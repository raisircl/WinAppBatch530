using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppBatch530
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(chkPlay.Checked && chkRead.Checked) {
                
                MessageBox.Show("Execelnt");
            }
            else if(chkPlay.Checked)
            {
                MessageBox.Show("Good");
            }
            else if(chkRead.Checked) {
                MessageBox.Show("Very Good");
            }
            else
            {
                MessageBox.Show("Please select a hobby then click me");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked) { 
                textBox2.Text=textBox1.Text;   
            }
            else
            {
                textBox2.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

                MessageBox.Show($"Hello Mr. {txtName.Text}");
            }
            else
            {
                MessageBox.Show($"Hello Ms. {txtName.Text}");
            }
        }
    }
}
