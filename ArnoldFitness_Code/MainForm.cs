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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddMember addmember = new AddMember();
            addmember.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateDelete Update = new UpdateDelete();
            Update.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Payment pay = new Payment();
            pay.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         


        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
