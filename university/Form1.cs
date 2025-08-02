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

namespace university
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-AQ0VOT0;Initial Catalog=log;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string query = "SELECT COUNT(*) FROM loginpage WHERE username=@username AND password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", txtuser.Text);
            cmd.Parameters.AddWithValue("@password", txtpass.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                //MessageBox.Show("Login Successful", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Open Dashboard Form
                deshboard ds = new deshboard();
                ds.Show();

                // Hide current login form
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Failed", "info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtpass_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = guna2CheckBox1.Checked ? '\0' : '*';
        }
    }
}
