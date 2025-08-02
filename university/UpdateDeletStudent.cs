using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace university
{
    public partial class UpdateDeletStudent : Form
    {
        function fn = new function();
        string query;
        public UpdateDeletStudent()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateDeletStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 150);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }
        private void ClearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtCollege.Clear();
            txtID.Clear();
            txtRoom.Clear();
            comboBoxLiving.SelectedIndex = -1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM newStudent WHERE mobile = " + txtMobile.Text;
            DataSet ds = fn.GetData(query);


            if (ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][6].ToString();
                txtCollege.Text = ds.Tables[0].Rows[0][7].ToString();
                txtID.Text = ds.Tables[0].Rows[0][8].ToString();
                txtRoom.Text = ds.Tables[0].Rows[0][9].ToString();
                comboBoxLiving.Text = ds.Tables[0].Rows[0][10].ToString();
            }
            else
            {
                ClearAll();
                MessageBox.Show("NO Records With THis Mobile Number", "Information!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String name = txtName.Text;
            String fname = txtFather.Text;
            String mname = txtMother.Text;
            String email = txtEmail.Text;
            String paddress = txtAddress.Text;
            String college = txtCollege.Text;
            String idproof = txtID.Text;
            Int64 roomNo = Int64.Parse(txtRoom.Text);
            String livingStatus = comboBoxLiving.Text;

            query =
      "UPDATE newStudent SET " + "name = '" + name + "', " + "fname = '" + fname + "', " + "mname = '" + mname + "', " + "email = '" + email + "', " + "paddress = '" + paddress + "', " + "college = '" + college + "', " + "idproof = '" + idproof + "', " +
      "roomNo = '" + roomNo + "', " + "living = '" + livingStatus + "' " + "WHERE mobile = '" + mobile + "'; " + "UPDATE rooms SET " + "Booked = '" + livingStatus + "' " + "WHERE roomNo = " + roomNo + ";";
            fn.SetData(query, "Data Updation Successful");



        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                query = "DELETE FROM newStudent WHERE mobile = '" + txtMobile.Text + "'";
                fn.SetData(query, "Student Record Deleated.");
                ClearAll();
            }
        }
    }
}
