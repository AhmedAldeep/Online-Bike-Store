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
    public partial class new_spare : UserControl
    {
        string Title = "";
        string Title2 = "";
        public new_spare()
        {
            InitializeComponent();
        }

        private void new_spare_Load(object sender, EventArgs e)
        {

        }
        // ADD PHOTO
        private void label2_Click(object sender, EventArgs e)
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
        // ADD NEW SPARE BUTTON
        private void metroButton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            if (metroTextBox4.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Enter SPARE PART Code  ");

            }
            else if (metroComboBox2.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Select SPARE PART NAME ");

            }
            else if (metroTextBox2.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Write The spare Part Descrption");

            }
            else if (metroTextBox3.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Spare Part Price ");

            }
            else if (metroTextBox1.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter The Spare Part Ammount");

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select spare_code from [spare]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["spare_code"].ToString() == metroTextBox4.Text)
                    {
                        flag = true;
                        break;
                    }
                }

                re.Close();
                if (flag == true)
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tThere Are Spare Code With Same Code ");
                else
                {
                  

                    string query = "INSERT INTO [spare] (spare_name,spare_code,price,ammont,descrption,spare_part1) Values ('" + this.metroComboBox2.Text + "','" + this.metroTextBox4.Text + "','" + this.metroTextBox3.Text + "','" + this.metroTextBox1.Text + "','" + this.metroTextBox2.Text + "','" + Title + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);
                    try
                    {

                        cmd1.ExecuteNonQuery();
                        pictureBox2.Image = null;
                        pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\t Spare Bike Added ");
                        metroTextBox1.Text = null;
                        metroTextBox2.Text = null;
                        metroTextBox3.Text = null;
                        metroTextBox4.Text = null;

                        metroComboBox2.Text = null;
                    }
                    catch (Exception ex)
                    {
                        MetroFramework.MetroMessageBox.Show(this, ex.Message);
                    }
                }
            }

        }
    }
}
