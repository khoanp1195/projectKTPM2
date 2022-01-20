using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ClassLibrary;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach.DAO
{
    class CategoryDAO
    {
        private DBHelper dbHelper = new DBHelper();

        public CategoryDAO()
        {
            dbHelper.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public DataSet SelectAll(string keyword)
        {
            string sql = "SELECT * FROM Category WHERE Name LIKE  N'%" + keyword + "%'";
            string tableName = "Category";
            DataSet ds = dbHelper.executeSelect(sql, tableName);
            if (ds != null)
            {
                return ds;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectAllAdvanced()
        {
            string sql = "SELECT * FROM Category";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectById(int id)
        {
            string sql = "SELECT * FROM Category WHERE Id = "+id+" ";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectByName(string name)
        {
            string sql = "SELECT * FROM Category WHERE Name = N'" + name + "' ";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public SqlDataReader SelectByKeyWord(string keyword)
        {
            string sql = "SELECT * FROM Category WHERE Name LIKE  N'%" + keyword + "%'";
            SqlDataReader dr = dbHelper.executeSelect(sql);
            if (dr != null)
            {
                return dr;
            }
            else
            {
                return null;
            }
        }

        public bool Insert(Category newCategory)
        {
            try
            {
                string sql = "INSERT INTO Category VALUES (N'" + newCategory.Name + "')";
                bool result = dbHelper.executeCRUD(sql);
                if (result)
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

        public bool Update(Category newCategory,int id)
        {
            try
            {
                string sql = "UPDATE Category SET Name=N'" + newCategory.Name + "' Where Id=" + id + "";
                bool result = dbHelper.executeCRUD(sql);
                if (result)
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

        public bool Delete(int id)
        {
            try
            {
                string sql = "DELETE FROM Category Where Id= " + id + "";
                bool result = dbHelper.executeCRUD(sql);
                if (result)
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
    }
}
