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
    /// Summary description for EmployeeServices
    /// </summary>
    [WebService(Namespace = "http://quanlynhasach.org/employee")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class EmployeeServices : System.Web.Services.WebService
    {
        EmployeeDAO dao = new EmployeeDAO();

        [WebMethod]
        public List<Employee> GetAll()
        {
            List<Employee> employees = dao.SelectAll();
            return employees;
        }

        [WebMethod]
        public Employee GetDetail(string id)
        {
            Employee employee = dao.SelectById(id);
            return employee;
        }

        [WebMethod]
        public List<Employee> SearchByKeyword(string keyword)
        {
            List<Employee> employees = dao.SelectByKeyWord(keyword);
            return employees;
        }

        [WebMethod]
        public bool InsertEmployee(Employee employee)
        {
            bool result = dao.Insert(employee);
            return result;
        }

        [WebMethod]
        public bool UpdateEmployee(Employee employee)
        {
            bool result = dao.Update(employee);
            return result;
        }

        [WebMethod]
        public bool DeleteEmployee(string id)
        {
            bool result = dao.Delete(id);
            return result;
        }

        [WebMethod]
        public List<Employee> SortAsc(string name)
        {
            List<Employee> employees = dao.SortAsc(name);
            return employees;
        }

        [WebMethod]
        public List<Employee> SortDesc(string name)
        {
            List<Employee> employees = dao.SortDesc(name);
            return employees;
        }

        [WebMethod]
        public List<Employee> FilterGender(bool gender)
        {
            List<Employee> employees = dao.FilterGender(gender);
            return employees;
        }
    }
}
