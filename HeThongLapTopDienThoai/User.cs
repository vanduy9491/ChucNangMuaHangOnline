using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongLapTopDienThoai
{
    class User
    {
        private string username;
        private string matKhau;
        public string UserName
        {
            get
            {
                return username;

            }
            set
            {
                username = value;
            }
        }
        public string MatKhau
        {
            get
            {
                return matKhau;

            }
            set
            {
                matKhau = value;
            }
        }
        public static void DangKy(List<User> user)
        {
            Console.WriteLine("hay dien thong tin dang ky!");
            Console.Write("Ten dang nhap: ");
            string name = Console.ReadLine();
            Console.Write("Mat khau: ");
            string matkhau = Console.ReadLine();
            Console.Write("Nhap lai mat khau: ");
            string reMatkhau = Console.ReadLine();
            while (matkhau != reMatkhau)
            {
                Console.WriteLine("Mat khau khong trung khop!");
                Console.Write("Vui long nhap lai mat khau: ");
                reMatkhau = Console.ReadLine();
            }
            User user1 = new User();
            user1.MatKhau = matkhau;
            user1.UserName = name;
            user.Add(user1);
            Helpper<User>.WriteFile("user.json", user);
        }
        public static bool IsNameExist(List<User> user, string name)
        {
            foreach (var item in user)
            {
                if (item.username.Contains(name))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsMkExist(List<User> user, string matkhau)
        {
            foreach (var item in user)
            {
                if (item.matKhau.Contains(matkhau))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool IsExistvalue(List<User> user)
        {
            foreach (var item in user)
            {
                if (item != null)
                {
                    return true;
                }
            }
            return false;
        }
        public static bool DangNhap(List<User> user)
        {
            bool IsDangnhap = false;
            bool check = false;
            if (IsExistvalue(user))
            {
                do
                {
                    Console.Write("Nhap ten dang nhap:");
                    string name = Console.ReadLine();
                    Console.Write("Nhap mat khau:");
                    string mk = Console.ReadLine();
                    bool isNameExist = IsNameExist(user, name);
                    bool isMkExist = IsMkExist(user, mk);
                    if (isNameExist)
                    {
                        if (isMkExist)
                        {
                            Console.WriteLine("Dang nhap thanh cong");
                            IsDangnhap = true;
                            check = true;
                        }
                        else
                        {
                            Console.WriteLine("Sai mat khau!! Vui long dang nhap lai:");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ten dang nhap khong ton tai!! Vui long dang nhap lai");
                    }
                }
                while (check == false);
            }
            else
            {
                Console.WriteLine("Chua co thanh vien!!!");
            }
            return IsDangnhap;
        }
    }
}
