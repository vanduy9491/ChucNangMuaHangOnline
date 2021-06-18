using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongLapTopDienThoai
{
    class BuildMenu
    {
        const int min = 1, max = 3;
        const int dangnhap = 1, dangky = 2, thoat = 3;
        public static void Buildmenu(out int option)
        {
            do
            {
                Console.WriteLine("-----------Menu-----------");
                Console.WriteLine("1. Dang Nhap");
                Console.WriteLine("2. Dang Ky");
                Console.WriteLine("3. Thoat");
                Console.Write($"Please choice a number ({min},{max}):");
                if (!int.TryParse(Console.ReadLine(), out option))
                {
                    option = 0;
                }
            }
            while (option < min || option > max);
        }
        public static void Process()
        {
            var user = Helpper<List<User>>.ReadFile("user.json");
            var selected = 0;            
            do
            {
                Buildmenu(out selected);
                Console.Clear();
                switch (selected)
                {
                    case dangnhap:
                        {  
                            bool check = User.DangNhap(user);
                            if (check)
                            {
                                Menu2.Process2();
                            }
                            break;
                        }
                    case dangky:
                        {
                            User.DangKy(user);
                            Menu2.Process2();
                            break;
                        }

                    case thoat:
                        { 
                            Environment.Exit(0);
                            break;
                        }
                }

            }
            while (selected != thoat);
        }
    }
}
