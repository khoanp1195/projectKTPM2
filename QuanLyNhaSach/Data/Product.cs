using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Data
{
    class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Origin { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public Product()
        {

        }

        public Product(string id, string name, double price, string description, string unit, string origin, int categoryId)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Unit = unit;
            Origin = origin;
            CategoryId = categoryId;
        }

        public Product(string id, string name, double price, string description, string unit, string origin, string categoryName)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Unit = unit;
            Origin = origin;
            CategoryName = categoryName;
        }

        public Product(string id, string name, double price, string description, string unit, string origin, int categoryId, string categoryName)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Unit = unit;
            Origin = origin;
            CategoryId = categoryId;
            CategoryName = categoryName;
        }
    }
}
