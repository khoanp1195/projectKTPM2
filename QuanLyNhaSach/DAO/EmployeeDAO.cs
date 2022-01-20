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
    class EmployeeDAO
    {

        private DBHelper dbHelper = new DBHelper();

        public EmployeeDAO()
        {
            dbHelper.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public DataSet SelectAll(string keyword)
        {
            string sql = "SELECT Id,Name,Age,Case Gender When 0 then N'Nữ' Else N'Nam' End AS Gender,Dob,Address,Phone FROM Employee WHERE Name LIKE  N'%" + keyword + "%'";
            string tableName = "Employee";
            DataSet ds = dbHelper.executeSelect(sql, tableName);
            if(ds != null)
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
            string sql = "SELECT * FROM Employee";
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
            string sql = "SELECT * FROM Employee WHERE Id= '"+id+"'";
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
            string sql = "SELECT * FROM Employee WHERE Name LIKE  N'%" + keyword + "%'";
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

        public bool Insert(Employee newEmployee)
        {
            try
            {
                string sql = "INSERT INTO Employee VALUES ('" + newEmployee.Id + "',N'" + newEmployee.Name + "'," + newEmployee.Age + ",'" + newEmployee.Dob + "'," + newEmployee.Gender + ",N'" + newEmployee.Address + "'," + newEmployee.Phone + ")";
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

        public bool Update(Employee newEmployee,string id)
        {
            try
            {
                string sql = "UPDATE Employee SET Name=N'" + newEmployee.Name + "', Age=" + newEmployee.Age + ", Dob='" + newEmployee.Dob + "', Gender=" + newEmployee.Gender + ", Address=N'" + newEmployee.Address + "', Phone=" + newEmployee.Phone + " Where Id='" + id + "'";
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
                string sql = "DELETE FROM Employee Where Id= '"+id+"'";
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
