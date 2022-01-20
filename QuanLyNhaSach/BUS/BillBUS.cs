using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QuanLyNhaSach.DAO;
using QuanLyNhaSach.Data;

namespace QuanLyNhaSach.BUS
{
    class BillBUS
    {
        BillDAO dao = new BillDAO();

        public DataSet GetDetailInformationBillByID()
        {
            DataSet ds = dao.SelectDetailInformationBillByID();
            return ds;
        }

        public DataSet GetAllBill()
        {
            DataSet ds = dao.SelectAllBill();
            return ds;
        }

        public DataSet GetAllDetailBill()
        {
            DataSet ds = dao.SelectAllDetailBill();
            return ds;
        }

        public DataSet GetAllDetailBill(string id)
        {
            DataSet ds = dao.SelectAllDetailBill(id);
            return ds;
        }

        public DataSet GetAllEmployee()
        {
            DataSet ds = dao.SelectAllEmployee();
            return ds;
        }

        public DataSet GetAllCustomer()
        {
            DataSet ds = dao.SelectAllCustomer();
            return ds;
        }

        public DataSet GetAllProduct()
        {
            DataSet ds = dao.SelectAllProduct();
            return ds;
        }

        public List<Bill> GetAllBills()
        {
            List<Bill> bills = new List<Bill>();
            SqlDataReader dr = dao.SelectAllAdvancedBill();
            while (dr.Read())
            {
                Bill bill = new Bill()
                {
                    CodeHD = (string)dr["CodeHD"],
                    CodeNV = (string)dr["CodeNV"],
                    SellDay = (DateTime)dr["SellDay"],
                    CodeKH = (string)dr["CodeKH"],
                    Total = Convert.ToDecimal(dr["Total"]),     
                };
                bills.Add(bill);
            }
            if (bills != null)
            {
                return bills;
            }
            else
            {
                return null;
            }
        }

        public List<DetailBill> GetAllDetailBills()
        {
            List<DetailBill> detailBills = new List<DetailBill>();
            SqlDataReader dr = dao.SelectAllAdvancedDetailBill();
            while (dr.Read())
            {
                DetailBill detailBill = new DetailBill()
                {
                    Id = (string)dr["Id"],
                    CodeMH = (string)dr["CodeMH"],
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    Price = Convert.ToDecimal(dr["Price"]),
                    Sale = float.Parse(dr["Sale"].ToString()),
                    Total = Convert.ToDecimal(dr["Total"]),
                };
                detailBills.Add(detailBill);
            }
            if (detailBills != null)
            {
                return detailBills;
            }
            else
            {
                return null;
            }
        }

        public Bill GetBillDetail(string id)
        {
            Bill bill = null;
            SqlDataReader dr = dao.SelectBillById(id);
            while (dr.Read())
            {
                bill = new Bill()
                {
                    CodeHD = (string)dr["CodeHD"],
                    CodeNV = (string)dr["CodeNV"],
                    SellDay = (DateTime)dr["SellDay"],
                    CodeKH = (string)dr["CodeKH"],
                    Total = Convert.ToDecimal(dr["Total"]),
                };
            }
            if (bill != null)
            {
                return bill;
            }
            else
            {
                return null;
            }
        }

        public DetailBill GetDetailBillDetail(string id)
        {
            DetailBill detailBill = null;
            SqlDataReader dr = dao.SelectDetailBillById(id);
            while (dr.Read())
            {
                detailBill = new DetailBill()
                {
                    Id = (string)dr["Id"],
                    CodeMH = (string)dr["CodeMH"],
                    Quantity = Convert.ToInt32(dr["Quantity"]),
                    Price = Convert.ToDecimal(dr["Price"]),
                    Sale = float.Parse(dr["Sale"].ToString()),
                    Total = Convert.ToDecimal(dr["Total"]),
                };
            }
            if (detailBill != null)
            {
                return detailBill;
            }
            else
            {
                return null;
            }
        }

        public bool InsertBill(Bill bill)
        {
            bool result = dao.InsertBill(bill);
            return result;
        }

        public bool UpdateBill(Bill bill)
        {
            bool result = dao.UpdateBill(bill);
            return result;
        }

        public bool DeleteBill(string id)
        {
            bool result = dao.DeleteBill(id);
            return result;
        }

        public bool InsertDetailBill(DetailBill detailBill)
        {
            bool result = dao.InsertDetailBill(detailBill);
            return result;
        }

        public bool UpdateDetailBill(DetailBill detailBill)
        {
            bool result = dao.UpdateDetailBill(detailBill);
            return result;
        }

        public bool DeleteDetailBill(string id)
        {
            bool result = dao.DeleteDetailBill(id);
            return result;
        }

        public bool DeleteDetailBill(string id, string codeSP)
        {
            bool result = dao.DeleteDetailBill(id,codeSP);
            return result;
        }
    }
}
