using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SoapServices.Data;
using SoapServices.Dao;

namespace SoapServices.Services
{
    /// <summary>
    /// Summary description for CustomerServices
    /// </summary>
    [WebService(Namespace = "http://quanlynhasach.org/customer")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CustomerServices : System.Web.Services.WebService
    {

        CustomerDAO dao = new CustomerDAO();

        [WebMethod]
        public List<Customer> GetAll()
        {
            List<Customer> customers = dao.SelectAll();
            return customers;
        }

        [WebMethod]
        public Customer GetDetail(string id)
        {
            Customer customer = dao.SelectById(id);
            return customer;
        }

        [WebMethod]
        public List<Customer> SearchByKeyword(string keyword)
        {
            List<Customer> customers = dao.SelectByKeyWord(keyword);
            return customers;
        }

        [WebMethod]
        public bool InsertCustomer(Customer customer)
        {
            bool result = dao.Insert(customer);
            return result;
        }

        [WebMethod]
        public bool UpdateCustomer(Customer customer)
        {
            bool result = dao.Update(customer);
            return result;
        }

        [WebMethod]
        public bool DeleteCustomer(string id)
        {
            bool result = dao.Delete(id);
            return result;
        }

        [WebMethod]
        public List<Customer> SortAsc(string name)
        {
            List<Customer> customers = dao.SortAsc(name);
            return customers;
        }

        [WebMethod]
        public List<Customer> SortDesc(string name)
        {
            List<Customer> customers = dao.SortDesc(name);
            return customers;
        }

        [WebMethod]
        public List<Customer> FilterGender(bool gender)
        {
            List<Customer> customers = dao.FilterGender(gender);
            return customers;
        }
    }
}
