using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongLapTopDienThoai
{
    class SanPham
    {
        public string Name { get; set; }
        public long Gia { get; set; }
        public int  Soluong { get; set; }
        public long TongTien1MatHang => Tong1MatHang();
        public long Tong1MatHang()
        {
            return Soluong * Gia;
        }
        public override string ToString()
        {
            return $"{Name}\t {Soluong}\t {string.Format("{0:0,0}", Gia)}vnd\t {string.Format("{0:0,0}", TongTien1MatHang)}vnd";
        }
        public static void ShowHang()
        {
            var result = Helpper<HangHoa>.ReadFile("sanpham.json");
            Console.WriteLine("Ten san pham\tDon gia\t");
            foreach (var hang in result.mathang)
            {
                Console.WriteLine($"{hang.Name}\t{string.Format("{0:0,0}", hang.Gia)}vnd");
            } 
        }
        public static void XemGioHang(List<SanPham> loaiHangs)
        {
            Console.WriteLine("Ten san pham\tSo luong\tDon gia\tTong Tien 1 san pham");
            foreach (SanPham hang in loaiHangs)
            {
                Console.WriteLine(hang.ToString());
            }
        }

    }
}
