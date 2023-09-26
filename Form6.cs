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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TreeNode tnode = new TreeNode(txtNode.Text);
            tnode.ImageIndex = 0;
            tnode.SelectedImageIndex = 1;
            treeView1.SelectedNode.Nodes.Add(tnode);    

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem litm=new ListViewItem(txtName.Text);
            litm.SubItems.Add(txtJob.Text);
            litm.SubItems.Add(txtSal.Text);
            litm.ImageIndex = 0;
            
            listView1.Items.Add(litm);  
        }

        private void largeIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }

        private void smallIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View=View.SmallIcon;
        }

        private void detailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }
    }
}
