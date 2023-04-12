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
    public partial class User_Register : UserControl
    {
        public User_Register()
        {
            InitializeComponent();
        }
        // Register button
        private void metroButton1_Click(object sender, EventArgs e)
        {
            bool flag = false;
            string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            if (metroTextBox3.Text != metroTextBox2.Text)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPassword Don't Match ");

            }
            else if (metroTextBox4.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Name ");

            }
            else if (!this.metroTextBox8.Text.Contains('@') || !this.metroTextBox8.Text.Contains('.'))
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\t Invalid Email .. Please Enter A Valid Email");

            }
            else if (metroTextBox8.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Email ");

            }
            else if (metroTextBox1.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter your Username ");

            }
            else if (metroTextBox2.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Password ");

            }
            else if (metroTextBox3.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Repeat Password ");

            }
            else if (metroTextBox7.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Mobile ");

            }
            else if (metroTextBox9.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Address ");

            }
            else if (metroTextBox5.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Age ");

            }
            else if (metroTextBox6.Text == null)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tPlease Enter Your Credit Card Number ");

            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("Select username from [user]", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader re = cmd.ExecuteReader();
                while (re.Read())
                {
                    if (re["username"].ToString() == metroTextBox1.Text)
                    {
                        flag = true;
                        break;
                    }
                }

                re.Close();
                if (flag == true)
                    MetroFramework.MetroMessageBox.Show(this, "\n\n\tThe Username is already Exist ");
                else
                {
                    
                    string query = "INSERT INTO [user] (full_name,username,age,password,credit_card,mobile,email,address) Values ('" + this.metroTextBox4.Text + "','" + this.metroTextBox1.Text + "','" + this.metroTextBox5.Text + "','" + this.metroTextBox2.Text + "','" + this.metroTextBox6.Text + "','" + this.metroTextBox7.Text + "','" + this.metroTextBox8.Text + "','" + this.metroTextBox9.Text + "') ";
                    SqlCommand cmd1 = new SqlCommand(query, con);                    
                    try
                    {
                        cmd1.ExecuteNonQuery();
                        MetroFramework.MetroMessageBox.Show(this, "\n\n\tResgister Complete  ");
                        metroTextBox1.Text = null;
                        metroTextBox2.Text = null;
                        metroTextBox3.Text = null;
                        metroTextBox4.Text = null;
                        metroTextBox5.Text = null;
                        metroTextBox6.Text = null;
                        metroTextBox7.Text = null;
                        metroTextBox8.Text = null;
                        metroTextBox9.Text = null;
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
