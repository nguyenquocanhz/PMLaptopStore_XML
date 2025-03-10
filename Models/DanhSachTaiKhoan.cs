using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMLaptopStore_XML.Models
{
    public class DanhSachTaiKhoan
    {
        private string _username;
        private string _password;
        private string _quyenhan;
        private static DanhSachTaiKhoan instance;

        private List<TaiKhoan> listTaiKhoan = new List<TaiKhoan>();

        public static DanhSachTaiKhoan Instance
        {
            get
            {
                if (instance == null)
                    instance = new DanhSachTaiKhoan();
                return instance;
            }
            private set { instance = value; }
        }

        public DanhSachTaiKhoan() { }

        // constructor
        public DanhSachTaiKhoan(string username, string password, string quyenhan)
        {
            this.Username = username;
            this.Password = password;
            this.Quyenhan = quyenhan;
        }
        // instace of DanhSachTaiKhoan

        public override string ToString()
        {
            return this.Username + " " + this.Password + " " + this.Quyenhan;
        }
        // getter and setter
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public string Quyenhan { get => _quyenhan; set => _quyenhan = value; }

        public List<TaiKhoan> ListTaiKhoan { get => listTaiKhoan; set => listTaiKhoan = value; }

        // read data from XML file

        // get list TaiKhoan

        public List<TaiKhoan> GetListTaiKhoan()
        {
            return listTaiKhoan;
        }


        // check login in listTaiKhoan using foreach
        public bool CheckLogin(string username, string password)
        {
            foreach (TaiKhoan item in listTaiKhoan)
            {
                if (item.username.Equals(username) && item.password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public void ThemTK(TaiKhoan tk)
        {
            listTaiKhoan.Add(tk);
        }
        public void XoaTK(TaiKhoan tk)
        {
            listTaiKhoan.Remove(tk);
        }

        public TaiKhoan TimTK(string username)
        {
            foreach (TaiKhoan tk in listTaiKhoan)
            {
                if (tk.username.Equals(username))
                {
                    return tk;
                }
            }
            return null;
        }


        public bool KiemTraTK(string username, string password)
        {
            ReadAccountFromXML();
            foreach (TaiKhoan tk in listTaiKhoan)
            {
                if (tk.username.Equals(username) && tk.password.Equals(password))
                {
                    return true;
                }
            }
            return false;
        }

        public void ReadAccountFromXML()
        {
            string pathTaikhoan = @"I:\LapTrinhWindowForm\PMLaptopStore_XML\PMLaptopStore_XML\DataXML\NhanVien.xml";
            List<string> list = XmlHelpers.Instance.GetAllNodeValues(pathTaikhoan, "info");
            
            foreach (string item in list)
            {
                string[] arr = item.Split('|');
                string username = arr[0];
                string password = arr[1];
                string quyenhan = arr[2];
                TaiKhoan tk = new TaiKhoan(username, password, quyenhan);
                listTaiKhoan.Add(tk);

            
            }
        }
    }
}
