using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTrackingSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogTb.Text = "";
            PassTb.Text = "";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LogTb.Text == "" || PassTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else if (LogTb.Text == "gokul" && PassTb.Text == "gokul")
            {
                MainForm mainform = new MainForm();
                mainform.Show();
                this.Hide();


            }
            else
            {
                MessageBox.Show("Wrong Id or Password");
            }
        }
    }
}
