using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace university
{
    internal class function
    {
        protected SqlConnection GetSqlConnection()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=DESKTOP-AQ0VOT0;Initial Catalog=log;Integrated Security=True;";
            return con;
        }
        public DataSet GetData(string query)
        {
            SqlConnection con = GetSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public void SetData(string query,string msg)
        {
            SqlConnection con = GetSqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = query;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show(msg, "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
