using System;

namespace PMLaptopStore_XML.Products
{
    public class SanPham
    {
        public string MaSP { get; set; } // Thay vì ProductionID cho khớp với "ma" trong XML
        public string TenSP { get; set; } // Thay vì ProductName cho khớp với "tensp" trong XML
        public int SoLuong { get; set; } // Thêm thuộc tính "soluong"
        public int DonGia { get; set; } // Thêm thuộc tính "dongia"
        public string BaoHanh { get; set; } // Thêm thuộc tính "baohanh"
        public DateTime NgayNhap { get; set; } // Thêm thuộc tính "ngaynhap" và sử dụng kiểu DateTime
        public string LoaiSP { get; set; } // Thêm thuộc tính "loaisp"
        public string ManHinh { get; set; } // Thêm thuộc tính "manhinh"
        public string CPU { get; set; } // Thêm thuộc tính "cpu"
        public string RAM { get; set; } // Thêm thuộc tính "ram"
        public string SSD { get; set; } // Thêm thuộc tính "ssd"
        public string CardManHinh { get; set; } // Thêm thuộc tính "cardmanhinh"
        public string KetNoi { get; set; } // Thêm thuộc tính "ketnoi"
        public string HDH { get; set; } // Thêm thuộc tính "hdh"
        public string Anh { get; set; } // Thêm thuộc tính "anh"

        public SanPham() { }
    }
}