using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Analysis19
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        //ADMIN LOGIN
        private void metroTile1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new admin_login());
            panel2.BackColor = Color.Teal;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;


        }
        // User Login button
        private void metroTile2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new USER_LOGIN());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.Teal;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
        }
        // USER REGISTER BUTTON
        private void metroTile3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new User_Register());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.Teal;
            panel4.BackColor = Color.Maroon;
        }
        // EXIT BUTTON
        private void metroTile4_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Teal;
            Application.Exit();
        }
    }
}
