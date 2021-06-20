using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongLapTopDienThoai
{
    class HangHoa
    {
        public List<SanPham> mathang { get; set; }
        public static void HangNhap(List<SanPham> loaiHangs, Bill billl, out long sum)
        {
            var result1 = Helpper<HangHoa>.ReadFile("sanpham.json");
            string choice = "";
            string name;
            do
            {
                bool check = false;
                bool check1 = false;
                Console.Write("Nhap ten san pham: ");
                name = Console.ReadLine();
                foreach (SanPham item in result1.mathang)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        check = true;
                    }
                }
                if (check == true)
                {
                    foreach (SanPham sanpham in loaiHangs)
                    {
                        if (sanpham.Name.ToLower() == name.ToLower())
                        {
                            check1 = true;
                        }
                    }
                    Console.Write("Nhap so luong muon mua: ");
                    int sl = int.Parse(Console.ReadLine());
                    foreach (var item in result1.mathang)
                    {

                        if (item.Name.ToLower() == name.ToLower())
                        {
                            if (item.Soluong < sl)
                            {
                                Console.WriteLine("So luon mat hang khong du dap ung, xin quy khach thong cam mua so luong it hon!!");
                            }
                            else
                            {
                                if (check1)
                                {
                                    foreach (SanPham items in loaiHangs)
                                    {
                                        if (items.Name.ToLower() == name.ToLower())
                                        {
                                            items.Soluong += sl;
                                        }
                                    }
                                }
                                else
                                {
                                    loaiHangs.Add(new SanPham()
                                    {
                                        Name = item.Name,
                                        Soluong = sl,
                                        Gia = item.Gia
                                    });
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("San pham ko ton tai !!");
                }

                Console.WriteLine("Ban co muon tiep tuc mua hang??");
                Console.Write("Nhap c de tiep tuc nhap, k de thoat: ");
                choice = Console.ReadLine();
            }
            while (choice != "k");
            sum = 0;
            foreach (SanPham sanpham in loaiHangs)
            {
                sum += sanpham.TongTien1MatHang;
            }
            billl.bill = loaiHangs;
            billl.TotalAmount = sum;
        }
        public static void ChinhSuaGioHang(List<SanPham> loaiHangs)
        {
            SanPham.XemGioHang(loaiHangs);
            Console.Write("Nhap mon hang muon chinh sua :");
            string name = Console.ReadLine();
            bool check = false;
            foreach (SanPham hang in loaiHangs)
            {
                if (hang.Name.ToLower() == name.ToLower())
                {
                    Console.Write("Nhap so luong muon thay doi: ");
                    int sl = int.Parse(Console.ReadLine());
                    check = true;
                    if (sl == 0)
                    {
                        loaiHangs.Remove(hang);
                        Console.WriteLine("San pham da xoa khoi gio hang.");
                        break;
                    }
                    else
                    {
                        hang.Soluong = sl;
                    }
                }
            }
            if (check == false) { Console.WriteLine("San pham khong co trong gio, vui long kiem tra lai!!"); }
            SanPham.XemGioHang(loaiHangs);
        }
    }
}
