﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace IAS2163VP
{
    public partial class New_Account_Form : Form
    {
        private readonly SqlConnection conn = new SqlConnection(@"Data Source=MUKTADIR-PC\SQLEXPRESS;Initial Catalog=MMBdb;Integrated Security=True");

        public New_Account_Form()
        {
            InitializeComponent();
            DisplayAccounts();
        }

        private void New_Account_Form_Load(object sender, EventArgs e)
        {

        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dataRow = dataGridView2.Rows[e.RowIndex];
                textBoxName.Text = dataRow.Cells[1].Value.ToString();
                textBoxPhone.Text = dataRow.Cells[2].Value.ToString();
                textBoxAddress.Text = dataRow.Cells[3].Value.ToString();
                comboBoxGender.SelectedItem = dataRow.Cells[4].Value.ToString();
                textBoxOcupation.Text = dataRow.Cells[5].Value.ToString();
                comboBoxEducation.SelectedItem = dataRow.Cells[6].Value.ToString();
                textBoxIncome.Text = dataRow.Cells[7].Value.ToString();
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

    
        private void DisplayAccounts()
        {
            conn.Open();
            string Query = "select * from AccountTbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, conn);
            SqlCommandBuilder Builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
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
                    SqlCommand cmd = new SqlCommand("insert into Account(Name,Phone,Address,Gender,Occupation,Income,AccountNo,Balance) values(@Name,@Phone,@Address,@Gender,@Occupation,@Income,@AccountNo,@Balance)", conn);
                    cmd.Parameters.AddWithValue("@Name", textBoxName.Text);
                    cmd.Parameters.AddWithValue("@Phone", textBoxPhone.Text);
                    cmd.Parameters.AddWithValue("@Address", textBoxAddress.Text);
                    cmd.Parameters.AddWithValue("@Gender", comboBoxGender.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@Occupation", textBoxOcupation.Text);
                    cmd.Parameters.AddWithValue("@Income", comboBoxEducation.Text);
                    cmd.Parameters.AddWithValue("@AccountNo", textBoxIncome.Text);
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
                    SqlCommand cmd = new SqlCommand("update AccountTbl set AcName=@AN,AcPhone=@AP,AcAddress=@AA,AcGen=@AG,AcOccup=@AO,AcEduc=@AE,AcInc=@AI where AcNum=@AcKey", conn);
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

