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
    public partial class admin_form : MetroFramework.Forms.MetroForm
    {
        public admin_form()
        {
            InitializeComponent();
        }

        private void admin_form_Load(object sender, EventArgs e)
        {

        }
        // EXIT BUTTON
        private void metroTile4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        // USERS BUTTON
        private void metroTile1_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new admin_users());
            panel2.BackColor = Color.Teal;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
        }
        // NEW BIKE BUTTON
        private void metroTile2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new new_bike());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.Teal;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
        }
        // BIKES 
        private void metroTile3_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new BIKES());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.Teal;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
        }
        // TODAY SELLS
        private void metroTile5_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new sells());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.Teal;
            panel6.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel9.BackColor = Color.DimGray;

        }
        // SIGN OUT BUTTON
        private void metroTile7_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            ((Form)this.TopLevelControl).Hide();
            f.ShowDialog();
            ((Form)this.TopLevelControl).Close();
        }
        // ADD NEW SPARE PART
        private void metroTile6_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new new_spare());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.Teal;
            panel8.BackColor = Color.DimGray;
            panel9.BackColor = Color.DimGray;

        }
        // spare part
        private void metroTile8_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new SPARE_PART());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel8.BackColor = Color.Teal;
            panel9.BackColor = Color.DimGray;
        }

        private void metroTile9_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in metroPanel1.Controls)
            {
                ctrl.Dispose();
            }
            metroPanel1.Controls.Add(new show_rents());
            panel2.BackColor = Color.DimGray;
            panel1.BackColor = Color.DimGray;
            panel3.BackColor = Color.DimGray;
            panel4.BackColor = Color.Maroon;
            panel5.BackColor = Color.DimGray;
            panel6.BackColor = Color.DimGray;
            panel8.BackColor = Color.DimGray;
            panel9.BackColor = Color.Teal;
        }
    }
}
