using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace HeThongLapTopDienThoai
{
    class Menu2
    {
        const int min = 1, max = 4;
        const int Themhang = 1, XemGio = 2, DatHang = 3, Thoat = 4;
        public static void Buildmenu2(out int option)
        {
            do
            {
                Console.WriteLine("-----------Menu-----------");
                Console.WriteLine("1. Them hang vao gio");
                Console.WriteLine("2. Xem gio hang");
                Console.WriteLine("3. Dat hang");
                Console.WriteLine("4. Thoat");
                Console.Write($"Please choice a number ({min},{max}):");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    option = 0;
                }
            }
            while (option < min || option > max);
        }
        public static void Process2()
        {
            List<SanPham> sanPhams = new List<SanPham>();
            var selected = 0;
            long total = 0;
            do
            {
                Buildmenu2(out selected);
                Console.Clear();
                switch (selected)
                {
                    case Themhang:
                        {
                           Helpper<DanhSachHang>.HangNhap(sanPhams, out long sum);
                            total = sum;
                            break;
                        }
                    case XemGio:
                        {
                            SanPham.XemGioHang(sanPhams);
                            Console.WriteLine("Tong gia tri gio hang: " + total);
                            break;
                        }
                    case DatHang:
                        {
                            Helpper<SanPham>.WriteFile("bill.json", sanPhams);
                            var fullpath = Path.Combine(Common.FullPath, "bill.json");
                            using (StreamWriter sw = File.AppendText(fullpath))
                            {
                                sw.WriteLine($"Tong bill la: {total}");
                            }
                            Console.WriteLine("Dat hang thanh cong");
                            break;
                        }
                    case Thoat:
                        {
                            Environment.Exit(0);
                            break;
                        }
                }

            }
            while (selected != Thoat);
        }
    }
}
