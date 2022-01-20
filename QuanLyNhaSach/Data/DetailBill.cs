using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Data
{
    class DetailBill
    {
        public string Id { get; set; }
        public string CodeMH { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public float Sale { get; set; }
        public decimal Total { get; set; }

        public DetailBill() { }

        public DetailBill(string id, string codeMH, int quantity, decimal price, float sale, decimal total)
        {
            Id = id;
            CodeMH = codeMH;
            Quantity = quantity;
            Price = price;
            Sale = sale;
            Total = total;
        }
    }
}
