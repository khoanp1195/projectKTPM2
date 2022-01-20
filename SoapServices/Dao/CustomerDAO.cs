using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoapServices.Data;

namespace SoapServices.Dao
{
    public class CustomerDAO
    {
        DBDataContext db = new DBDataContext();

        public List<Customer> SelectAll()
        {
            List<Customer> customers = db.Customers.ToList();
            return customers;
        }

        public Customer SelectById(string id)
        {
            Customer customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            return customer;
        }

        public List<Customer> SelectByKeyWord(string keyword)
        {
            List<Customer> customers = db.Customers.Where(x => x.Name.ToLower().Contains(keyword.ToLower())).ToList();
            return customers;
        }

        public bool Insert(Customer newCustomer)
        {
            if (newCustomer != null)
            {
                try
                {
                    db.Customers.InsertOnSubmit(newCustomer);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Update(Customer newCustomer)
        {
            Customer customer = db.Customers.Where(x => x.Id == newCustomer.Id).FirstOrDefault();
            if (customer != null)
            {
                try
                {
                    customer.Name = newCustomer.Name;
                    customer.Age = newCustomer.Age;
                    customer.Gender = newCustomer.Gender;
                    customer.Dob = newCustomer.Dob;
                    customer.Address = newCustomer.Address;
                    customer.Phone = newCustomer.Phone;
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool Delete(string id)
        {
            Customer customer = db.Customers.Where(x => x.Id == id).FirstOrDefault();
            if (customer != null)
            {
                try
                {
                    db.Customers.DeleteOnSubmit(customer);
                    db.SubmitChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public List<Customer> SortAsc(string name)
        {
            List<Customer> customers = SelectAll();
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
            List<Customer> customers = SelectAll();
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

        public List<Customer> FilterGender(bool gender)
        {
            List<Customer> customers = db.Customers.Where(x => x.Gender == gender).ToList();
            return customers;
        }
    }
}