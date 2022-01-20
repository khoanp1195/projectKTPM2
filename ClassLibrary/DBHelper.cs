using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ClassLibrary
{
    public class DBHelper
    {
        public string ConnectionString { get; set; }

        private SqlConnection conn = null;

        public SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            return conn;
        }
    
        public SqlDataReader executeSelect(string sql)
        {
            SqlDataReader dr = null;
            try
            {
                // Init conn
                SqlConnection conn = GetConnection();
                // Open conn
                conn.Open();
                // Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                dr = cmd.ExecuteReader();
            }
            catch
            {
                dr = null;
            }
            return dr;
        }

        public DataSet executeSelect(string sql, string tableName)
        {
                // Init conn
                SqlConnection conn = GetConnection();
                // Open conn
                conn.Open();
                // Data Adapter
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                // Fill DataSet
                DataSet ds = new DataSet();
                da.Fill(ds, tableName);
                return ds;
        }

        public bool executeCRUD(string sql)
        {
            int result = 0;
            try
            {
                // Init conn
                SqlConnection conn = GetConnection();
                // Open conn
                conn.Open();
                // Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public void CloseConnection()
        {
            if(conn != null)
            {
                if(conn.State == ConnectionState.Open)
                {
                    try
                    {
                        conn.Close();
                    }
                    catch
                    {

                    }
                }
            }
        }
    }
}
