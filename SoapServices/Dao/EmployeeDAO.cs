using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SoapServices.Data;

namespace SoapServices.Dao
{
    public class EmployeeDAO
    {
        DBDataContext db = new DBDataContext();

        public List<Employee> SelectAll()
        {
            List<Employee> employees = db.Employees.ToList();
            return employees;
        }

        public Employee SelectById(string id)
        {
            Employee employee = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return employee;
        }

        public List<Employee> SelectByKeyWord(string keyword)
        {
            List<Employee> employees = db.Employees.Where(x => x.Name.ToLower().Contains(keyword.ToLower())).ToList();
            return employees;
        }

        public bool Insert(Employee newEmployee)
        {
            if (newEmployee != null)
            {
                try
                {
                    db.Employees.InsertOnSubmit(newEmployee);
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

        public bool Update(Employee newEmployee)
        {
            Employee employee = db.Employees.Where(x => x.Id == newEmployee.Id).FirstOrDefault();
            if (employee != null)
            {
                try
                {
                    employee.Name = newEmployee.Name;
                    employee.Age = newEmployee.Age;
                    employee.Gender = newEmployee.Gender;
                    employee.Dob = newEmployee.Dob;
                    employee.Address = newEmployee.Address;
                    employee.Phone = newEmployee.Phone;
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
            Employee employee = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (employee != null)
            {
                try
                {
                    db.Employees.DeleteOnSubmit(employee);
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

        public List<Employee> SortAsc(string name)
        {
            List<Employee> employees = SelectAll();
            if (name == "Name")
            {
                employees = employees.OrderBy(x => x.Name).ToList();
            }
            else if (name == "Age")
            {
                employees = employees.OrderBy(x => x.Age).ToList();
            }
            else if (name == "Dob")
            {
                employees = employees.OrderBy(x => x.Dob).ToList();
            }
            else if (name == "Gender")
            {
                employees = employees.OrderBy(x => x.Gender).ToList();
            }
            else if (name == "Address")
            {
                employees = employees.OrderBy(x => x.Address).ToList();
            }
            else if (name == "Phone")
            {
                employees = employees.OrderBy(x => x.Phone).ToList();
            }
            return employees;
        }

        public List<Employee> SortDesc(string name)
        {
            List<Employee> employees = SelectAll();
            if (name == "Name")
            {
                employees = employees.OrderByDescending(x => x.Name).ToList();
            }
            else if (name == "Age")
            {
                employees = employees.OrderByDescending(x => x.Age).ToList();
            }
            else if (name == "Dob")
            {
                employees = employees.OrderByDescending(x => x.Dob).ToList();
            }
            else if (name == "Gender")
            {
                employees = employees.OrderByDescending(x => x.Gender).ToList();
            }
            else if (name == "Address")
            {
                employees = employees.OrderByDescending(x => x.Address).ToList();
            }
            else if (name == "Phone")
            {
                employees = employees.OrderByDescending(x => x.Phone).ToList();
            }
            return employees;
        }

        public List<Employee> FilterGender(bool gender)
        {
            List<Employee> employees = db.Employees.Where(x => x.Gender == gender).ToList();
            return employees;
        }
    }
}