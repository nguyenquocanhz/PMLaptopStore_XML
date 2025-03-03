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

namespace PMLaptopStore_XML
{
    public partial class fQuanLySanPham: Form
    {
        public fQuanLySanPham()
        {
            InitializeComponent();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }
    }
}
