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
    public partial class Buy_Bike : UserControl
    {
        string myconn = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
        int Rate = 0, Amm;
        string use;
        string am;
        int am1;
        int rr;
        int aaaa;
        string rr2;
        public Buy_Bike(string f)
        {
            InitializeComponent();
            use = f;
           
            //=============================================================
            string sql = "SELECT product_code,brand,imagge FROM bike where ammount > 0 and rentornot='"+"FOR SALE"+"'";
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
            metroGrid1.Columns[2].Visible = false;
        }
        // Buy Bike Button
        private void metroButton2_Click(object sender, EventArgs e)
        {
            int ppp = Int32.Parse(metroTextBox3.Text);
            DateTime noe = DateTime.Now;
            SqlConnection con = new SqlConnection(myconn);
            con.Open();
            int p = rr * ppp;
            string query = "INSERT INTO [sells] (user_username,product_number,price,date,ammont) Values ('" + use + "','" + this.metroTextBox4.Text + "','" + p+ "','" + noe + "','" + rr + "') ";
            SqlCommand cmd1 = new SqlCommand(query, con);
            try
            {
                cmd1.ExecuteNonQuery();
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t You Have Buy "+rr+ " Bike With "+p+" $ Thank You For Using Our System  ");
                metroTextBox1.Text = null;
                metroTextBox2.Text = null;
                metroTextBox3.Text = null;
                
              
                metroTextBox8.Text = null;
                label13.Visible = false;
                metroTrackBar2.Value = 0;
                label6.Text = "0";
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }


            con.Close();

            aaaa = Amm - rr;
            
            string query1 = "update [bike] set ammount='" + aaaa + "' where product_code ='" + this.metroTextBox4.Text + "' ;";
            con.Open();
            SqlCommand cmd111 = new SqlCommand(query1, con);
            SqlDataReader reader;
            try
            {
                reader = cmd111.ExecuteReader();

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
            metroTextBox4.Text = null;
        }

        private void metroTrackBar2_Scroll(object sender, ScrollEventArgs e)
        {
            rr2 = metroTrackBar2.Value.ToString();
            rr = Int32.Parse(rr2);
            label6.Text = metroTrackBar2.Value.ToString();
        }

        private void metroTrackBar2_TextChanged(object sender, EventArgs e)
        {

        }

        // CELL CLICK 
        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            metroTrackBar2.Value = 0;
            label6.Text="0";
            string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cod = new SqlCommand("Select ammount from [bike] where product_code='" + this.metroTextBox4.Text + "' ;", con);
            SqlDataReader myreader;
            myreader = cod.ExecuteReader();
            int count = 0;
            if (myreader.Read())
            {
                am = myreader["ammount"].ToString();
                am1 = Int32.Parse(am);
                metroTrackBar2.Maximum = am1;

            }
            con.Close();
            myreader.Close();
            //=================================================================
            string path = "";
            //SqlConnection con = new SqlConnection(myconn);
            con.Open();
            string pro = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            string pro2 = metroGrid1.CurrentRow.Cells[1].Value.ToString();
            metroTextBox4.Text = pro;
            metroTextBox8.Text = pro2;
            string q1 = "select descrption,price,ammount,imagge,rate from bike where product_code = '" + pro + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            string ee;
            int h;
            if (d.Read())
            {
                string sts = "";
                metroTextBox2.Text = d[0].ToString();
                metroTextBox3.Text = d[1].ToString();
                Amm = Int32.Parse(d[2].ToString());
                if (Amm < 1)
                    sts = "Unavailable";
                else
                    sts = "Available";
                metroTextBox1.Text = sts;
                path = d[3].ToString();
                pictureBox2.ImageLocation = path;
                ee = d[4].ToString();
                label13.Visible = true;
                label13.Text = ee;
            }
        }
    }
}
