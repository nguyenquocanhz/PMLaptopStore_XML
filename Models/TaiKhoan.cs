using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMLaptopStore_XML.Models
{
    public class TaiKhoan
    {
        public string username { get; set; }
        public string password { get; set; }
        public string quyenhan { get; set; }

        public TaiKhoan() { }
        public TaiKhoan(string username, string password, string quyenhan)
        {
            this.username = username;
            this.password = password;
            this.quyenhan = quyenhan;

        }

    }
}
