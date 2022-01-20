using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Data
{
    class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime Dob { get; set; }
        public int Gender { get; set; }
        public string Address { get; set; }
        public int Phone { get; set; }

        public Employee()
        {

        }

        public Employee(string id, string name, int age, DateTime dob, int gender, string address, int phone)
        {
            Id = id;
            Name = name;
            Age = age;
            Dob = dob;
            Gender = gender;
            Address = address;
            Phone = phone;
        }
    }
}
