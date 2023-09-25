using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppBatch530
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        int i;
        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            foreach(var item in checkedListBox1.CheckedItems)
            {
                label1.Text += item.ToString() +"\n"; 
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text=comboBox1.SelectedItem.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum=listBox1.Items.Count;
            i = 0;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(i<progressBar1.Maximum) {
                listBox2.Items.Add(listBox1.Items[i]);
                i++;
                progressBar1.Value = i;
            }
            else
            {
                timer1.Stop();
            }
        }
    }
}
