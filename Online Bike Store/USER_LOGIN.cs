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
    public partial class USER_LOGIN : UserControl
    {
         private string user__name ;

        public string u
        {
            get { return user__name; }
            set { user__name = value; }
        }
        public USER_LOGIN()
        {
            InitializeComponent();
            
        }
        public string user_name
        {
            get
            {
                return metroTextBox1.Text;
            }
            set
            {
                string US = metroTextBox1.Text;

            }
        }
        // LOGIN BUTTON
        public void metroButton1_Click(object sender, EventArgs e)
        {
            string mycon = "Data Source=.;Initial Catalog=Analysis19;Integrated Security=True";
            SqlConnection con = new SqlConnection(mycon);
            con.Open();
            SqlCommand cod = new SqlCommand("Select * from [USER] where username='" + this.metroTextBox1.Text + "' and password ='" + this.metroTextBox2.Text + "';", con);
            SqlDataReader myreader;
            myreader = cod.ExecuteReader();
            int count = 0;
            while (myreader.Read())
            {
                count = count + 1;
            }
            if (count == 1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tWelcome \t" + this.metroTextBox1.Text);
                string US = metroTextBox1.Text;
                


                USER f = new USER(US);
                ((Form)this.TopLevelControl).Hide();
                f.ShowDialog();
                ((Form)this.TopLevelControl).Close();
            }
            else if (count > 1)
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tDuplicate Username and Password ... Access Denied");
            }
            else
            {
                MetroFramework.MetroMessageBox.Show(this, "\n\n\tUsername and Password Is not Correct ... Try Again");
            }

                     
        }
    }
}
