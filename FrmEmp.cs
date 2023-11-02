using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppBatch530
{
    public partial class FrmEmp : Form
    {
        public FrmEmp()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        DataSet ds = new DataSet();
        DataSet ds1 = new DataSet();

        SqlDataAdapter da = new SqlDataAdapter();
        int ci = -1;
        private void FrmEmp_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=winappbatch4pmdb;User Id=sa;Password=rai11**";

            loadgrid();
            loaddept(); 
        }
        void loadgrid()
        {
            ds.Tables.Clear();
            comm.CommandText = "select * from tblemp";
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            da.SelectCommand = comm;

            da.Fill(ds, "emp");
            dgv1.DataSource = ds.Tables["emp"];
        }
        void loaddept()
        {
            ds1.Tables.Clear();
            comm.CommandText = "select * from rai.tblDept";
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            da.SelectCommand = comm;

            da.Fill(ds1, "dept");
            cmbDept.DataSource = ds1.Tables["dept"];
            cmbDept.DisplayMember = "DName";
            cmbDept.ValueMember = "DNo";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            comm.CommandText = "insert into tblemp(ename,dno) values(@ename,@dno)";
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.Parameters.AddWithValue("@ename", txtEname.Text);
            comm.Parameters.AddWithValue("@dno", cmbDept.SelectedValue);

            conn.Open();
            int x = comm.ExecuteNonQuery();
            conn.Close();
            comm.Parameters.Clear();

            MessageBox.Show($"Data Save and Affected Rows are {x}");
           
        }
    }
}
