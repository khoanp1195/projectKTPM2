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
    class CustomerDAO
    {

        private DBHelper dbHelper = new DBHelper();

        public CustomerDAO()
        {
            dbHelper.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public DataSet SelectAll(string keyword)
        {
            string sql = "SELECT Id,Name,Age,Case Gender When 0 then N'Nữ' Else N'Nam' End AS Gender,Dob,Address,Phone FROM Customer WHERE Name LIKE  N'%" + keyword + "%'";
            string taleName = "Customer";
            DataSet ds = dbHelper.executeSelect(sql, taleName);
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
            string sql = "SELECT * FROM Customer";
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

        public SqlDataReader SelectById(string id)
        {
            string sql = "SELECT * FROM Customer WHERE Id= '"+id+"'";
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
            string sql = "SELECT * FROM Customer WHERE Name LIKE  N'%" + keyword + "%'";
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

        public bool Insert(Customer newCustomer)
        {
            try
            {
                string sql = "INSERT INTO Customer VALUES ('" + newCustomer.Id + "',N'" + newCustomer.Name + "'," + newCustomer.Age + ",'" + newCustomer.Dob + "'," + newCustomer.Gender + ",N'" + newCustomer.Address + "'," + newCustomer.Phone + ")";
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

        public bool Update(Customer newCustomer,string id)
        {
            try
            {
                string sql = "UPDATE Customer SET Name=N'" + newCustomer.Name + "', Age=" + newCustomer.Age + ", Dob='" + newCustomer.Dob + "', Gender=" + newCustomer.Gender + ", Address=N'" + newCustomer.Address + "', Phone=" + newCustomer.Phone + " Where Id='" + id + "'";
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

        public bool Delete(string id)
        {
            try
            {
                string sql = "DELETE FROM Customer Where Id= '" + id + "'";
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
