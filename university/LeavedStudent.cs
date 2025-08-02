using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university
{
    public partial class LeavedStudent : Form
    {
        function fn = new function();
        string query;

        
        PrintDocument printDocument = new PrintDocument();
        Bitmap bitmap;

        public LeavedStudent()
        {
            InitializeComponent();

           
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void LeavedStudent_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            query = "select * from newStudent where living='No'";
            DataSet ds = fn.GetData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnprint_Click(object sender, EventArgs e)
        {
            try
            {
             
                int height = guna2DataGridView1.Height;

                guna2DataGridView1.Height = guna2DataGridView1.RowCount * guna2DataGridView1.RowTemplate.Height * 2;

              
                bitmap = new Bitmap(guna2DataGridView1.Width, guna2DataGridView1.Height);
                guna2DataGridView1.DrawToBitmap(bitmap, new Rectangle(0, 0, guna2DataGridView1.Width, guna2DataGridView1.Height));

             
                guna2DataGridView1.Height = height;

               
                printDocument.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Print Error: " + ex.Message);
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0);
        }
    }
}
