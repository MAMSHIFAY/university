using System;
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
    public partial class EmplyeePayment : Form
    {    function fn = new function();
        string query;
        public EmplyeePayment()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmplyeePayment_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            DateTimePicker1.Format = DateTimePickerFormat.Custom;
            DateTimePicker1.CustomFormat = "MMMM yyyy";
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            if(txtMobile.Text != "")
            {
                query = "Select ename,eemail,edesignation from newEmplovee where emobile="+txtMobile.Text+"";
                DataSet ds = fn.GetData(query);

                if(ds.Tables[0].Rows.Count != 0)
                {
                    txtName.Text = ds.Tables[0].Rows[0][0].ToString();
                    txtEmail.Text = ds.Tables[0].Rows[0][1].ToString();
                    txtDesignation.Text = ds.Tables[0].Rows[0][2].ToString();

                    setDataGrid(Int64.Parse(txtMobile.Text));
                }
                else
                {
                    MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtName.Clear();
                    txtEmail.Clear();
                    txtDesignation.SelectedIndex = -1;

                }
            }
            else
            {
                MessageBox.Show("Please Enter Mobile Number", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void setDataGrid(Int64 mobile)
        {
            query = "select * from employeeSalary where mobileNo=" + txtMobile.Text + "";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnPaySalary_Click(object sender, EventArgs e)
        {
            if(txtMobile.Text != "" && txtPayment.Text != "")
            {
              query= "select * from employeeSalary where mobileNo=" + txtMobile.Text + " and fmonth='" + DateTimePicker1.Text + "'";
                DataSet ds = fn.GetData(query);
                if (ds.Tables[0].Rows.Count == 0)
                {
                    Int64 mobile = Int64.Parse(txtMobile.Text);
                    string month = DateTimePicker1.Text;
                    Int64 payment = Int64.Parse(txtPayment.Text);

                    query = "insert into employeeSalary values(" + mobile + ",'" + month + "'," + payment + ")";
                    fn.SetData(query, "Salary Paid Successfully"+ DateTimePicker1.Text+"paid");
                    setDataGrid(mobile);
                    clearAll();

                }
                else
                {
                    MessageBox.Show("Salary Already Paid", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please Enter Mobile Number and Salary", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }
        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtEmail.Clear();
            txtDesignation.SelectedIndex = -1;
            txtPayment.Clear();
            dataGridView1.DataSource = null;
        }
    }
}
