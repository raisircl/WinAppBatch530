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
    public partial class FrmDepartment : Form
    {
        public FrmDepartment()
        {
            InitializeComponent();
        }
        // 1. Fetch Data
        // 1.1 Establish the Connection. Need to create Connection Class Object SqlConnection
        /*
            SqlConnection
            Properties          Value
            A.ConnectionString    Connection String of DataBase 
                Note - 
                1. We can establish the connection with DB using SQL Server Authentication for this we need user name and pwd
                2. We can establish the connection using Windows Authentication
           
              Example:  
               1. "Data Source=Server Name;Initial Catalog=dbname;User Id=sa;Password=pwd" (Sql Server Authentication)
               2. "Data Source=ServerName;nitial Catalog=dbname;Integrated Security=true"
            B.State (Read Only)=> I has enumrated Value of type ConnectionState (Open, Close)
            
            Functions 
            Open() = Open the connection with DB
            Close()  Close he connection

           Note - Connection String can also passed in constructor
         
        1.2  - Prepare Command to fetch the data and for this we need to create SqlCommand Class Object
             SqlCommand - 
            Properties      Values
            CommandText     A valid Sql Statement in string it can be SQL Query, Stored Procedure or Table Name
            Connection      Object of SqlConnection
            CommandType     Enumrated value of type CommandType (Text, StoredProcedure, TableDirect)
            Parameters      We need to add paramaters with value if command required the parameters
                            Parameters is Collection of SqlParameter Objects
        
            Function          Description 
            ExecuteReader()   We call it in case of Select statement when it returns numbers of rows
                              It returns the data as an object of SqlDataReader class
                              When we call it the in left side we need to store its data in SqlDatReader reference
            ExecuteScalar()   It also call in case select when select statement return only scaler value
                              Scaler Value mean One Row and One Column. 
                              Aggregation Function behave like this. eg select sum(sal) from tblemp
                              It returns value as object
            ExecuteNonQuery() We call it in case of Insert Update or Delete.
                              It return number of rows affected by sql stament  
        
        1.3 SqlDataAdapter - It is responsible to fetch the data from db and fill in dataset
             Properties      value   
             SelectCommand  Object of SqlCommand Class
         
             Function                       Work
             Fill(dataset, "tablename")     fetch data from db and fill to dataset 
             Update(dataset,"tablename")    as per SqlCommandBuilder It Update The data into database
             

         */

        //SqlConnection conn=new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=winappbatch4pmdb;User Id=sa;Password=rai11**"); 
        
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        DataSet ds=new DataSet();
        SqlDataAdapter da=new SqlDataAdapter();
        int ci = -1;
        //SqlConnection conn = null;  
        private void FrmDepartment_Load(object sender, EventArgs e)
        {
            conn.ConnectionString =  @"Data Source=.\SQLEXPRESS;Initial Catalog=winappbatch4pmdb;User Id=sa;Password=rai11**";
            //conn.ConnectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=winappbatch4pmdb;Integrated Security=true";
            //conn=new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=winappbatch4pmdb;User Id=sa;Password=rai11**");
            fetchdata();

        }
        void fetchdata()
        {
            ds.Tables.Clear();
            comm.CommandText = "select * from rai.tblDept";
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            da.SelectCommand = comm;

            da.Fill(ds, "dept");
            dgv1.DataSource = ds.Tables["dept"];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            comm.CommandText = "insert into rai.tbldept values(@dname,@loc)";
            comm.Connection = conn;
            comm.CommandType=CommandType.Text;
            comm.Parameters.AddWithValue("@dname", txtDName.Text);
            comm.Parameters.AddWithValue("@loc", txtLoc.Text);
            
            conn.Open();    
            int x=comm.ExecuteNonQuery();
            conn.Close();
            comm.Parameters.Clear();

            MessageBox.Show($"Data Save and Affected Rows are {x}");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (ci > -1)
            {
                comm.CommandText = "update rai.tblDept set DName=@dname, Loc=@loc where DNo=@dno";
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;
                comm.Parameters.AddWithValue("@dname", txtDName.Text);
                comm.Parameters.AddWithValue("@loc", txtLoc.Text);
                comm.Parameters.AddWithValue("@dno", txtDNo.Text);

                conn.Open();
                int x = comm.ExecuteNonQuery();
                conn.Close();
                comm.Parameters.Clear();

                MessageBox.Show($"Data Updated and Affected Rows are {x}");
                ci = -1;
                fetchdata();
            }
            else
            {
                MessageBox.Show("Please Select A Record");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (ci > -1)
            {
                comm.CommandText = "delete from rai.tbldept where DNo=@dno";
                comm.Connection = conn;
                comm.CommandType = CommandType.Text;

                comm.Parameters.AddWithValue("@dno", txtDNo.Text);

                conn.Open();
                int x = comm.ExecuteNonQuery();
                conn.Close();
                comm.Parameters.Clear();

                MessageBox.Show($"Data Deleted and Affected Rows are {x}");
                ci = -1;
                fetchdata();
            }
            else
            {
                MessageBox.Show("Please Select A Record");
            }
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex>-1)
            {
                ci=e.RowIndex;
                txtDNo.Text = dgv1.Rows[ci].Cells["DNo"].Value.ToString();
                txtDName.Text = dgv1.Rows[ci].Cells["DName"].Value.ToString();
                txtLoc.Text = dgv1.Rows[ci].Cells["Loc"].Value.ToString();
            }
        }
    }
}
