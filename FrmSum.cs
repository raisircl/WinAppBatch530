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
    public partial class FrmSum : Form
    {
        public FrmSum()
        {
            InitializeComponent();
        }

       
        private void btnOperations_Click(object sender, EventArgs e)
        {
            Button x=(Button)sender;

            if (x.Text == "+")
            {
                lblResult.Text = Convert.ToString(Convert.ToInt32(txtN1.Text) + Convert.ToInt32(txtN2.Text));
            }
            else if(x.Text == "-") {
                lblResult.Text = Convert.ToString(Convert.ToInt32(txtN1.Text) - Convert.ToInt32(txtN2.Text));

            }
            else if(x.Text=="*"){
                lblResult.Text = Convert.ToString(Convert.ToInt32(txtN1.Text) * Convert.ToInt32(txtN2.Text));

            }
            else if(x.Text == "/")
            {
                lblResult.Text = Convert.ToString(Convert.ToInt32(txtN1.Text) / Convert.ToInt32(txtN2.Text));

            }
        }
        private void FrmSum_MouseMove(object sender, MouseEventArgs e)
        {
            label4.Text=e.X.ToString()+", " + e.Y.ToString(); 
        }

       
    }
}
