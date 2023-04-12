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
    public partial class new_bike : UserControl
    {
        string Title = "";
        string Title2 = "";
        public new_bike()
        {
            InitializeComponent();
        }
        // Change Photo
        private void label3_Click(object sender, EventArgs e)
        {
            OpenFileDialog obg = new OpenFileDialog();
            obg.Filter = "Images(.jpg,.png)|*.png;*.jpg";
            obg.FilterIndex = 2;

            if (obg.ShowDialog() == DialogResult.OK)
            {
                pictureBox2.BackgroundImage = new Bitmap(obg.FileName);
                pictureBox2.Image = Image.FromFile(obg.FileName);
                Title = obg.FileName;
                Title2 = obg.SafeFileName.ToString();
            }
        }
        // ADD NEW BIKE BUTTON
        private void metroButton1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(Title);
            bool flag = false;
            string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            if (metroTextBox4.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Enter Bike Product Code  ");

            }
            else if (metroComboBox2.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Bike Brand ");

            }
            else if (metroTextBox2.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Write The Bike Descrption");

            }
            else if (metroTextBox3.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Bike Price ");

            }
            else if (metroTextBox1.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter The Bike Ammount");

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select product_code from [bike]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["product_code"].ToString() == metroTextBox4.Text)
                    {
                        flag = true;
                        break;
                    }
                }

                re.Close();
                if (flag == true)
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tThere Are Product With Same Product Code ");
                else
                {
                    string sts = "";
                    int Amm = Int32.Parse(metroTextBox1.Text);
                    if (Amm < 1)
                        sts = "Unavailable";
                    else
                        sts = "Available";
                    

                    string query = "INSERT INTO [bike] (product_code,brand,status,descrption,price,ammount,imagge,rentornot) Values ('" + this.metroTextBox4.Text + "','" + this.metroComboBox2.Text + "','" + sts + "','" + this.metroTextBox2.Text + "','" + this.metroTextBox3.Text + "','" + this.metroTextBox1.Text + "','"+Title+ "','" + metroComboBox1.Text + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    try
                    {
                       
                        cmd1.ExecuteNonQuery();
                        pictureBox2.Image = null;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\t New Bike Added ");
                        metroTextBox1.Text = null;
                        metroTextBox2.Text = null;
                        metroTextBox3.Text = null;
                        metroTextBox4.Text = null;
                        metroComboBox1.Text = null;
                        metroComboBox2.Text = null;
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                }
            }
        }

        private void new_bike_Load(object sender, EventArgs e)
        {
            //picture = new SqlParameter("@picture", SqlDbType.Image);
        }
    }
}

