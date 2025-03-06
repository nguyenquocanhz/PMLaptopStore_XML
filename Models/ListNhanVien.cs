using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMLaptopStore_XML.Models
{
    public class ListNhanVien
    {
        public ListNhanVien() { }
        public string filePath = @"I:\LapTrinhWindowForm\PMLaptopStore_XML\PMLaptopStore_XML\DataXML\NhanVien.xml";
        public List<NhanVien> nhanViens = new List<NhanVien>();

        public List<NhanVien> GetNhanViens() 
        { 
            return nhanViens; 
        }

        // add list 
        public void themNV(string[] data)
        {
            
        }
    }
}
