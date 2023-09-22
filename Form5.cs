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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Add")
            {
                if (!listBox1.Items.Contains(textBox1.Text))
                {
                    listBox1.Items.Add(textBox1.Text);
                    Reset();
                }
                else
                {
                    MessageBox.Show("Can Not Add Duplicate");
                }
            }
            else
            {
                if (!listBox1.Items.Contains(textBox1.Text))
                {
                    listBox1.Items[listBox1.SelectedIndex] = textBox1.Text;
                    Reset();
                }
                else
                {
                    MessageBox.Show("Can Not Update Duplicate");
                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(listBox1.SelectedIndex >= 0)
            {
                textBox1.Text = listBox1.SelectedItem.ToString();
                button1.Text = "Update";
            }
           
        }
        void Reset()
        {
            textBox1.Text = "";
            button1.Text = "Add";
            textBox1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = listBox1.Items.Count;
            label1.Text = "";
            for (int i = 0; i < x; i++)
            {
                label1.Text+= listBox1.Items[i].ToString() + "\n"; 
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int x = listBox1.Items.Count;
            for (int i = 0; i < x; i++)
            {
                listBox1.Items.RemoveAt(0);
            }
        }
    }
}
