using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMLaptopStore_XML
{
    public partial class FQuanLyNhanVien: Form
    {
        public FQuanLyNhanVien()
        {
            InitializeComponent();
            InitChucDanh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void InitChucDanh()
        {
            List<string> list = new List<string>();
            string[] chucdanh = {"Nhân viên", "Quản lý"};
            foreach (var item in chucdanh)
            {
                list.Add(item);
            }
            cbChucDanh.DropDownStyle = ComboBoxStyle.DropDownList;
            cbChucDanh.DataSource = list;

        }
        private void InitDatagridView()
        {
            
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
