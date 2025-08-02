using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university
{
    public partial class NewEmployee : Form
    {
        function fn = new function();
        string query;

        public NewEmployee()
        {
            InitializeComponent();
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Check if any field is empty
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtMobile.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtFather.Text) ||
                string.IsNullOrWhiteSpace(txtMother.Text) ||
                string.IsNullOrWhiteSpace(txtUniqueID.Text) ||
                txtDesignation.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all the fields", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validate mobile number
            if (!Int64.TryParse(txtMobile.Text, out Int64 mobile) || txtMobile.Text.Length != 10)
            {
                MessageBox.Show("Enter a valid 10-digit mobile number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate email
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Enter a valid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate name fields
            if (!IsAllLetters(txtName.Text) ||
                !IsAllLetters(txtFather.Text) ||
                !IsAllLetters(txtMother.Text))
            {
                MessageBox.Show("Name, Father, and Mother fields should contain only letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Assign all values
            string name = txtName.Text;
            string fname = txtFather.Text;
            string mname = txtMother.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string id = txtUniqueID.Text;
            string designation = txtDesignation.Text;

            // Prepare SQL query
            query = "INSERT INTO newEmplovee (emobile, ename, efname, emname, eemail, epaddress, eidproof, edesignation) " +
                    $"VALUES ('{mobile}', '{name}', '{fname}', '{mname}', '{email}', '{address}', '{id}', '{designation}')";

            fn.SetData(query, "New Employee Added Successfully");
            ClearAll();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll()
        {
            txtName.Clear();
            txtEmail.Clear();
            txtMobile.Clear();
            txtAddress.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtUniqueID.Clear();
            txtDesignation.SelectedIndex = -1;
        }

        // Method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mail = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // Method to validate that a string contains only letters and spaces
        private bool IsAllLetters(string input)
        {
            return input.All(c => char.IsLetter(c) || c == ' ');
        }
    }
}
