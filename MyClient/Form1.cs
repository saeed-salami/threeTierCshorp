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
using System.Threading;
using System.Text;

namespace MyClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IPAddress Myip = null;
            Int16 Myport = 0;

            Myip = Dns.Resolve(Dns.GetHostName()).AddressList[0];
            Myport = Convert.ToInt16("8650");

            TcpClient Cl = new TcpClient();
            Cl.Connect(Myip.ToString(), Myport);

            NetworkStream Ns = null;
            Ns = Cl.GetStream();

            //******************

            string sendC = textBox1.Text;
            byte[] writebuffer = new byte[1024];
            writebuffer = Encoding.UTF8.GetBytes(sendC);
            Ns.Write(writebuffer, 0, writebuffer.Length);

            byte[] Readbuffer = new byte[1024];
            Int32 Readcount = 0;
            string Servermess = null;
            Readcount = Ns.Read(Readbuffer, 0, Readbuffer.Length);
            Servermess = Encoding.UTF8.GetString(Readbuffer, 0, Readcount);
            richTextBox1.Text = Servermess;

        }
    }
}
