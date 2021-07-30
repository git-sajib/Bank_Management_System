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

namespace IAS2163VP
{
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        private void Transaction_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        SqlConnection Con = new SqlConnection(@"Data Source=SAMIUL\SQLEXPRESS;Initial Catalog=MMBdb;Integrated Security=True");
        int Balance;
        private void CheckBalance()
        {
            Con.Open();
            string Query = "select * from AccountTbl where AcNum=" + textBoxCheckBalance.Text + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach(DataRow dr in dt.Rows)
            {
                lblBalance.Text = "RM"+dr["AcBal"].ToString();
                Balance = Convert.ToInt32(dr["AcBal"].ToString());
            }
            Con.Close();
        }

        private void GetNewBalance()
        {
            Con.Open();
            string Query = "select * from AccountTbl where AcNum=" + textBoxCheckBalance.Text + "";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                //lblBalance.Text = "RM" + dr["AcBal"].ToString();
                Balance = Convert.ToInt32(dr["AcBal"].ToString());
            }
            Con.Close();
        }

        private void btnCheckBal_Click(object sender, EventArgs e)
        {
            if (textBoxCheckBalance.Text == "")
            {
                MessageBox.Show("Enter Account Number");
            } 
            else
            {
                CheckBalance();
                if(lblBalance.Text == "Your Balance")
                {
                    MessageBox.Show("Account Not Found");
                    textBoxCheckBalance.Text = "";
                }
            }
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (textBoxDeAccNo.Text == "" || textBoxDeAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                GetNewBalance();
                int newBal = Balance + Convert.ToInt32(textBoxDeAmount.Text);
                try
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update AccountTbl set AcBal=@AB where AcNum=@AcKey", Con);
                    cmd.Parameters.AddWithValue("@AB", newBal);
                    cmd.Parameters.AddWithValue("@AcKey", textBoxDeAccNo.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Money Deposit!");
                    Con.Close();
                    textBoxDeAmount.Text = "";
                    textBoxDeAccNo.Text = "";
                    lblBalance.Text = "Your Balance";
                    //DisplayAccounts();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
        }

        private void btnWithdraw_Click(object sender, EventArgs e)
        {
            if (textBoxWiAccNo.Text == "" || textBoxWiAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                
                GetNewBalance();
                //int newBal = Balance + Convert.ToInt32(textBoxDeAmount.Text);
                if(Balance < Convert.ToInt32(textBoxWiAmount.Text))
                {
                    MessageBox.Show("Insufficient Balance");
                }
                else
                {
                    int newBal = Balance - Convert.ToInt32(textBoxWiAmount.Text);
                    try
                    {
                        Con.Open();
                        SqlCommand cmd = new SqlCommand("update AccountTbl set AcBal=@AB where AcNum=@AcKey", Con);
                        cmd.Parameters.AddWithValue("@AB", newBal);
                        cmd.Parameters.AddWithValue("@AcKey", textBoxWiAccNo.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Money Withdrawn!");
                        Con.Close();
                        textBoxWiAmount.Text = "";
                        textBoxWiAccNo.Text = "";
                        lblBalance.Text = "Your Balance";
                    }
                    catch (Exception E)
                    {
                        MessageBox.Show(E.Message);
                    }
                }
            }
        }
    }
}
