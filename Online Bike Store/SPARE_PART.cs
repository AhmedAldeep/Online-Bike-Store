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
using System.IO;
namespace Analysis19
{
    public partial class SPARE_PART : UserControl
    {
        string myconn = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";

        public SPARE_PART()
        {
            InitializeComponent();
            string sql = "SELECT spare_code,spare_name FROM spare";
            SqlConnection connection = new SqlConnection(myconn);
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
        // Update Button
        private void metroButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconn);
            string query = "update [spare] set price='" + this.metroTextBox3.Text + "',ammont='" + this.metroTextBox1.Text + "' where spare_code ='" + this.metroTextBox4.Text + "' ;";
            con.Open();
            SqlCommand cmd1 = new SqlCommand(query, con);
            SqlDataReader reader;
            try
            {
                reader = cmd1.ExecuteReader();
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t  Spare Part Price And Ammount has Been Edited");

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // cell click event
        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = "";
            SqlConnection con = new SqlConnection(myconn);
            con.Open();
            string pro = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            string pro2 = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            metroTextBox4.Text = pro;
            metroTextBox8.Text = pro2;
            string q1 = "select descrption,price,ammont,spare_part1 from spare where spare_code = '" + pro + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            if (d.Read())
            {
                metroTextBox2.Text = d[0].ToString();
                metroTextBox3.Text = d[1].ToString();
                metroTextBox1.Text = d[2].ToString();
                path = d[3].ToString();
                pictureBox2.ImageLocation = path;
            }
        }
        // Delete Spare Part
        private void metroButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconn);

            con.Open();
            string query = "Delete from spare where spare_code='" + this.metroTextBox4.Text + "' ;";
            SqlCommand cmd1 = new SqlCommand(query, con);
            cmd1.CommandText = query;
            cmd1.Connection = con;
            cmd1.ExecuteNonQuery();
        }
    }
}
