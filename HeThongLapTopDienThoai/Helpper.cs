using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace HeThongLapTopDienThoai
{
    class Helpper<T> where T : class
    {
        public static T ReadFile(string filename)
        {
            var fullpath = Path.Combine(Common.FullPath, filename);
            var data = "";
            using (StreamReader sr = File.OpenText(fullpath))
            {
                data = sr.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<T>(data);
        }
        public static void WriteFile(string filename, object data)
        {
            var serializeObject = JsonConvert.SerializeObject(data);
            var fullpath = Path.Combine(Common.FullPath, filename);
            using (StreamWriter sw = File.CreateText(fullpath))
            {
                sw.WriteLine(serializeObject);
            }
        }
       
        public static void HangNhap(List<SanPham> loaiHangs, out long sum)
        {
            var result1 = Helpper<HangHoa>.ReadFile("sanpham.json");


            string choice = "";
            bool check1 = false;
            do
            {
                Console.Write("Nhap ten san pham: ");
                string name = Console.ReadLine();

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
                Console.WriteLine("Ban co muon nhap them hang??");
                Console.Write("Nhap c de tiep tuc nhap, k de thoat: ");
                choice = Console.ReadLine();
            }
            while (choice != "k");
            sum = 0;
            foreach (SanPham sanpham in loaiHangs)
            {
                sum += sanpham.TongTien1MatHang;
            }
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
