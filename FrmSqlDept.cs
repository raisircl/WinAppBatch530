using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace WinAppBatch530
{
    public partial class FrmSqlDept : Form
    {
        public FrmSqlDept()
        {
            InitializeComponent();
        }
        //Data Source=.\sqlexpress;Initial Catalog=winappbatch4pmdb;Persist Security Info=True;User ID=sa;Password=***********
        SqlConnection conn=new SqlConnection();
        SqlCommand cmd = new SqlCommand();  
        SqlDataAdapter da=new SqlDataAdapter();
        
        DataSet ds = new DataSet(); 

        private void FrmSqlDept_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = @"Data Source=.\sqlexpress;Initial Catalog=winappbatch4pmdb;Persist Security Info=True;User ID=sa;Password=rai11**";
            loadgrid();
        }
        void loadgrid()
        {
            ds.Tables.Clear();

            cmd.CommandText = "select DNo DeptNo, DName DeptName, Loc Location from rai.tbldept";
            cmd.CommandType=CommandType.Text;
            cmd.Connection = conn;  
            
            da.SelectCommand = cmd;

            da.Fill(ds, "dept");
            dgv1.DataSource = ds.Tables["dept"];

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "insert into rai.tbldept values(@dname,@loc)";
            cmd.CommandType=CommandType.Text;
            cmd.Connection = conn;
            cmd.Parameters.AddWithValue("@dname",txtDName.Text);
            cmd.Parameters.AddWithValue("@loc", txtLoc.Text);
            
            conn.Open(); 
            
            cmd.ExecuteNonQuery();
            
            cmd.Parameters.Clear();
            conn.Close();

            loadgrid();
        }
    }
}
