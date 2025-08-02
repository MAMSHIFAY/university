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
    public partial class AddNewRoom : Form
    {
        function fn = new function();
        string query;
        private object lableRoom;

        public AddNewRoom()
        {
            InitializeComponent();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNewRoom_Load(object sender, EventArgs e)
        {
            this.Location = new Point(450, 250);
            labelRoom.Visible = false;
            labelsetText.Visible = false;

            query = "select * from rooms";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];


        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            query = "Select * from rooms where roomno=" + txtRoomNo1.Text + "";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                string status;
                if (checkBox1.Checked)
                {
                    status = "YES";
                }
                else
                {
                    status = "No";

                }
                labelRoom.Visible = false;
                query = "insert into rooms(roomNo,roomStatus) values(" + txtRoomNo1.Text + ",'" + status + "')";
                fn.SetData(query, "Room Added Successfully");
                AddNewRoom_Load(this, null);
            }
            else
            {
                labelRoom.Text = "All ROOM READY";
                labelsetText.Visible = true;


            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            query = "select * from rooms where roomno=" + txtRoomNo2.Text + "";
            DataSet ds = fn.GetData(query);
            if (ds.Tables[0].Rows.Count == 0)
            {
                labelRoom.Text = "Room Not Found";
                labelRoom.Visible = true;
                checkBox2.Checked = false;

            }
            else
            {
                labelRoom.Text = "Room Found";
                labelRoom.Visible = true;
                if (ds.Tables[0].Rows[0][1].ToString() == "Yes")
                {
                    checkBox2.Checked = true;
                }
                else
                {
                    checkBox2.Checked= false;
                }
            }

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string status;
            if (checkBox2.Checked)
            {
                status = "Yes";
            }
            else
            {
                status = "No";
            }
            query = "update rooms set roomStatus='" + status + "' where roomNO="+txtRoomNo2.Text+"";
            fn.SetData(query, "Detail Updated");
            AddNewRoom_Load(this, null); 
        }

        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (labelRoom.Text == "Room Found")
            {
                if (string.IsNullOrWhiteSpace(txtRoomNo2.Text))
                {
                    MessageBox.Show("Please enter a valid Room Number.");
                    return;
                }

                // Check if the room is used by any student
                query = "SELECT COUNT(*) FROM newStudent WHERE roomNo = '" + txtRoomNo2.Text + "'";
                DataSet ds = fn.GetData(query);
                int count = Convert.ToInt32(ds.Tables[0].Rows[0][0]);

                if (count > 0)
                {
                    MessageBox.Show("Cannot delete this room. It is currently assigned to one or more students.", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    query = "DELETE FROM rooms WHERE roomNo = '" + txtRoomNo2.Text + "'";
                    fn.SetData(query, "Room Details Deleted");
                    AddNewRoom_Load(this, null);
                }
            }
            else
            {
                MessageBox.Show("Trying to delete a room which doesn't exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void txtRoomNo1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}