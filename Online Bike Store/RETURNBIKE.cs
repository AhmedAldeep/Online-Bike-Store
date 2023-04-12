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
    public partial class RETURNBIKE : UserControl
    {
        string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
        string use;
        int a;
        string AMM;
        int ammm;
        int aaaa;
        DateTime noe, ne;
        DateTime ff;
        public RETURNBIKE(string y)
        {
            InitializeComponent();
            use = y;
            string sql = "SELECT * FROM rent where user_username='" + use + "'";
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
        // RETURN IT BUTTON
        private void metroButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(mycon);
            //noe = DateTime.Now.Date.AddDays(5);
            noe = DateTime.Now.Date;
            string totalcuree = noe.Day + "-" + noe.Month + "-" + noe.Year;
            string pro2 = metroGrid1.CurrentRow.Cells[2].Value.ToString();
            string pro23 = metroGrid1.CurrentRow.Cells[4].Value.ToString();
            metroTextBox5.Visible = true;
            ne = Convert.ToDateTime(pro23);
            string totaldata = ne.Day + "-" + ne.Month + "-" + ne.Year;

            MessageBox.Show("Now = " + noe.ToString());
            MessageBox.Show("Return = " + ne.ToString());
            if (ne.Day >= noe.Day && ne.Month >= noe.Month && ne.Year >= noe.Year)
            {
                metroTextBox5.Text = "Thank You For Using Our System";
            }
            else
            {
                con.Open();
                ne = noe.AddDays(7);
                string totaldata1 = ne.Day + "-" + ne.Month + "-" + ne.Year;
                // ff = Convert.ToDateTime(totaldata1);
                MessageBox.Show("do");
                string query = "INSERT INTO [BLOCK] (user_username,BLOCK) Values ('" + use + "','" + ne + "') ";
                SqlCommand cmd1 = new SqlCommand(query, con);
                try
                {
                    cmd1.ExecuteNonQuery();
                    metroTextBox5.Text = "Sorry For That .. But You Have To Return This Bike At " + pro23 + " So System Will Block You For A Week \n Hopefully If You Return To Us Again ";

                }
                catch (Exception ex)
                {
                    MetroFramework.MetroMessageBox.Show(this, ex.Message);
                }


                con.Close();
            }
            string pro = metroGrid1.CurrentRow.Cells[2].Value.ToString();

            string q1 = "select ammount from bike where product_code = '" + pro + "'";
            SqlCommand cmd0 = new SqlCommand(q1, con);
            con.Open();
            SqlDataReader d = cmd0.ExecuteReader();
            if (d.Read())
            {
                AMM = d["ammount"].ToString();
            }


            a = Int32.Parse(AMM);


            aaaa = a + 1;
            con.Close();
            string query1 = "update [bike] set ammount='" + aaaa + "' where product_code ='" + pro + "' ;";
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
            string pro233 = metroGrid1.CurrentRow.Cells[0].Value.ToString();
            con.Close();

            string query1r = "delete from rent where rent_number='"+pro233+"' ;";
            con.Open();
            SqlCommand cmd111r = new SqlCommand(query1r, con);
            SqlDataReader readerr;
            try
            {
                readerr = cmd111r.ExecuteReader();

            }
            catch (Exception ex)
            {
                MetroFramework.MetroMessageBox.Show(this, ex.Message);
            }

        }
    }

}
    
