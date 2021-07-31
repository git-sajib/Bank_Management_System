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
using System.Numerics;
using IAS2163VP.models;

namespace IAS2163VP
{
    public partial class New_Account_Form : Form
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=MUKTADIR-PC\SQLEXPRESS;Initial Catalog=MMBdb;Integrated Security=True");
        private List<Account> AllAccounts;
        private String RunningNumber = "0000001";
        private String accountN = "";

        public New_Account_Form()
        {
            InitializeComponent();
            DisplayAccounts();
            RunningNumber = GetRunningAccountNo();
            accountN = GetAccountNumber(RunningNumber);
            Console.WriteLine(accountN);
        }

        private void New_Account_Form_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {////Name,Phone,Address,Gender,Income,AccountNo,Balance
                DataGridViewRow dataRow = dataGridView2.Rows[e.RowIndex];
                textBoxName.Text = dataRow.Cells[1].Value.ToString();
                textBoxPhone.Text = dataRow.Cells[2].Value.ToString();
                textBoxAddress.Text = dataRow.Cells[3].Value.ToString();
                comboBoxGender.SelectedItem = dataRow.Cells[4].Value.ToString();
                textBoxIncome.Text = dataRow.Cells[5].Value.ToString();
            }
            
            if(textBoxName.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void LoadAccounts() { 
        
        }
    
        private void DisplayAccounts()
        {
            conn.Open();
            AllAccounts = new List<Account>();
            string Query = "select * from Account";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            DataSet accounts = new DataSet();
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            sda.Fill(accounts, "Accounts");

            var rows = accounts.Tables[0].Rows;
            foreach (DataRow row in rows) {
                var items = row.ItemArray; //rows[0].ItemArray
                //id,Name,Phone,Address,Gender,Income,AccountNo,Balance
                Account account = new Account {
                    Id = int.Parse(items[0].ToString()),
                    Name = items[1].ToString(),
                    Phone = items[2].ToString(),
                    Address = items[3].ToString(),
                    Gender = items[4].ToString(),
                    Income = int.Parse(items[5].ToString()),
                    AccountNo = items[6].ToString(),
                    Balance = int.Parse(items[7].ToString()),
                
                };
                AllAccounts.Add(account);
            }
            conn.Close();
        }
        private void Reset()
        {
            textBoxName.Text = "";
            textBoxPhone.Text = "";
            textBoxAddress.Text = "";
            comboBoxGender.SelectedIndex = -1;
            textBoxOcupation.Text = "";
            textBoxIncome.Text = "";
            comboBoxEducation.SelectedIndex = -1;
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {

            if (validate())
            {
                try 
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($"insert into Account(Name,Phone,Address,Gender,Income,AccountNo,Balance) values(@Name,@Phone,@Address,@Gender,@Income,@AccountNo,@Balance)", conn);
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBoxGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Income", textBoxIncome.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", accountN);
                    cmd.Parameters.AddWithValue("@Balance", 0);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created!");
                    conn.Close();
                    Reset();
                    DisplayAccounts();
                }
                catch(Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
        }



        private bool validate()
        {
            bool isValid = true;
            if (textBoxName.Text.Equals("")){
                showMessage("Name can't be empty");
               isValid = false;
            }
            if (textBoxPhone.Text.Equals(""))
            {
                showMessage("phone can't be empty");
                isValid = false;
            }
            if (textBoxAddress.Text.Equals(""))
            {
                showMessage("address can't be empty");
                isValid = false;
            } 
            if (comboBoxGender.SelectedIndex == -1)
            {
                showMessage("gender can't be empty");
                isValid = false;
            }
            if (textBoxOcupation.Text.Equals(""))
            {
                showMessage("ocupation can't be empty");
                isValid = false;
            }
            if (comboBoxEducation.SelectedIndex == -1)
            {
                showMessage("education can't be empty");
                isValid = false;
            }
            if (textBoxIncome.Text.Equals(""))
            {
                showMessage("income can't be empty");
                isValid = false;
            }

            return isValid;
        }

        private void showMessage(string message)
        {
            MessageBox.Show("Error: "+ message);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Account");
            }
            else 
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("delete from AccountTbl where AcNum=@AcKey", conn);
                    cmd.Parameters.AddWithValue("@AcKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Deleted!");
                    conn.Close();
                    Reset();
                    DisplayAccounts();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
            
            }

        private bool CreateNewAccount() {
            bool isSuccessful = false;



            return isSuccessful;
        }

        private String GetAccountNumber(String runningNumber) {
            var accountNumber = new System.Text.StringBuilder();
            String branchCode = "02";
            String accountType = "001";
            runningNumber = UpdateRunningAcc(runningNumber);
            accountNumber.Append(branchCode);
            accountNumber.Append(accountType);
            accountNumber.Append(runningNumber);
            var result = FirstSetp(accountNumber.ToString());
            var x = MultiplyEachNumber(result);
           
            //Console.WriteLine(Math.Pow(x,x));

            var y = BigInteger.Pow(int.Parse(x.ToString()), 7);
            var last = GetLastThree(y);
            Console.WriteLine(last);
            accountNumber.Append(last);

            Console.WriteLine("Account number : " + accountNumber.ToString());

            return accountNumber.ToString();
        }

        private String UpdateRunningAcc(String runing) {
            var accountNumber = new System.Text.StringBuilder();
            int num = int.Parse(runing) + 1;
            int length = 7 - (num.ToString().ToArray().Length);
            for (int i = 0; i < length; i++) {
                accountNumber.Append('0');
            }
            accountNumber.Append(num);
            return accountNumber.ToString();
        }

        private String GetLastThree(BigInteger numbers) { 
            var sb = new System.Text.StringBuilder();
            var arrary = numbers.ToString().ToArray();
            var length = arrary.Length - 1;
            for (int i = 2; i >= 0; i--) {
                sb.Append(arrary[length - (i)]);
            }
            return sb.ToString();
        }

        private String GetRunningAccountNo() {
            var last = AllAccounts.Last();
            var accountNumber = last.AccountNo.ToArray();
            //accountNumber; ^4..^11
            var running = new System.Text.StringBuilder();
            for(int i=5; i< 12; i++){
                running.Append(accountNumber[i]);
            }
            return running.ToString();
        }

        private double MultiplyEachNumber(String all) {
            double result = 0;
            foreach (var num in all.ToArray()) {
                result += Math.Pow(double.Parse(num.ToString()), int.Parse(num.ToString()));
            }
            return result;
        }

        private String FirstSetp(String all) {
            var sb = new System.Text.StringBuilder();
            int extraNumber = 3;
            try
            {
                foreach (var cha in all.ToArray())
                {
                    
                    sb.Append(int.Parse(cha.ToString())+extraNumber);
                   
                }
            }
            catch {
                return "";
            }
            Console.WriteLine("First step : "+sb.ToString());
            return sb.ToString();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Account");
            }
            else
            {
                try
                {
                    conn.Open();
                    //Name,Phone,Address,Gender,Income,AccountNo,Balance
                    SqlCommand cmd = new SqlCommand("update Account set Name=@AN,Phone=@AP,Address=@AA,Gender=@AG,Income=@AI where AccountNo=@AcKey", conn);
                    cmd.Parameters.AddWithValue("@AN", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@AP", textBoxPhone.Text);
                    cmd.Parameters.AddWithValue("@AA", textBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@AG", comboBoxGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AO", textBoxOcupation.Text);
                    cmd.Parameters.AddWithValue("@AE", comboBoxEducation.Text);
                    cmd.Parameters.AddWithValue("@AI", textBoxIncome.Text);
                    cmd.Parameters.AddWithValue("@AcKey", key);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Updated!");
                    conn.Close();
                    Reset();
                    DisplayAccounts();
                }
                catch (Exception E)
                {
                    MessageBox.Show(E.Message);
                }
            }
        }
    }
    }

