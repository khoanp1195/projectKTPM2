using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using QuanLyNhaSach.DAO;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach.BUS
{
    class AdminBUS
    {
        AdminDAO dao = new AdminDAO();

        public Admin GetAdminDetail(string username)
        {
            Admin admin = null;
            SqlDataReader dr = dao.CheckExists(username);
            while (dr.Read())
            {
                admin = new Admin()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = (string)dr["Name"],
                    Username = (string)dr["Username"],
                    Password = (string)dr["Password"],
                    Image =  (byte[])dr["Image"],
                    Rule = (string)dr["Rule"]
                };
            }
            if (admin != null)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }

        public Admin Login(string username, string password)
        {
            Admin admin = null;
            SqlDataReader dr = dao.Login(username, password);
            while (dr.Read())
            {
                admin = new Admin()
                {
                    Id = Convert.ToInt32(dr["Id"]),
                    Name = (string)dr["Name"],
                    Username = (string)dr["Username"],
                    Password = (string)dr["Password"],
                    Image = (Byte[])dr["Image"],
                    Rule = (string)dr["Rule"],
                };
            }
            if (admin != null)
            {
                return admin;
            }
            else
            {
                return null;
            }
        }

        public bool InsertAdmin(Admin admin)
        {
            bool result = dao.Insert(admin);
            return result;
        }

        public bool UpdateAdmin(Admin admin, string username)
        {
            bool result = dao.Update(admin, username);
            return result;
        }
    }
}
