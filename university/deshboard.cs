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
    public partial class deshboard : Form
    {
        function fn = new function();
        string query;
        public deshboard()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnManageRooms_Click(object sender, EventArgs e)
        {
            AddNewRoom anr = new AddNewRoom();
            anr.Show();
        }

        private void btnNewStudent_Click(object sender, EventArgs e)
        {
            NewStudent ns = new NewStudent();
            ns.Show();
        }

        private void btnUpdateDeletStudent_Click(object sender, EventArgs e)
        {
            UpdateDeletStudent uds=new UpdateDeletStudent();
            uds.Show();
        }

        private void btnStudentFees_Click(object sender, EventArgs e)
        {
            StudentFees sf = new StudentFees();
            sf.Show();
        }

        private void btnAllStudentLiving_Click(object sender, EventArgs e)
        {
            StudentLiving sl = new StudentLiving();
            sl.Show();
           
        }

        private void btnLeavedStudent_Click(object sender, EventArgs e)
        {
            LeavedStudent ls=new LeavedStudent();
            ls.Show();
        }

        private void btnNewEmployee_Click(object sender, EventArgs e)
        {
            NewEmployee ne = new NewEmployee();
                ne.Show();

        }

        private void btnUpdateDeleteEmployee_Click(object sender, EventArgs e)
        {
            UpdateDeleteEmplyee ude = new UpdateDeleteEmplyee();
            ude.Show();
        }

        private void btnEmployeePayment_Click(object sender, EventArgs e)
        {
            EmplyeePayment ep = new EmplyeePayment();
            ep.Show();
        }

        private void btnAllEmployeeWorking_Click(object sender, EventArgs e)
        {
            AllEmployeeWorking aew = new AllEmployeeWorking();
            aew.Show();
        }

        private void btnLeavedEmployee_Click(object sender, EventArgs e)
        {
            LeavedEmployee le = new LeavedEmployee();
            le.Show();
        }
    }
}
