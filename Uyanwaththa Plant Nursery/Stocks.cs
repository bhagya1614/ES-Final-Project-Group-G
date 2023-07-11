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
    public partial class Stocks : Form
    {
        public Stocks()
        {
            InitializeComponent();
            DisplayStocks();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\ASUS\source\repos\Uyanwaththa Plant Nursery\UyanwaththaDB.mdf"";Integrated Security=True;Connect Timeout=30");
        private void DisplayStocks()
        {
            Con.Open();
            String Query = "Select * from Stocks";
            SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            GV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void Clear()
        {
            ic1.SelectedIndex = 0;
            In1.SelectedIndex = 0;
            sn.Text = "";
            qty.Text = "";
            ic2.Text = "";
            in2.Text = "";
            sn2.Text = "";
            qty2.Text = "";
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

        private void button3_Click(object sender, EventArgs e)
        {
            Stocks obj = new Stocks();
            obj.Show();
            this.Hide();
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


        
        private void add1_Click(object sender, EventArgs e)
        {
            if (ic1.SelectedIndex == -1 || In1.SelectedIndex == -1 || sn.Text == "" || qty.Text == "" )
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Stocks (Number,Item_Code,Item_Name,Quantity) values(@N,@IC,@IN,@Q)", Con);
                    cmd.Parameters.AddWithValue("@IC", ic1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@IN", In1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Q", qty.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recorded");
                    Con.Close();
                    DisplayStocks();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void add2_Click(object sender, EventArgs e)
        {
            if (ic2.Text == "" || in2.Text == "" || sn2.Text == "" || qty2.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Stocks (Number,Item_Code,Item_Name,Quantity) values(@N,@IC,@IN,@Q)", Con);
                    cmd.Parameters.AddWithValue("@IC", ic2.Text);
                    cmd.Parameters.AddWithValue("@IN", in2.Text);
                    cmd.Parameters.AddWithValue("@Q", qty2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Recorded");
                    Con.Close();
                    DisplayStocks();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        int key = 0;
        private void GV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ic1.Text = GV.SelectedRows[0].Cells[1].Value.ToString();
            In1.Text = GV.SelectedRows[0].Cells[2].Value.ToString();
            qty2.Text = GV.SelectedRows[0].Cells[3].Value.ToString();
            if (ic1.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(GV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
       
        private void upd_Click(object sender, EventArgs e)
        {
            if (ic1.SelectedIndex == -1 || In1.SelectedIndex == -1 || sn.Text == "" || qty.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("Update Stocks set Item_Cod =@IC,Item_Name=@IN,Quantity=@Q where PrID=@PKey", Con);
                    cmd.Parameters.AddWithValue("@IC", ic1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@IN", In1.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Q", qty.Text);
                    cmd.Parameters.AddWithValue("@Pkey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Edited !");
                    Con.Close();
                    DisplayStocks();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select Stock");
            }
            else
            {
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from Stocks where EmpNum = @EmpKey", Con);
                    cmd.Parameters.AddWithValue("@EmpKey" , key);


                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Deleted !");
                    Con.Close();
                    DisplayStocks();
                    Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
