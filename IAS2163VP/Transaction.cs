using IAS2163VP.models;
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
        private readonly SqlConnection Con = new SqlConnection(@"Data Source=MUKTADIR-PC\SQLEXPRESS;Initial Catalog=MMBdb;Integrated Security=True");
        private int Balance;
        private Staff Staff;
        private Account UserAccount;
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

        private void CheckStaff_Click(object sender, EventArgs e)
        {
            if (TxtStaffId.Text == "")
            {
                MessageBox.Show("Enter Staff ID Number");
            } else
            { 
          
                Con.Open();
                string Query = $"SELECT * FROM Staff WHERE Id={int.Parse(TxtStaffId.Text)}";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                DataSet staffs = new DataSet();
                sda.Fill(staffs, "Staff");
                Console.WriteLine(staffs.Tables[0].Rows.Count);
                if (staffs.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow row in staffs.Tables[0].Rows) {
                        Staff = new Staff {
                            Id = int.Parse(row["Id"].ToString()),
                            Name = row["Name"].ToString(),
                            Role = int.Parse(row["Role"].ToString()),
                            Phone = row["Phone"].ToString(),
                            Address = row["Address"].ToString(),
                        };
                    }

                    if (Staff != null) {
                        lblStaffName.Text = $"Name : {Staff.Name}";
                        lblStaffRole.Text = $"Role : {RoleToTxt(Staff.Role)}";
                    }
                }
                else {
                    MessageBox.Show("No Staff Found");

                }
                Con.Close();

            }
        }

        private String RoleToTxt(int type) {
            switch (type) {
                case 0:
                    return "Manager";
                case 1:
                    return "Supervisor";
                case 2:
                    return "Teller";
                default:
                    return "Unknown";
            }
        
        }



        

        private void CheckBalance()
        {
            Con.Open();
            string Query = $"SELECT * FROM Account WHERE AccountNo = '{textBoxCheckBalance.Text}'";
            SqlDataAdapter sda = new SqlDataAdapter(Query,Con);

            DataSet accounts = new DataSet();
            sda.Fill(accounts,"Account");

            foreach (DataRow dr in accounts.Tables[0].Rows)
            {
                lblBalance.Text = "RM" + dr["Balance"].ToString();
                Balance = Convert.ToInt32(dr["Balance"].ToString());
            }

            Con.Close();
        }

        private void GetNewBalance()
        {
            Con.Open();
            string Query = $"select * from Account where AccountNo = '{textBoxCheckBalance.Text}'";
            SqlCommand cmd = new SqlCommand(Query, Con);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                //lblBalance.Text = "RM" + dr["AcBal"].ToString();
                Balance = Convert.ToInt32(dr["Balance"].ToString());
                UserAccount = new Account {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Balance = int.Parse(dr["Balance"].ToString()),
                };
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
                    SqlCommand cmd = new SqlCommand("UPDATE Account SET Balance = @AB WHERE AccountNo=@AcKey", Con);
                    cmd.Parameters.AddWithValue("@AB", newBal);
                    cmd.Parameters.AddWithValue("@AcKey", textBoxDeAccNo.Text);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    AddToTransactionHistory(0, int.Parse(textBoxDeAmount.Text));
                    MessageBox.Show("Money Deposit!");
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

                if (ValidateWithdraw()) {
                    GetNewBalance();
                    //int newBal = Balance + Convert.ToInt32(textBoxDeAmount.Text);
                    int minimum = (Balance - int.Parse(textBoxWiAmount.Text));

                    if (Balance < Convert.ToInt32(textBoxWiAmount.Text) || minimum <= 20)
                    {
                        MessageBox.Show("Insufficient Balance");
                    }
                    else
                    {
                        int newBal = Balance - Convert.ToInt32(textBoxWiAmount.Text);
                        try
                        {
                            Con.Open();
                            SqlCommand cmd = new SqlCommand("UPDATE Account SET Balance=@AB WHERE AccountNo=@AcKey", Con);
                            cmd.Parameters.AddWithValue("@AB", newBal);
                            cmd.Parameters.AddWithValue("@AcKey", textBoxWiAccNo.Text);
                            cmd.ExecuteNonQuery();
                           
                            Con.Close();
                            AddToTransactionHistory(1,int.Parse(textBoxWiAmount.Text));
                            MessageBox.Show("Money Withdrawn!");
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
                else {
                    MessageBox.Show("You are exceeding your minimun widthdraw");
                }
                }
            
        }

        private void lblStaffName_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateWithdraw() { 
            var check = false;
            if (Staff == null)
            {
                MessageBox.Show("Please check in with ID");
            }
            else {
                switch (Staff.Role)
                {
                    case 0:
                        if (int.Parse(textBoxWiAmount.Text) > 5000) {
                            check = true;
                        }
                        break;
                    case 1:
                        if (500 < int.Parse(textBoxWiAmount.Text) && int.Parse(textBoxWiAmount.Text) > 5000)
                        {
                            check = true;
                        }
                        break;
                    case 2:
                        if (int.Parse(textBoxWiAmount.Text) <= 500)
                        {
                            check = true;
                        }
                        break;
                    default:
                        return check;
                }
            }
            return check;
        
        }

        private void AddToTransactionHistory(int type,int amount) {
            try {
                Con.Open();
                SqlCommand cmd = new SqlCommand($"INSERT into TransactionHistory(AccountId,ApprovedBy,Type,Amount,DateTime) values(@AccountId,@ApprovedBy,@Type,@Amount,@DateTime)", Con);
                cmd.Parameters.AddWithValue("@AccountId", UserAccount.Id);
                cmd.Parameters.AddWithValue("@ApprovedBy", Staff.Id);
                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@Amount", amount);
                cmd.Parameters.AddWithValue("@DateTime", DateTime.Now);
                cmd.ExecuteNonQuery();
                Con.Close();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
    }
}
