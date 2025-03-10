using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.IO;

namespace PMLaptopStore_XML.Models
{
    public class NhanVien
    {
        public XDocument doc;
        public XElement root;
        public string fileName = "NhanVien.xml";

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

        public NhanVien()
        {
            CheckFileExist();
        }

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

        public void CheckFileExist()
        {
            if (!File.Exists(fileName))
            {
                // Nếu file không tồn tại, tạo mới XML
                doc = new XDocument(
                    new XElement("nhanviens")
                );

                root = doc.Root;
                doc.Save(fileName);

                // Tạo danh sách nhân viên mẫu
                List<NhanVien> danhSachMau = new List<NhanVien>
                {
                    new NhanVien("NV001", "Nguyễn Văn A", new DateTime(1990, 5, 15), "0123456789",
                        "Giám đốc", "Quản lý", new DateTime(2015, 7, 1), "admin", "admin123", "admin"),

                    new NhanVien("NV002", "Trần Thị B", new DateTime(1995, 10, 12), "0987654321",
                        "Nhân viên", "Kế toán", new DateTime(2020, 3, 15), "tranb", "pass123", "user"),

                    new NhanVien("NV003", "Lê Văn C", new DateTime(1998, 8, 21), "0971122334",
                        "Nhân viên", "Kinh doanh", new DateTime(2022, 5, 10), "levanc", "password", "user")
                };

                foreach (var nv in danhSachMau)
                {
                    ThemNodeNhanVien(nv);
                }
            }
            else
            {
                // Nếu file đã tồn tại, load XML vào bộ nhớ
                doc = XDocument.Load(fileName);
                root = doc.Root;
            }
        }

        public void ThemNodeNhanVien(NhanVien nv)
        {
            CheckFileExist();

            XElement newNhanVien = new XElement("nhanvien",
                new XAttribute("ma", nv.MaNhanVien),
                new XElement("thongtin",
                    new XElement("hovaten", nv.HoVaTen),
                    new XElement("ngaysinh", nv.NgaySinh.ToString("yyyy-MM-dd")),
                    new XElement("sodienthoai", nv.SoDienThoai),
                    new XElement("chucvu", nv.ChucVu),
                    new XElement("phongban", nv.PhongBan),
                    new XElement("ngaytuyendung", nv.NgayTuyenDung.ToString("yyyy-MM-dd")),
                    new XElement("info", $"{nv.TaiKhoan}|{nv.MatKhau}|{nv.VaiTro}")
                )
            );

            root.Add(newNhanVien);
            doc.Save(fileName);
        }

        public void XoaNhanVien(string maNhanVien)
        {
            CheckFileExist();

            XElement nhanVien = root.Elements("nhanvien")
                .FirstOrDefault(x => x.Attribute("ma").Value == maNhanVien);

            if (nhanVien != null)
            {
                nhanVien.Remove();
                doc.Save(fileName);
            }
        }

        public void SuaNhanVien(NhanVien nv)
        {
            CheckFileExist();

            XElement nhanVien = root.Elements("nhanvien")
                .FirstOrDefault(x => x.Attribute("ma").Value == nv.MaNhanVien);

            if (nhanVien != null)
            {
                nhanVien.Element("thongtin").Element("hovaten").Value = nv.HoVaTen;
                nhanVien.Element("thongtin").Element("ngaysinh").Value = nv.NgaySinh.ToString("yyyy-MM-dd");
                nhanVien.Element("thongtin").Element("sodienthoai").Value = nv.SoDienThoai;
                nhanVien.Element("thongtin").Element("chucvu").Value = nv.ChucVu;
                nhanVien.Element("thongtin").Element("phongban").Value = nv.PhongBan;
                nhanVien.Element("thongtin").Element("ngaytuyendung").Value = nv.NgayTuyenDung.ToString("yyyy-MM-dd");
                nhanVien.Element("thongtin").Element("info").Value = $"{nv.TaiKhoan}|{nv.MatKhau}|{nv.VaiTro}";

                doc.Save(fileName);
            }
        }

        public List<NhanVien> DocDanhSachNhanVien()
        {
            CheckFileExist();

            List<NhanVien> danhSach = new List<NhanVien>();

            foreach (XElement nhanVien in root.Elements("nhanvien"))
            {
                string[] info = nhanVien.Element("thongtin").Element("info").Value.Split('|');

                NhanVien nv = new NhanVien(
                    nhanVien.Attribute("ma").Value,
                    nhanVien.Element("thongtin").Element("hovaten").Value,
                    DateTime.Parse(nhanVien.Element("thongtin").Element("ngaysinh").Value),
                    nhanVien.Element("thongtin").Element("sodienthoai").Value,
                    nhanVien.Element("thongtin").Element("chucvu").Value,
                    nhanVien.Element("thongtin").Element("phongban").Value,
                    DateTime.Parse(nhanVien.Element("thongtin").Element("ngaytuyendung").Value),
                    info[0],
                    info[1],
                    info[2]
                );

                danhSach.Add(nv);
            }

            return danhSach;
        }
    }
}
