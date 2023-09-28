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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        DataSet ds = new DataSet();
        
        DataTable dt=new DataTable("tbldept");
        
        DataColumn dc1 = new DataColumn("DNo");
        DataColumn dc2 = new DataColumn("DName");
        DataColumn dc3 = new DataColumn("Loc");

        int ci = -1;
        private void Form7_Load(object sender, EventArgs e)
        {
            dt.Columns.Add(dc1);    
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            
            ds.Tables.Add(dt);  
            
            dgv1.DataSource = ds.Tables["tbldept"];

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow row = ds.Tables["tbldept"].NewRow();
            row["Dno"]=txtDNo.Text;
            row["DName"]=txtDName.Text;
            row["Loc"] = txtLoc.Text;
            ds.Tables["tbldept"].Rows.Add(row);
            reset();

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            reset();
        }
        void reset()
        {
            ci = -1;
            txtDNo.Text = "";
            txtDName.Text = "";
            txtLoc.Text = "";
            txtDNo.Focus();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>=0)
            {
                ci= e.RowIndex;
                txtDNo.Text = dgv1.Rows[ci].Cells["DNo"].Value.ToString();
                txtDName.Text = dgv1.Rows[ci].Cells["DName"].Value.ToString();
                txtLoc.Text = dgv1.Rows[ci].Cells["Loc"].Value.ToString();

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(ci>=0)
            {
                DataRow dr = ds.Tables["tblDept"].Rows[ci];
                dr["Dno"] = txtDNo.Text;
                dr["DName"] = txtDName.Text;
                dr["Loc"] = txtLoc.Text;
                reset();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ci >= 0)
            {
                ds.Tables["tblDept"].Rows.RemoveAt(ci); 
                reset();
            }
        }
    }
}
