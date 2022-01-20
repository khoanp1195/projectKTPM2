using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyNhaSach.Data
{
    class Bill
    {
        public string CodeHD { get; set; }
        public string CodeNV { get; set; }
        public DateTime SellDay { get; set; }
        public string CodeKH { get; set; }
        public decimal Total { get; set; }

        public Bill() { }

        public Bill(string codeHD, string codeNV, DateTime sellDay, string codeKH, decimal total)
        {
            CodeHD = codeHD;
            CodeNV = codeNV;
            SellDay = sellDay;
            CodeKH = codeKH;
            Total = total;
        }
    }
}
