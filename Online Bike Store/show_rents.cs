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
    public partial class show_rents : UserControl
    {
        string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";

        public show_rents()
        {
            InitializeComponent();
            string sql = "SELECT * FROM rent";
            SqlConnection connection = new SqlConnection(mycon);
            connection.Open();
            SqlCommand s = new SqlCommand(sql, connection);
            SqlDataAdapter sa = new SqlDataAdapter(s);
            DataTable da = new DataTable();
            sa.Fill(da);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = da;
            SqlCommandBuilder sb = new SqlCommandBuilder(sa);
            metroGrid1.DataSource = bsource;
            sa.Update(da);
            connection.Close();
        }

        private void metroDateTime1_ValueChanged(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM rent where date_of_rent ='" + metroDateTime1.Value + "'";
            SqlConnection connection = new SqlConnection(mycon);
            connection.Open();
            SqlCommand s = new SqlCommand(sql, connection);
            SqlDataAdapter sa = new SqlDataAdapter(s);
            DataTable da = new DataTable();
            sa.Fill(da);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = da;
            SqlCommandBuilder sb = new SqlCommandBuilder(sa);
            metroGrid1.DataSource = bsource;
            sa.Update(da);
            connection.Close();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM rent";
            SqlConnection connection = new SqlConnection(mycon);
            connection.Open();
            SqlCommand s = new SqlCommand(sql, connection);
            SqlDataAdapter sa = new SqlDataAdapter(s);
            DataTable da = new DataTable();
            sa.Fill(da);
            BindingSource bsource = new BindingSource();
            bsource.DataSource = da;
            SqlCommandBuilder sb = new SqlCommandBuilder(sa);
            metroGrid1.DataSource = bsource;
            sa.Update(da);
            connection.Close();
        }
    }
}
