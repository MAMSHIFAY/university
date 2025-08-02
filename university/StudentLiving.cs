using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace university
{
    public partial class StudentLiving : Form
    {
        function fn = new function();
        string query;

        PrintDocument printDocument = new PrintDocument();
        PrintPreviewDialog previewDialog = new PrintPreviewDialog();

        // Variables for printing
        int currentRow = 0;
        int totalWidth = 0;
        List<int> columnLefts = new List<int>();
        List<int> columnWidths = new List<int>();
        int headerHeight = 0;
        bool firstPage = true;

        public StudentLiving()
        {
            InitializeComponent();
            printDocument.PrintPage += new PrintPageEventHandler(printDocument_PrintPage);
        }

        private void StudentLiving_Load(object sender, EventArgs e)
        {
            this.Location = new Point(350, 170);
            query = "select * from newStudent where living='Yes'";
            DataSet ds = fn.GetData(query);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           

            
            PrintDialog printDlg = new PrintDialog();
            printDlg.Document = printDocument;
            if (printDlg.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }
            
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int leftMargin = e.MarginBounds.Left;
            int topMargin = e.MarginBounds.Top;
            bool morePages = false;
            int tempWidth = 0;

            if (firstPage)
            {
                currentRow = 0;
                totalWidth = 0;
                columnLefts.Clear();
                columnWidths.Clear();

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    int colWidth = (int)Math.Floor((double)column.Width);
                    totalWidth += colWidth;
                    columnLefts.Add(tempWidth + leftMargin);
                    columnWidths.Add(colWidth);
                    tempWidth += colWidth;
                }
                firstPage = false;
            }

            Font font = dataGridView1.Font;
            int y = topMargin;

            // Print headers
            if (headerHeight == 0)
                headerHeight = dataGridView1.ColumnHeadersHeight;

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, new Rectangle(columnLefts[i], y, columnWidths[i], headerHeight));
                e.Graphics.DrawRectangle(Pens.Black, columnLefts[i], y, columnWidths[i], headerHeight);
                e.Graphics.DrawString(dataGridView1.Columns[i].HeaderText, font, Brushes.Black, columnLefts[i], y);
            }
            y += headerHeight;

            // Print rows
            while (currentRow < dataGridView1.Rows.Count)
            {
                int rowHeight = dataGridView1.Rows[currentRow].Height;

                if (y + rowHeight > e.MarginBounds.Bottom)
                {
                    morePages = true;
                    break;
                }

                for (int i = 0; i < dataGridView1.Columns.Count; i++)
                {
                    string cellValue = dataGridView1.Rows[currentRow].Cells[i].FormattedValue?.ToString() ?? "";
                    e.Graphics.DrawRectangle(Pens.Black, columnLefts[i], y, columnWidths[i], rowHeight);
                    e.Graphics.DrawString(cellValue, font, Brushes.Black, new RectangleF(columnLefts[i], y, columnWidths[i], rowHeight));
                }
                y += rowHeight;
                currentRow++;
            }

            e.HasMorePages = morePages;

            if (!morePages)
            {
                firstPage = true;
                headerHeight = 0;
            }
        }
    }
}
