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
    class BillDAO
    {
        private DBHelper dbHelper = new DBHelper();

        public BillDAO() 
        {
            dbHelper.ConnectionString = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
        }

        public DataSet SelectAllBill()
        {
            string sql = "SELECT * FROM Bill";
            string taleName = "Bill";
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

        public DataSet SelectAllDetailBill()
        {
            string sql = "SELECT * FROM DetailBill";
            string taleName = "DetailBill";
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

        public DataSet SelectDetailInformationBillByID()
        {
            string sql = "SELECT C.Name AS 'Customer', E.Name AS 'Employee', B.CodeHD, B.SellDay, B.Total FROM Customer C, Employee E, Bill B WHERE C.Id = B.CodeKH AND E.Id = B.CodeNV";
            string taleName = "DetailInformationBill";
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

        public DataSet SelectAllDetailBill(string id)
        {
            string sql = "SELECT * FROM DetailBill WHERE Id = '"+id+"'";
            string taleName = "DetailBill";
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

        public DataSet SelectAllEmployee()
        {
            string sql = "SELECT * FROM Employee";
            string taleName = "Employee";
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

        public DataSet SelectAllCustomer()
        {
            string sql = "SELECT * FROM Customer";
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

        public DataSet SelectAllProduct()
        {
            string sql = "SELECT * FROM Product";
            string taleName = "Product";
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

        public SqlDataReader SelectAllAdvancedBill()
        {
            string sql = "SELECT * FROM Bill";
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

        public SqlDataReader SelectAllAdvancedDetailBill()
        {
            string sql = "SELECT * FROM DetailBill";
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

        public SqlDataReader SelectBillById(string id)
        {
            string sql = "SELECT * FROM Bill WHERE CodeHD = '" + id + "'";
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
        
        public SqlDataReader SelectDetailBillById(string id)
        {
            string sql = "SELECT * FROM DetailBill WHERE Id = '" + id + "'";
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

        public bool InsertBill(Bill bill)
        {
            try
            {
                string sql = "INSERT INTO Bill VALUES ('" + bill.CodeHD + "','" + bill.CodeNV + "','" + bill.SellDay + "','" + bill.CodeKH + "'," + bill.Total + ")";
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

        public bool UpdateBill(Bill bill)
        {
            try
            {
                string sql = "UPDATE Bill SET CodeNV='" + bill.CodeNV + "', CodeKH='" + bill.CodeKH + "', SellDay='" + bill.SellDay + "', Total=" + bill.Total + " Where CodeHD='" + bill.CodeHD + "'";
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

        public bool DeleteBill(string id)
        {
            try
            {
                string sql = "DELETE FROM Bill Where CodeHD= '" + id + "'";
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

        public bool InsertDetailBill(DetailBill detailBill)
        {
            try
            {
                string sql = "INSERT INTO DetailBill VALUES ('" + detailBill.Id + "','" + detailBill.CodeMH + "'," + detailBill.Quantity + "," + detailBill.Price + ", " + detailBill.Sale + ", " + detailBill.Total + ")";
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

        public bool UpdateDetailBill(DetailBill detailBill)
        {
            try
            {
                string sql = "UPDATE DetailBill SET CodeMH='" + detailBill.CodeMH + "', Quantity=" + detailBill.Quantity + ", Price=" + detailBill.Price + ", Sale=" + detailBill.Sale + ", Total=" + detailBill.Total + " Where Id='" + detailBill.Id + "'";
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

        public bool DeleteDetailBill(string id)
        {
            try
            {
                string sql = "DELETE FROM DetailBill Where Id= '" + id + "'";
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

        public bool DeleteDetailBill(string id, string codeSP)
        {
            try
            {
                string sql = "DELETE FROM DetailBill Where Id= '" + id + "' AND CodeMH = '"+codeSP+"'";
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
