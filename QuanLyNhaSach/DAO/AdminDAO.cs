using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using QuanLyNhaSach.Data;
using System.Configuration;
using System.IO;

namespace QuanLyNhaSach.DAO
{
    class AdminDAO
    {
        private DBHelper dbHelper = new DBHelper();

        public AdminDAO()
        {
            dbHelper.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public SqlDataReader CheckExists(string username)
        {
                SqlConnection connect = dbHelper.GetConnection();
                connect.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "getDetailAdmin";
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                cmd.Connection = connect;

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    return dr;
                }
                else
                {
                    return null;
                }
        }

        public SqlDataReader Login(string username, string password)
        {
            SqlConnection connect = dbHelper.GetConnection();
            connect.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "login";
            cmd.Parameters.Add(new SqlParameter("@Username", username));
            cmd.Parameters.Add(new SqlParameter("@Password", password));
            cmd.Connection = connect;

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(Admin admin)
        {
            try
            {
                int result = 0;
                SqlConnection connect = dbHelper.GetConnection();
                connect.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "addAdmin";
                cmd.Parameters.Add(new SqlParameter("@Name", admin.Name));
                cmd.Parameters.Add(new SqlParameter("@Username", admin.Username));
                cmd.Parameters.Add(new SqlParameter("@Password", admin.Password));
                cmd.Parameters.Add(new SqlParameter("@Image", admin.Image));
                cmd.Parameters.Add(new SqlParameter("@Rule", admin.Rule));
                cmd.Connection = connect;

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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool Update(Admin admin, string username)
        {
            try
            {
                int result = 0;
                SqlConnection connect = dbHelper.GetConnection();
                connect.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updateAdmin";
                cmd.Parameters.Add(new SqlParameter("@Username", username));
                cmd.Parameters.Add(new SqlParameter("@Name", admin.Name));
                cmd.Parameters.Add(new SqlParameter("@Password", admin.Password));

                byte[] b = new byte[admin.Image.Length];
                MemoryStream stream = new MemoryStream();
                stream.Read(b, 0, admin.Image.Length);
                b = admin.Image.ToArray();
                cmd.Parameters.Add(new SqlParameter("@Image", b));
                cmd.Connection = connect;

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
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
