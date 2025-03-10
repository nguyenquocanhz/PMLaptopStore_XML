using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMLaptopStore_XML.Models
{
    public class DanhSachNhanVien
    {
        public List<NhanVien> listNv;
        public string fileName { get; set; }
        public DanhSachNhanVien() { }

        public List<NhanVien> ListNhanVien => listNv;

        public void ThemNv(NhanVien nv) => listNv.Add(nv);

        

    }
}
