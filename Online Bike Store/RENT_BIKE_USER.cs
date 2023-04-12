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
    public partial class RENT_BIKE_USER : UserControl
    {
        string myconn = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
        //string use;
        int Rate = 0, Amm;
        string use;
        string am;
        int am1;
        int rr;
        int aaaa;
        string rr2;
        int p;
        int ppp;
        DateTime noe, ne, nef;
        string totalcuree;
        string totaldata;
        string UU;
        public RENT_BIKE_USER(string y)
        {

            InitializeComponent();
            use = y;
            string sql = "SELECT product_code,brand,imagge FROM bike where ammount > 0 and rentornot='" + "FOR RENT" + "'";
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
        // RENT BUTTON
        private void metroButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(myconn);
            noe = DateTime.Now;
            DateTime u = new DateTime();
            con.Open();
            string q1 = "select BLOCK from block where user_username = '" + use + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            SqlDataReader d = cmd0.ExecuteReader();
            string ee;
            int h;
            if (d.Read())
            {
                UU = d["BLOCK"].ToString();
            }
            d.Close();
            nef = Convert.ToDateTime(UU);
            string totaldata = nef.Day + "-" + nef.Month + "-" + nef.Year;
            if (noe.Day < nef.Day && noe.Month <= nef.Month)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t You Have Blocked Until " + nef + " Try To Return After This Date.");

            }
            else
            {
                //===============================================
                string query = "INSERT INTO [rent] (user_username,product_number,price,return_date,date_of_rent) Values ('" + use + "','" + this.metroTextBox4.Text + "','" + p + "','" + ne + "','" + noe + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                try
                {
                    cmd1.ExecuteNonQuery();
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\t You Have Rent " + metroTextBox8.Text + " Bike With " + p + " $ and You Should Return It IN " + metroDateTime2.Value.Date + " \nThank You For Using Our System  ");
                    metroTextBox1.Text = null;
                    metroTextBox2.Text = null;
                    metroTextBox5.Text = null;
                    metroTextBox8.Text = null;
                    label13.Visible = false;

                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message);
                }
                con.Close();
                aaaa = Amm - 1;
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
        }

        private void metroDateTime2_ValueChanged(object sender, EventArgs e)
        {

            noe = DateTime.Now.Date;
            ne = metroDateTime2.Value;


            int po = Int32.Parse(ne.Day.ToString());
            int po1 = Int32.Parse(noe.Day.ToString());
            int po2 = po - po1;

            p = ppp * po2;
            metroTextBox5.Text = p.ToString();
           totaldata = ne.Day + "-" + ne.Month + "-" + ne.Year;
            totalcuree = noe.Day + "-" + noe.Month + "-" + noe.Year;
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
      
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
                metroTextBox5.Text = d[1].ToString();
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
                ppp = Int32.Parse(metroTextBox5.Text);
            }
        }
    }
}
