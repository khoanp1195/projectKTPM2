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
    class CustomerBUS
    {
        CustomerDAO dao = new CustomerDAO();

        public DataSet GetAll(string keyword)
        {
            DataSet ds = dao.SelectAll(keyword);
            return ds;
        }

        public List<Customer> GetAllAdvanced()
        {
            List<Customer> customers = new List<Customer>();
            SqlDataReader dr = dao.SelectAllAdvanced();
            while (dr.Read())
            {
                Customer customer = new Customer()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Age = Convert.ToInt32(dr["Age"]),
                    Dob = (DateTime)dr["Dob"],
                    Gender = Convert.ToInt32(dr["Gender"]),
                    Address = (string)dr["Address"],
                    Phone = Convert.ToInt32(dr["Phone"])
                };
                customers.Add(customer);
            }
            if (customers != null)
            {
                return customers;
            }
            else
            {
                return null;
            }
        }

        public Customer GetCustomerDetail(string id)
        {
            Customer customer = null;
            SqlDataReader dr = dao.SelectById(id);
            while (dr.Read())
            {
                customer = new Customer()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Age = Convert.ToInt32(dr["Age"]),
                    Dob = (DateTime)dr["Dob"],
                    Gender = Convert.ToInt32(dr["Gender"]),
                    Address = (string)dr["Address"],
                    Phone = Convert.ToInt32(dr["Phone"])
                };
            }
            if (customer != null)
            {
                return customer;
            }
            else
            {
                return null;
            }
        }

        public List<Customer> GetCustomersSearch(string keyword)
        {
            List<Customer> customers = new List<Customer>(); ;
            SqlDataReader dr = dao.SelectByKeyWord(keyword);
            while (dr.Read())
            {
                Customer customer = new Customer()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Age = Convert.ToInt32(dr["Age"]),
                    Dob = (DateTime)dr["Dob"],
                    Gender = Convert.ToInt32(dr["Gender"]),
                    Address = (string)dr["Address"],
                    Phone = Convert.ToInt32(dr["Phone"])
                };
                customers.Add(customer);
            }
            if (customers != null)
            {
                return customers;
            }
            else
            {
                return null;
            }
        }

        public bool InsertCustomer(Customer customer)
        {
            bool result = dao.Insert(customer);
            return result;
        }

        public bool UpdateCustomer(Customer customer,string id)
        {
            bool result = dao.Update(customer,id);
            return result;
        }

        public bool DeleteCustomer(string id)
        {
            bool result = dao.Delete(id);
            return result;
        }

        public List<Customer> SortAsc(string name)
        {
            List<Customer> customers = GetAllAdvanced();
            if (name == "Name")
            {
                customers = customers.OrderBy(x => x.Name).ToList();
            }
            else if (name == "Age")
            {
                customers = customers.OrderBy(x => x.Age).ToList();
            }
            else if (name == "Dob")
            {
                customers = customers.OrderBy(x => x.Dob).ToList();
            }
            else if (name == "Gender")
            {
                customers = customers.OrderBy(x => x.Gender).ToList();
            }
            else if (name == "Address")
            {
                customers = customers.OrderBy(x => x.Address).ToList();
            }
            else if (name == "Phone")
            {
                customers = customers.OrderBy(x => x.Phone).ToList();
            }
            return customers;
        }

        public List<Customer> SortDesc(string name)
        {
            List<Customer> customers = GetAllAdvanced();
            if (name == "Name")
            {
                customers = customers.OrderByDescending(x => x.Name).ToList();
            }
            else if (name == "Age")
            {
                customers = customers.OrderByDescending(x => x.Age).ToList();
            }
            else if (name == "Dob")
            {
                customers = customers.OrderByDescending(x => x.Dob).ToList();
            }
            else if (name == "Gender")
            {
                customers = customers.OrderByDescending(x => x.Gender).ToList();
            }
            else if (name == "Address")
            {
                customers = customers.OrderByDescending(x => x.Address).ToList();
            }
            else if (name == "Phone")
            {
                customers = customers.OrderByDescending(x => x.Phone).ToList();
            }
            return customers;
        }

        public List<Customer> FilterGender(int gender)
        {
            List<Customer> customers = GetAllAdvanced();
            customers = customers.Where(x => x.Gender == gender).ToList();
            return customers;
        }
    }
}
