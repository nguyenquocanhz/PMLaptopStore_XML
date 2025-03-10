using PMLaptopStore_XML.DBconfig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace PMLaptopStore_XML
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            btn_DX.Click += btn_DX_Click;
            btnFormNhanVien.Click += btnFormNhanVien_Click;
        }
        public fMain(string username)
        {
            InitializeComponent();
            label1.Text = "Xin chào " + username;

        }
        public void LoadData()
        {
            // Load data from XML file
        }
        // display form child 
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        // open Child Form mdi

        // gán form cho fDonHang cho fmainPanel
        private void fQuanLySanPham_Load(object sender, EventArgs e)
        {

        }

        // hiển thị form fDonHang khi click btnOpenDonHang
        private void btnOpenDonHang_Click(object sender, EventArgs e)
        {
            openChildForm(new fDonHang());
        }
        private void btnFormNhanVien_Click(object sender, EventArgs e)
        {
            openChildForm(new FQuanLyNhanVien());
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }

        private void btnopenHoaDonTT_Click(object sender, EventArgs e)
        {
            openChildForm(new fHoaDonThanhToan());

        }
        private void btn_DX_Click(object sender, EventArgs e)
        {

            this.Hide();
            fLogin fLogin = new fLogin();
            fLogin.Show();

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void fMain_Load(object sender, EventArgs e)
        {

        }
    }
}
