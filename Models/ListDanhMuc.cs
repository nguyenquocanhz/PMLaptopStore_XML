using PMLaptopStore_XML.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PMLaptopStore_XML.Category
{
    public class ListDanhMuc
    {
        List<DanhMuc> listDanhMuc = new List<DanhMuc>();

        public ListDanhMuc() { }

        public ListDanhMuc(List<DanhMuc> listDanhMuc)
        {
            this.listDanhMuc = listDanhMuc;
        }

        public List<DanhMuc> ListDanhMuc1 { get => listDanhMuc; set => listDanhMuc = value; }

        public List<DanhMuc> GetListDanhMuc()
        {
            return listDanhMuc;
        }
        public void AddDanhMuc(DanhMuc dm)
        {
            listDanhMuc.Add(dm);
        }

        public void XoaDanhMuc(string maDanhMuc)
        {
            foreach (DanhMuc item in listDanhMuc)
            {
                if (item.MaDanhMuc.Equals(maDanhMuc))
                {
                    listDanhMuc.Remove(item);
                    break;
                }
            }
        }

        public void SuaDanhMuc(DanhMuc dm)
        {
            foreach (DanhMuc item in listDanhMuc)
            {
                if (item.MaDanhMuc.Equals(dm.MaDanhMuc))
                {
                    item.TenDanhMuc = dm.TenDanhMuc;
                    break;
                }
            }
        }

        public DanhMuc TimDanhMuc(string maDanhMuc)
        {
            foreach (DanhMuc item in listDanhMuc)
            {
                if (item.MaDanhMuc.Equals(maDanhMuc))
                {
                    return item;
                }
            }
            return null;
        }

        public bool KiemTraDanhMuc(string maDanhMuc)
        {
            foreach (DanhMuc item in listDanhMuc)
            {
                if (item.MaDanhMuc.Equals(maDanhMuc))
                {
                    return true;
                }
            }
            return false;
        }

        public bool KiemTraTenDanhMuc(string tenDanhMuc)
        {
            foreach (DanhMuc item in listDanhMuc)
            {
                if (item.TenDanhMuc.Equals(tenDanhMuc))
                {
                    return true;
                }
            }
            return false;
        }
        // add danh muc
        public void AddDanhMuc(string maDanhMuc, string tenDanhMuc)
        {
            DanhMuc dm = new DanhMuc(maDanhMuc, tenDanhMuc);
            listDanhMuc.Add(dm);
        }

        // đọc danh sách danh mục từ file XML và thêm vào listDanhMuc
        public void ReadListDanhMucFromXML(string filePath)
        {
            XmlHelpers xml = new XmlHelpers();
            List<string> listMaDanhMuc = xml.GetAllNodeValues(filePath, "MaDanhMuc");
            List<string> listTenDanhMuc = xml.GetAllNodeValues(filePath, "TenDanhMuc");
            for (int i = 0; i < listMaDanhMuc.Count; i++)
            {
                DanhMuc dm = new DanhMuc(listMaDanhMuc[i], listTenDanhMuc[i]);
                listDanhMuc.Add(dm);
            }
        }
    }
}
