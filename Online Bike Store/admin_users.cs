using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Analysis19
{
    public partial class admin_users : UserControl
    {
        string myconn = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
        SqlDataAdapter sa;
        SqlCommandBuilder sb;
        BindingSource bsource;
        DataTable da;
        DataSet ds;
        public admin_users()
        {
            InitializeComponent();
            string q = "SELECT * FROM [USER]";
            /* SqlConnection connection = new SqlConnection(myconn);
             connection.Open();
             SqlCommand s = new SqlCommand(sql, connection);
             sa = new SqlDataAdapter(s);
             da = new DataTable();
             sa.Fill(da);
             bsource = new BindingSource();
             bsource.DataSource = da;
             sb= new SqlCommandBuilder(sa);
             metroGrid1.DataSource = bsource;
             sa.Update(da);
             connection.Close();*/
            //string q = "select * from PRISONER";
            sa = new SqlDataAdapter(q, myconn);
            ds = new DataSet();
            sa.Fill(ds);
            metroGrid1.DataSource = ds.Tables[0];
        }
        // SAVE CHANGE 
        private void metroButton1_Click(object sender, EventArgs e)
        {
            sb = new SqlCommandBuilder(sa);
            sa.Update(ds.Tables[0]);
            MetroFramework.MetroMessageBox.Show(this, "\n\n\t Saved");

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(myconn);
            string pro3 = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            MessageBox.Show(pro3);
            string query1r = "delete from BLOCK where user_username='" + pro3 + "' ;";
            connection.Open();
            SqlCommand cmd111r = new SqlCommand(query1r, connection);
            SqlDataReader readerr;
            try
            {
                readerr = cmd111r.ExecuteReader();
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t UNBLOCK");


            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }

        }
    }
}
