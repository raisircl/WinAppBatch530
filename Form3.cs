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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = dateTimePicker1.Value.ToString();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //FrmWelcome frm = new FrmWelcome();   
            //frm.ShowDialog();

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            label2.Text=monthCalendar1.SelectionStart.ToString();
            label3.Text=monthCalendar1.SelectionEnd.ToString(); 
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello I am Disha");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = Image.FromFile(@"C:\Users\RAI\Downloads\1.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = WinAppBatch530.Properties.Resources.logo;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
