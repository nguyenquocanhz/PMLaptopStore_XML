using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMLaptopStore_XML.Category
{
    public class DanhMuc
    {
        private string _maDanhMuc;
        private string _tenDanhMuc;


        public DanhMuc() { }

        public DanhMuc(string maDanhMuc, string tenDanhMuc)
        {
            this._maDanhMuc = maDanhMuc;
            this._tenDanhMuc = tenDanhMuc;
        }

        public string MaDanhMuc { get => _maDanhMuc; set => _maDanhMuc = value; }
        public string TenDanhMuc { get => _tenDanhMuc; set => _tenDanhMuc = value; }
    }
}
