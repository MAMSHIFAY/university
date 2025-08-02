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
    public partial class UpdateDeleteEmplyee : Form
    {    function fn = new function();
        string query;
        public UpdateDeleteEmplyee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_Click(object sender, EventArgs e)
        {
            query= "select * from newEmplovee where emobile='" + txtMobile.Text + "'";
            DataSet ds = fn.GetData(query);

           if(ds.Tables[0].Rows.Count != 0)
            {
                txtName.Text = ds.Tables[0].Rows[0][2].ToString();
                txtFather.Text = ds.Tables[0].Rows[0][3].ToString();
                txtMother.Text = ds.Tables[0].Rows[0][4].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0][5].ToString();
                txtAddress.Text = ds.Tables[0].Rows[0][6].ToString();
                txtUnique.Text = ds.Tables[0].Rows[0][7].ToString();
                txtDesignation.Text = ds.Tables[0].Rows[0][8].ToString();
                txtWork.Text = ds.Tables[0].Rows[0][9].ToString();
               
            }
            else
            {
                MessageBox.Show("No Record Found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                clearAll();
            }
        }

        private void UpdateDeleteEmplyee_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Int64 mobile = Int64.Parse(txtMobile.Text);
            String name =txtName.Text;
            String fname = txtFather.Text;
            String mname =txtMother.Text;
            String email =txtEmail.Text;
            String paddress =txtAddress.Text;
            String id =txtUnique.Text;
            String designation = txtDesignation.Text;
            String working=txtWork.Text;


            query =
  "UPDATE newEmplovee SET " + "ename = '" + name + "', " + "efname = '" + fname + "', " + "emname = '" + mname + "', " + "eemail = '" + email + "', " + "epaddress = '" + paddress + "', " + "eidproof = '" + id + "', " + "edesignation = '" + designation + "', " +
  "working = '" + working + "' WHERE emobile = '" + mobile + "';";
            fn.SetData(query, "Data Updation Successful");
        }

        private void txtDelete_Click(object sender, EventArgs e)
        {
          if(MessageBox.Show("Are You Sure?","Confirmation",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)== DialogResult.Yes)
            {
                query = "delete from newEmplovee where emobile='" + txtMobile.Text + "'";
                fn.SetData(query, "Data Deleted Successfully");
                clearAll();

            }
        }
        public void clearAll()
        {
            txtMobile.Clear();
            txtName.Clear();
            txtFather.Clear();
            txtMother.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtUnique.Clear();
            txtDesignation.SelectedIndex = -1;
            txtWork.SelectedIndex = -1;
        }

        private void txtClear_Click(object sender, EventArgs e)
        {
            clearAll();
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
