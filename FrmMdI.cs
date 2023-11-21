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
    public partial class FrmMdI : Form
    {
        public FrmMdI()
        {
            InitializeComponent();
        }
        Form1 form1;
        Form2 form2;
        Form3 form3;
        Form4 form4;
        Form5 form5;   
        Form6 form6;
        Form7 form7;

        Form frm;
        private void MenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem mitm=(ToolStripMenuItem) sender;  

            int x=Convert.ToInt32(mitm.Tag);
            if (x == 1)
            {
                if (frm != null)
                {
                    frm.Close();
                }
                if (form1 == null)
                {
                    form1 = new Form1();
                    form1.MdiParent = this;
                    form1.Focus();
                }
                else if (form1.IsDisposed)
                {
                    form1 = new Form1();
                    form1.MdiParent = this;
                    form1.Focus();
                }
                else
                {
                    form1.Focus();
                    form1.WindowState = FormWindowState.Maximized;
                }
                frm = form1;
            }
            else if (x == 2)
            {
                if(frm!=null)
                {
                    frm.Close();    
                }
                if (form2 == null)
                {
                    form2 = new Form2();
                    form2.MdiParent = this;
                    form2.Focus();
                }
                else if (form2.IsDisposed)
                {
                    form2 = new Form2();
                    form2.MdiParent = this;
                    form2.Focus();
                }
                else
                {
                    form2.Focus();
                }
                frm = form2;
            }
        }

        private void formatToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
