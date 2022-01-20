using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Data
{
    class Admin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Binary Image { get; set; }
        public string Rule { get; set; }
       
        public Admin()
        {
        }

        public Admin(int id, string name, string username, string password, Binary image, string rule)
        {
            Id = id;
            Name = name;
            Username = username;
            Password = password;
            Image = image;
            Rule = rule;
        }
    }
}
