using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using BL;

namespace Faradars_3Layer.Forms
{
    public partial class Mom : Form
    {
        public Mom()
        {
            InitializeComponent();
        }

        private TcpListener Sr;
        private bool StartServer = false;
        DataTable DT = new DataTable();
        public void Listen()
        {
            while (StartServer)
            {
                TcpClient Cl = null;
                Cl = Sr.AcceptTcpClient();

                NetworkStream Ns = null;
                Ns = Cl.GetStream();

                byte[] readbuffer = new byte[1024];
                Int32 readcount = 0;

                string clintmess = null;
                readcount = Ns.Read(readbuffer, 0, readbuffer.Length);

                clintmess = Encoding.UTF8.GetString(readbuffer, 0, readcount);

                //******************

                BL_Mom M = new BL_Mom();
                M.ISBN = clintmess;
                DT = M.Select();
                //*****************
                string Ans;
                Ans = Convert.ToString(DT.Rows[0][0].ToString()) + Environment.NewLine + Convert.ToString(DT.Rows[0][1].ToString()) + Environment.NewLine + Convert.ToString(DT.Rows[0][2].ToString()) + Environment.NewLine + Convert.ToString(DT.Rows[0][3].ToString()) + Environment.NewLine + Convert.ToString(DT.Rows[0][4].ToString()) + Environment.NewLine + Convert.ToString(DT.Rows[0][5].ToString()) + Environment.NewLine + Convert.ToString(DT.Rows[0][6].ToString()) + Environment.NewLine + Convert.ToString(DT.Rows[0][7].ToString());

                byte[] writeBuffer = new Byte[1024];
                writeBuffer = Encoding.UTF8.GetBytes(Ans);
                Ns.Write(writeBuffer, 0, writeBuffer.Length);

            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Frm_New_Book Fo2 = new Frm_New_Book();
            Fo2.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Frm_Search Fo3 = new Frm_Search();
            Fo3.ShowDialog();
        }

        private void Mom_Load(object sender, EventArgs e)
        {
            IPAddress myip = null;
            Int16 myport = 0;

            myip = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            myport = Convert.ToInt16("8650");

            Sr = new TcpListener(myip, myport);
            StartServer = true;
            Sr.Start();

            Thread Tr = new Thread(Listen);
            Tr.Start();

        }

        private void Mom_FormClosing(object sender, FormClosingEventArgs e)
        {
            StartServer = false;
            Sr.Stop();

        }

        
    }
}
