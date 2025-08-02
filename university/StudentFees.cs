using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university
{
    public partial class StudentFees : Form
    {
        function fn = new function();
        string query;
        public StudentFees()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StudentFees_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy-MM-dd";

            // Ensure DataGridView is ready
            dataGridView1.AutoGenerateColumns = true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtMobile.Text != "")
            {
                if (Int64.TryParse(txtMobile.Text, out long mobile))
                {
                    query = "select name,email,roomNo from newStudent where mobile= " + mobile;
                    DataSet ds = fn.GetData(query);

                    if (ds.Tables[0].Rows.Count != 0)
                    {
                        txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                        txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                        txtRoomNo.Text = ds.Tables[0].Rows[0][2].ToString();
                        setDataGrid(mobile);
                    }
                    else
                    {
                        MessageBox.Show("No Record Found With This Mobile Number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid mobile number.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        public void setDataGrid(Int64 mobile)
        {
            query = "select * from fees where mobileNo = " + mobile;
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

      
       

        private void ClearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtRoomNo.Clear();
            txtFees.Clear();
            dataGridView1.DataSource = null;
        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            MessageBox.Show("DataGridView Error: " + e.Exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            e.ThrowException = false;
        }

        private void btnPay_Click_1(object sender, EventArgs e)
        {
            if (txtMobile.Text != "" && txtFees.Text != "")
            {
                if (Int64.TryParse(txtMobile.Text, out long mobileNo))
                {
                    query = "select * from fees where mobileNo = " + mobileNo + " and fmonth='" + dateTimePicker.Text + "'";
                    DataSet ds = fn.GetData(query);

                    if (ds.Tables[0].Rows.Count == 0)
                    {
                        // Proceed with inserting the payment record here
                        string name = txtName.Text;
                        string email = txtEmail.Text;
                        string room = txtRoomNo.Text;
                        string fmonth = dateTimePicker.Text;
                        int fees = int.Parse(txtFees.Text);

                        query = "insert into fees(mobileNo, fmonth, amount) values(" + mobileNo + ", '" + fmonth + "', " + fees + ")";
                        fn.GetData(query);

                        MessageBox.Show("Fees Paid Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        setDataGrid(mobileNo);
                        ClearAll();
                    }
                    else
                    {
                        MessageBox.Show("No Dues Of " + dateTimePicker.Text + " left.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid mobile number format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill all fields.", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
    }
}