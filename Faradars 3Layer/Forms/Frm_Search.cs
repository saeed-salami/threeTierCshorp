using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;

namespace Faradars_3Layer.Forms
{
    public partial class Frm_Search : Form
    {
        public Frm_Search()
        {
            InitializeComponent();
        }

        private void Frm_Search_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 1;
            BL_Frm_Search M = new BL_Frm_Search();
            dataGridView1.DataSource = M.Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BL_Frm_Search M = new BL_Frm_Search();
            M.reng = comboBox1.SelectedIndex;
            M.TextCommand = textBox1.Text;
            dataGridView1.DataSource = M.Select_Search();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count != 0 && dataGridView1.CurrentCell.ColumnIndex == 0)
            {
                Frm_Edit_Book Fo4 = new Frm_Edit_Book();
                Fo4.textBox1.Text = Convert.ToString(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
                Fo4.textBox2.Text = Convert.ToString(dataGridView1[3, dataGridView1.CurrentRow.Index].Value.ToString());
                Fo4.Case_Book = Convert.ToString(dataGridView1[4, dataGridView1.CurrentRow.Index].Value.ToString());
                Fo4.textBox3.Text = Convert.ToString(dataGridView1[5, dataGridView1.CurrentRow.Index].Value.ToString());
                Fo4.textBox4.Text = Convert.ToString(dataGridView1[6, dataGridView1.CurrentRow.Index].Value.ToString());
                Fo4.textBox5.Text = Convert.ToString(dataGridView1[7, dataGridView1.CurrentRow.Index].Value.ToString());
                Fo4.textBox6.Text = Convert.ToString(dataGridView1[8, dataGridView1.CurrentRow.Index].Value.ToString());
                Fo4.textBox7.Text = Convert.ToString(dataGridView1[9, dataGridView1.CurrentRow.Index].Value.ToString());
                
                Fo4.ShowDialog();
            }
            else if (dataGridView1.Rows.Count != 0 && dataGridView1.CurrentCell.ColumnIndex == 1)
            {
                if (MessageBox.Show("آیا از حذف اطمینان دارید؟","پیغام",MessageBoxButtons.YesNo)==DialogResult.Yes)
                {
                BL_Frm_Search M = new BL_Frm_Search();
                M.ISBN = Convert.ToString(dataGridView1[2, dataGridView1.CurrentRow.Index].Value.ToString());
                M.Delete();
                Frm_Search_Load(null, null);
                }
               
            }

        }

        private void Frm_Search_Activated(object sender, EventArgs e)
        {
            Frm_Search_Load(null, null);
        }
    }
}
