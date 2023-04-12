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
    public partial class USER : MetroFramework.Forms.MetroForm
    {
        private USER_LOGIN U;
        
        public USER(string y)
        {
            
            InitializeComponent();
            label1.Text = y;
            
            
        }
        
        private void USER_Load(object sender, EventArgs e)
        {
           
        
        }
        // EXIT EVENT
        private void USER_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        // EXIT BUTTON
        private void metroTile4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // BIKES  ( RATES ) BUTTON
        private void metroTile1_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new USER_BIKE(TSU));
            panel2.BackColor = Color.Teal;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;



        }
        // SIGN OUT BUTTON
        private void metroTile7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            ((Form)this.TopLevelControl).Hide();
            f.ShowDialog();
            ((Form)this.TopLevelControl).Close();

        }
        // SPARE PART BUTTON
        private void metroTile2_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new user_spare(TSU));
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.Teal;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;

        }
        // BUY BIKE BUTTON
        private void metroTile3_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;

            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new Buy_Bike(TSU));
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.Teal;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
        }

        private void metroTile5_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;

            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new RENT_BIKE_USER(TSU));
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.Teal;
            panel6.BackColor = Color.DimGray;


        }

        private void metroTile6_Click(object sender, EventArgs e)
        {
            string TSU = label1.Text;

            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new RETURNBIKE(TSU));
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.Teal;
        }
    }
}
