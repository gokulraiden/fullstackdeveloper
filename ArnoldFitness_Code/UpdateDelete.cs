using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitnessTrackingSystem
{
    public partial class UpdateDelete : Form
    {
        public UpdateDelete()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gokul\OneDrive\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from MemberTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void UpdateDelete_Load(object sender, EventArgs e)
        {
            populate();

        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            key = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value.ToString());
            NameTb.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            PhoneTb.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            GenderCb.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            AgeTb.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            AmountTb.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            TimingCB.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            NameTb.Text = "";
            AgeTb.Text = "";
            PhoneTb.Text = "";
            TimingCB.Text = "";
            AmountTb.Text = "";
            GenderCb.Text = "";

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (key == 0 || NameTb.Text == "" || PhoneTb.Text == "" || AgeTb.Text == "" || AmountTb.Text == "" || GenderCb.Text == "" || TimingCB.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "update MemberTbl set MName='" + NameTb.Text + "',MPhone='" + PhoneTb.Text + "',MGen='" + GenderCb.Text + "',MAge=" + AgeTb.Text + ", MAmount=" + AmountTb.Text + ",MTiming='" + TimingCB.Text + "'where Mid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Updated Successfully");
                    Con.Close();
                    populate();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key==0)
            {
                MessageBox.Show("Select The Member to be Deleted");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete from MemberTbl where Mid=" + key + ";";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Member Deleted Successfully");
                    Con.Close();
                    populate();


                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);

                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
