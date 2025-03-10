using PMLaptopStore_XML.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace PMLaptopStore_XML
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            InitializeComponent();
            try
            {
                NhanVien nv = new NhanVien();
                nv.DocDanhSachNhanVien();
            }
            catch 
            {
                MessageBox.Show("Lỗi không xác định !");
            }
            btnLogin.Click += btnLogin_Click;
        }

        private void cShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = cShowPassword.Checked ? '\0' : '*';
        } 
        // check login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // read xml file to get username and password

            if (username == "" || password == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (DanhSachTaiKhoan.Instance.KiemTraTK(username, password))
            {

                Helpers.ShowMessageBox("Đăng nhập thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fMain f = new fMain(username);
                this.Hide();
                f.ShowDialog();
                this.Show();


            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát chương trình?",
                "Xác nhận thoát",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
