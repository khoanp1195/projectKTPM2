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
    class EmployeeBUS
    {
        EmployeeDAO dao = new EmployeeDAO();

        public DataSet GetAll(string keyword)
        {
            DataSet ds = dao.SelectAll(keyword);
            return ds;
        }

        public List<Employee> GetAllAdvanced()
        {
            List<Employee> employees = new List<Employee>();
            SqlDataReader dr = dao.SelectAllAdvanced();
            while (dr.Read())
            {
                Employee employee = new Employee()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Age = Convert.ToInt32(dr["Age"]),
                    Dob = (DateTime)dr["Dob"],
                    Gender = Convert.ToInt32(dr["Gender"]),
                    Address = (string)dr["Address"],
                    Phone = Convert.ToInt32(dr["Phone"])
                };
                employees.Add(employee);
            }
            if (employees != null)
            {
                return employees;
            }
            else
            {
                return null;
            }
        }

        public Employee GetEmployeeDetail(string id)
        {
            Employee employee = null;
            SqlDataReader dr = dao.SelectById(id);
            while (dr.Read())
            {
                employee = new Employee()
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
            if(employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }

        public List<Employee> GetEmployeesSearch(string keyword)
        {
            List<Employee> employees = new List<Employee>(); ;
            SqlDataReader dr = dao.SelectByKeyWord(keyword);
            while (dr.Read())
            {
                Employee employee = new Employee()
                {
                    Id = (string)dr["Id"],
                    Name = (string)dr["Name"],
                    Age = Convert.ToInt32(dr["Age"]),
                    Dob = (DateTime)dr["Dob"],
                    Gender = Convert.ToInt32(dr["Gender"]),
                    Address = (string)dr["Address"],
                    Phone = Convert.ToInt32(dr["Phone"])
                };
                employees.Add(employee);
            }
            if (employees != null)
            {
                return employees;
            }
            else
            {
                return null;
            }
        }

        public bool InsertEmployee(Employee employee)
        {
            bool result = dao.Insert(employee);
            return result;
        }

        public bool UpdateEmployee(Employee employee,string id)
        {
            bool result = dao.Update(employee,id);
            return result;
        }

        public bool DeleteEmployee(string id)
        {
            bool result = dao.Delete(id);
            return result;
        }

        public List<Employee> SortAsc(string name)
        {
            List<Employee> employees = GetAllAdvanced();
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
            List<Employee> employees = GetAllAdvanced();
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

        public List<Employee> FilterGender(int gender)
        {
            List<Employee> employees = GetAllAdvanced();
            employees = employees.Where(x => x.Gender == gender).ToList();
            return employees;
        }
    }
}
