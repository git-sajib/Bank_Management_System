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
    public partial class ViewAccountHistory : Form
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=MUKTADIR-PC\SQLEXPRESS;Initial Catalog=MMBdb;Integrated Security=True");
        private Account Account;
        private List<Staff> Staffs;
        private List<TransactionHistory> transactionHistories;

        public ViewAccountHistory()
        {
            InitializeComponent();
            LoadStaff();
        }

        private void LoadStaff()
        {
            Staffs = new List<Staff>();

            string Query = $"SELECT * from Staff";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            DataSet history = new DataSet();
            sda.Fill(history, "Staffs");
            var rows = history.Tables[0].Rows;
            foreach (DataRow row in rows) {
                var items = row.ItemArray;
                Staffs.Add(new Staff
                {
                    Id = int.Parse(items[0].ToString()),
                    Name = items[1].ToString(),
                    Role = int.Parse(items[2].ToString()),
                    Address = items[3].ToString(),
                    Phone = items[4].ToString(),
                }) ;
            }
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {
            string Query = $"SELECT * from Account WHERE AccountNo = {TxtAccountNumber.Text}";
            SqlCommand cmd = new SqlCommand(Query, conn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
               Account = new Account
                {
                    Id = int.Parse(dr["Id"].ToString()),
                    Name = dr["Name"].ToString(),
                    Balance = int.Parse(dr["Balance"].ToString()),
                    AccountNo = dr["AccountNo"].ToString(),
                    Gender = dr["Gender"].ToString(),
                    Address = dr["Address"].ToString(),
                    Phone = dr["Phone"].ToString(),
               };

                LoadUserTransction(Account);
            }

        }

        private void LoadUserTransction(Account account)
        {
            transactionHistories = new List<TransactionHistory>();

            lblUserName.Text = $"Account Name : {account.Name}";
            lblUserAccountNumber.Text = $"Account Number : {account.AccountNo}";
            lblUserBalance.Text = $"Balance : {account.Balance}";


            string Query = $"SELECT * from TransactionHistory WHERE AccountId = {account.Id}";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            DataSet history = new DataSet();
            sda.Fill(history, "TransactionHistory");
            var rows = history.Tables[0].Rows;
            foreach (DataRow row in rows) {
                var items = row.ItemArray;
                var staff = int.Parse(items[2].ToString());
                transactionHistories.Add(new TransactionHistory
                {
                    Id = int.Parse(items[0].ToString()),
                    Account = account,
                    ApprovedBy = Staffs.FirstOrDefault(st => st.Id == staff),
                    Type = int.Parse(items[3].ToString()),
                    Amount = int.Parse(items[4].ToString()),
                    Date = DateTime.Parse(items[5].ToString()),
                });
            }
            var results = transactionHistories.Select(data => new {
                TransactionId = data.Id,
                AccountName = data.Account.Name,
                StaffId = data.ApprovedBy.Id,
                StaffName = data.ApprovedBy.Name,
                Amount = data.Amount,
                TransactionType = GetType(data.Type),
                Address = data.Account.Address,
                Date = data.Date,
            }).ToList();

            dataGridViewHistory.DataSource = results;
        }

        private String GetType(int type) {
            if (type == 0) {
                return "Cash In";
            }
            return "Cash Out";
        }
    }
}
