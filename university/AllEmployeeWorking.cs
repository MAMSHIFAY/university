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
    public partial class AllEmployeeWorking : Form
    {    function fn = new function();
        string query;
        public AllEmployeeWorking()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AllEmployeeWorking_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            query = "select * from newEmplovee where working ='Yes'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
    }
}
