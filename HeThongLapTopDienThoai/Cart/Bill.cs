using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace HeThongLapTopDienThoai
{
    class Bill
    {
        public List<SanPham> bill;
        public long TotalAmount { get; set; }
        public Bill()
        {
            bill = new List<SanPham>();
        }
    }
}
