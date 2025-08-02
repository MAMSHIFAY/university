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
    public partial class NewStudent : Form
    {
        function fn = new function();
        string query;

        public NewStudent()
        {
            InitializeComponent();
        }

        private void NewStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 270);
            query = "select roomNO from rooms where roomStatus='Yes' and Booked='No'";
            DataSet ds = fn.GetData(query);

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                Int64 rooms = Int64.Parse(ds.Tables[0].Rows[i][0].ToString());
                comboRoomNo.Items.Add(rooms);
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        public void ClearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtCollege.Clear();
            txtID.Clear();
            comboRoomNo.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtMobile.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtFather.Text) ||
                string.IsNullOrWhiteSpace(txtMother.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtCollege.Text) ||
                string.IsNullOrWhiteSpace(txtID.Text) ||
                comboRoomNo.SelectedIndex == -1)
            {
                MessageBox.Show("Fill all fields", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Int64.TryParse(txtMobile.Text, out Int64 mobile) || txtMobile.Text.Length != 10)
            {
                MessageBox.Show("Enter a valid 10-digit mobile number", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            if (!IsAllLetters(txtName.Text) || !IsAllLetters(txtFather.Text) || !IsAllLetters(txtMother.Text))
            {
                MessageBox.Show("Name, Father, and Mother fields should contain only letters", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            if (!IsValidEmail(txtEmail.Text))
            {
                MessageBox.Show("Enter a valid email address", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          
            string name = txtName.Text;
            string fname = txtFather.Text;
            string mname = txtMother.Text;
            string email = txtEmail.Text;
            string paddress = txtAddress.Text;
            string college = txtCollege.Text;
            string idproof = txtID.Text;
            Int64 roomNo = Int64.Parse(comboRoomNo.Text);

          
            query = "INSERT INTO newStudent (mobile, name, fname, mname, email, paddress, college, idproof, roomNo) " +
                    "VALUES (" + mobile + ", '" + name + "', '" + fname + "', '" + mname + "', '" + email + "', '" + paddress + "', '" + college + "', '" + idproof + "', " + roomNo + "); " +
                    "UPDATE rooms SET Booked = 'Yes' WHERE roomNO = " + roomNo + ";";

            fn.SetData(query, "Student registration successful");
            ClearAll();
        }

       
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

      
        private bool IsAllLetters(string input)
        {
            return input.All(c => char.IsLetter(c) || c == ' ');
        }
    }
}
