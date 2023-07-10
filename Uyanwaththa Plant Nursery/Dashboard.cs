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

namespace Uyanwaththa_Plant_Nursery
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
            Total();
            Total2();
            Total3();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ASUS\source\repos\Uyanwaththa Plant Nursery\UyanwaththaDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Total()
        {
            
            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) from Stocks",Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            total.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }

        private void Total2()
        {

            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) from Stocks where Item_Name=' " + 002 + " ' ", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            total2.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void Total3()
        {

            Con.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select Count(*) from Stocks where Item_Code=' " + 003 + " ' ", Con);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            total3.Text = dt.Rows[0][0].ToString();
            Con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Dashboard obj = new Dashboard();
            obj.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Employee obj = new Employee();
            obj.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stocks obj = new Stocks();
            obj.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sales obj = new Sales();
            obj.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Mailbox obj = new Mailbox();
            obj.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            logout obj = new logout();
            obj.Show();
            this.Hide();
        }
       
       
    }
}
