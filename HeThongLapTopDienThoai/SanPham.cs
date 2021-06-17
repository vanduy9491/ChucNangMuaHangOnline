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
            return $"{Name}\t {Gia}vnd\t {Soluong}\t {TongTien1MatHang}";
        }
        //public static bool SanPhamIsExist(List<HangHoa> loaiHangs, string name)
        //{
        //    foreach (var item in loaiHangs)
        //    {
        //       for (int i = 0; i < item.dienthoai.Count; i++)
        //       {
        //            if (item.dienthoai[i].Name.ToLower() == name.ToLower()) return true;
        //       }
        //       for (int i = 0; i < item.laptop.Count; i++)
        //       {
        //            if (item.laptop[i].Name.ToLower() == name.ToLower()) return true;
        //       }
        //    }
        //    return false;
        //}
        //public static void HangNhap(List<SanPham> loaiHangs, out long sum)
        //{
        //    var result1 = Helpper<DanhSachHang>.ReadFile("sanpham.json");
           

        //    string choice = "";
        //    bool check1 = false;
        //    do
        //    {
        //        Console.Write("Nhap ten san pham: ");
        //        string name = Console.ReadLine();
                
        //        foreach (SanPham sanpham in loaiHangs)
        //        {
        //            if (sanpham.Name.ToLower() == name.ToLower())
        //            {
        //                check1 = true;
        //            }
        //        }
        //        Console.Write("Nhap so luong muon mua: ");
        //        int sl = int.Parse(Console.ReadLine());
        //        foreach (var item in result1.mathang)
        //        {
        //            for (int i = 0; i < item.dienthoai.Count; i++)
        //            {
        //                if (item.dienthoai[i].Name.ToLower() == name.ToLower())
        //                {
        //                    if (item.dienthoai[i].Soluong < sl)
        //                    {
        //                        Console.WriteLine("So luon mat hang khong du dap ung, xin quy khach thong cam mua so luong it hon!!");
        //                    }
        //                    else
        //                    {
        //                        if (check1)
        //                        {
        //                            foreach (SanPham items in loaiHangs)
        //                            {
        //                                if (items.Name.ToLower() == name.ToLower())
        //                                {
        //                                    items.Soluong += sl;
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            loaiHangs.Add(new SanPham()
        //                            {
        //                                Name = name,
        //                                Soluong = sl,
        //                                Gia = item.dienthoai[i].Gia
        //                            });
        //                        }
        //                    }
        //                }
        //            }
        //            for (int i = 0; i < item.laptop.Count; i++)
        //            {
        //                if (item.laptop[i].Name.ToLower() == name.ToLower())
        //                {
        //                    if (item.laptop[i].Soluong < sl)
        //                    {
        //                        Console.WriteLine("So luon mat hang khong du dap ung, xin quy khach thong cam mua so luong it hon!!");
        //                    }
        //                    else
        //                    {
        //                        if (check1)
        //                        {
        //                            foreach (SanPham items in loaiHangs)
        //                            {
        //                                if (items.Name.ToLower() == name.ToLower())
        //                                {
        //                                    items.Soluong += sl;
        //                                }
        //                            }
        //                        }
        //                        else
        //                        {
        //                            loaiHangs.Add(new SanPham()
        //                            {
        //                                Name = name,
        //                                Soluong = sl,
        //                                Gia = item.laptop[i].Gia
        //                            });
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        Console.WriteLine("Ban co muon nhap them hang??");
        //        Console.Write("Nhap c de tiep tuc nhap, k de thoat: ");
        //        choice = Console.ReadLine();
        //    }
        //    while (choice != "k");
        //    sum = 0;
        //    foreach (SanPham sanpham in loaiHangs)
        //    {
        //        sum += sanpham.TongTien1MatHang;
        //    }
        //}
        public static void XemGioHang(List<SanPham> loaiHangs)
        {
            foreach (SanPham hang in loaiHangs)
            {
                Console.WriteLine(hang.ToString());
            }
        }

    }
}
