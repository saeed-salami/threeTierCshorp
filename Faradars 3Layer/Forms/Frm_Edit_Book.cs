using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DA;
using BL;

namespace Faradars_3Layer.Forms
{
    public partial class Frm_Edit_Book : Form
    {
        public string Case_Book;
        public Frm_Edit_Book()
        {
            InitializeComponent();
        }

        private void Frm_Edit_Book_Load(object sender, EventArgs e)
        {
            BL_Frm_New_Book M = new BL_Frm_New_Book();
            dataGridView1.DataSource = M.Select();
            int i;
            for (i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                comboBox1.Items.Add(Convert.ToString(dataGridView1[1, i].Value.ToString()));
                if (Case_Book==comboBox1.Items[i].ToString())
                {
                    comboBox1.SelectedIndex = i;
                }
               
            }
              
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BL_Frm_Edit_Book M = new BL_Frm_Edit_Book();
            M.ISBN = textBox1.Text;
            M.Title = textBox2.Text;
            M.Subject = comboBox1.SelectedIndex+1;
            M.wirter = textBox3.Text;
            M.publishers = textBox4.Text;
            M.Year_Date = textBox5.Text;
            M.NumPage =Convert.ToInt16(textBox6.Text);
            M.Price = Convert.ToInt16(textBox7.Text);
            M.Update();
            this.Close();
        }
    }
}
