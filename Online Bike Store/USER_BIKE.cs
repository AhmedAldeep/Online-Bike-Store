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
    public partial class USER_BIKE : UserControl
    {
        string myconn = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
        int Rate=0, Amm;
        int SQLRATE;
        string SQLRATE1;
        int Rate2;
        string rr;
        string use;
        public USER_BIKE(string UUU)
        {
            InitializeComponent();
            use = UUU;
            string sql = "SELECT product_code,brand,imagge FROM bike";
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

        private void metroTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            rr = metroTrackBar1.Value.ToString();
            label3.Text = metroTrackBar1.Value.ToString() + " %";
        }

        private void metroTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            rr = metroTrackBar1.Value.ToString();
            label3.Text = metroTrackBar1.Value.ToString() + " %";

        }
        // RATE 
        private void metroButton2_Click(object sender, EventArgs e)
        {

            string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            string pro3 = metroGrid1.CurrentRow.Cells[0].Value.ToString();

            int count = 0;
            con.Open();
           string q11 = "select rate from Rate_Table where product_code = '" + pro3 + "'";
           SqlCommand cmd01 = new SqlCommand(q11, con);
           SqlDataReader d1 = cmd01.ExecuteReader();
           while (d1.Read())
           {
                
                 count++;
                
                SQLRATE1 = d1["rate"].ToString();
                if(SQLRATE1==string.Empty||SQLRATE1==null)
                {
                    Rate2 = Int32.Parse(rr);                       
                }
                else
                {
                    SQLRATE = Int32.Parse(SQLRATE1);
                    Rate = Rate + SQLRATE;
                }
                
           }
            int rr2 = Int32.Parse(rr);
           if(SQLRATE1==string.Empty||SQLRATE1==null)
                Rate2 = Int32.Parse(rr);
           else
                Rate2 = (Rate+rr2) / (count+1);

            d1.Close();

            string query = "insert into [Rate_Table] (product_code,username,rate) values ('"+metroTextBox4.Text+"','"+use+"','"+rr2+"') ";
            SqlCommand cmd1 = new SqlCommand(query, con);
            try
            {
                cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }

            string query1 = "update [bike] set rate='" + Rate2 + "' where product_code='" + pro3 + "'; ";
            SqlCommand cmd11 = new SqlCommand(query1, con);
            try
            {

                cmd11.ExecuteNonQuery();
                pictureBox2.Image = null;
                pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Rated ");
                metroTextBox1.Text = null;
                metroTextBox8.Text = null;
                metroTextBox3.Text = null;
                metroTextBox4.Text = null;
                label3.Text = "0%";
                metroTextBox5.Text = null;
            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }
        }
        // CELL CLICK BUTTON
        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string path = "";
            SqlConnection con = new SqlConnection(myconn);
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
                metroTextBox5.Text = d[0].ToString();
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
                if (ee != string.Empty)
                {
                    h = Int32.Parse(ee);
                    metroTrackBar1.Value = h;
                    label3.Text = h.ToString() + "%";
                }
                else
                {
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\t No Rate Yet !.. Rate This One Please ");

                }

            }
           
        }
    }
}
