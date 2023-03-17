using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;



namespace FitnessTrackingSystem
{
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\gokul\OneDrive\Documents\GymDb.mdf;Integrated Security=True;Connect Timeout=30");

        private void FillName()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select MName from MemberTbl",Con );
            SqlDataReader rdr = cmd.ExecuteReader();
            //rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("MName", typeof(string));
            dt.Load(rdr);
            NameCb.ValueMember = "MName";
            NameCb.DataSource = dt;
            Con.Close();
        }
        private void filterByName()
        {
            Con.Open();
           // string query = "select * from PaymentTbl where PMember '"+SearchName.Text+"'";
            //SqlDataAdapter dd = new SqlDataAdapter(query, Con);
            //DataTable dt = new DataTable();
            //SqlCommandBuilder builder = new SqlCommandBuilder();
            //var ds = new DataSet();
            //dd.Fill(ds);
           // PaymentVB.DataSource = ds.Tables[0];
            Con.Close();

        }
        private void populate()
        {
            Con.Open();
            //string query = "select * from PaymentTbl";
          // SqlDataAdapter sda = new SqlDataAdapter(query, Con);
           // DataTable dt = new DataTable();
            //SqlCommandBuilder builder = new SqlCommandBuilder();
            //var ds = new DataSet();
            //sda.Fill(ds);
           //PaymentVB.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
            NameCb.Text = "";
            AmountTb.Text = "";
            Period.Text = "";


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Hide();

        }

        private void Payment_Load(object sender, EventArgs e)
        {
            FillName();
            populate();
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            if (NameCb.Text == "" || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Information");

            }
            else
            {
                string payperiod = Period.Value.Month.ToString() + Period.Value.Year.ToString();
                Con.Open();
                SqlDataAdapter sda = new SqlDataAdapter("select count(*) from PaymentTbl where PMember =' " + NameCb.SelectedValue.ToString() + "' and PMonth='" + payperiod + "'", Con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    MessageBox.Show("Already Paid For This Month");
                }
                else
                {
                    string query = "insert into PaymentTbl values('"+payperiod+"','"+NameCb.SelectedValue.ToString()+"',"+AmountTb.Text+ "')";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    //cmd.ExecuteNonQuery();
                    MessageBox.Show("Already Paid Successfully");
                }
                Con.Close();
                populate();

                    
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            populate();

        }

        private void NameCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
