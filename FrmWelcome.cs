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
    public partial class FrmWelcome : Form
    {
        public FrmWelcome()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Welcome {txtName.Text}","Greet!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmWelcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult x;
            x = MessageBox.Show("do you want to close?","Confirmation to Close",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (x == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel=true;
            }

        }
    }
}
