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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //WYSWYG
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Hello {txtName.Text}");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
