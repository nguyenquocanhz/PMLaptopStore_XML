using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace PMLaptopStore_XML.Models
{
    public class NhanVien
    {
        public string MaNhanVien { get; set; }
        public string HoVaTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string SoDienThoai { get; set; }
        public string ChucVu { get; set; }
        public string PhongBan { get; set; }
        public DateTime NgayTuyenDung { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }



        public NhanVien() { }

        public NhanVien(string maNhanVien, string hoVaTen, DateTime ngaySinh, string soDienThoai,
                       string chucVu, string phongBan, DateTime ngayTuyenDung, string taiKhoan,
                       string matKhau, string vaiTro)
        {
            MaNhanVien = maNhanVien;
            HoVaTen = hoVaTen;
            NgaySinh = ngaySinh;
            SoDienThoai = soDienThoai;
            ChucVu = chucVu;
            PhongBan = phongBan;
            NgayTuyenDung = ngayTuyenDung;
            TaiKhoan = taiKhoan;
            MatKhau = matKhau;
            VaiTro = vaiTro;
        }

        /// <summary>
        /// Phương thức đọc dữ liệu nhân viên từ XmlNode
        /// </summary>
        public static NhanVien FromXmlNode(XmlNode node)
        {
            if (node == null) return null;

            XmlElement thongTin = node["thongtin"];
            if (thongTin == null) return null;

            string[] accountData = thongTin["info"].InnerText.Split('|');

            return new NhanVien
            {
                MaNhanVien = node.Attributes["ma"].Value,
                HoVaTen = thongTin["hovaten"].InnerText,
                NgaySinh = DateTime.Parse(thongTin["ngaysinh"].InnerText),
                SoDienThoai = thongTin["sodienthoai"].InnerText,
                ChucVu = thongTin["chucvu"].InnerText,
                PhongBan = thongTin["phongban"].InnerText,
                NgayTuyenDung = DateTime.Parse(thongTin["ngaytuyendung"].InnerText),
                TaiKhoan = accountData[0],
                MatKhau = accountData[1],
                VaiTro = accountData[2]
            };
        }

        /// <summary>
        /// Chuyển đổi nhân viên thành XmlElement
        /// </summary>
        public XmlElement ToXmlElement(XmlDocument doc)
        {
            XmlElement nhanVienNode = doc.CreateElement("nhanvien");
            nhanVienNode.SetAttribute("ma", MaNhanVien);

            XmlElement thongTin = doc.CreateElement("thongtin");
            nhanVienNode.AppendChild(thongTin);

            thongTin.AppendChild(CreateElement(doc, "hovaten", HoVaTen));
            thongTin.AppendChild(CreateElement(doc, "ngaysinh", NgaySinh.ToString("yyyy-MM-dd")));
            thongTin.AppendChild(CreateElement(doc, "sodienthoai", SoDienThoai));
            thongTin.AppendChild(CreateElement(doc, "chucvu", ChucVu));
            thongTin.AppendChild(CreateElement(doc, "phongban", PhongBan));
            thongTin.AppendChild(CreateElement(doc, "ngaytuyendung", NgayTuyenDung.ToString("yyyy-MM-dd")));
            thongTin.AppendChild(CreateElement(doc, "info", $"{TaiKhoan}|{MatKhau}|{VaiTro}"));

            return nhanVienNode;
        }

        /// <summary>
        /// Hàm tạo một XmlElement với giá trị nội dung.
        /// </summary>
        private XmlElement CreateElement(XmlDocument doc, string name, string value)
        {
            XmlElement element = doc.CreateElement(name);
            element.InnerText = value;
            return element;
        }


    }
}
