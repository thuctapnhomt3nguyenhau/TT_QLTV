using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTV.GUI;
namespace QLTV.GUI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
     
        private void btnMuonSach_Click(object sender, EventArgs e)
        {
            MuonSach f = new MuonSach();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void btnNguoiMuon_Click(object sender, EventArgs e)
        {
            NguoiMuon f = new NguoiMuon();
            this.Hide();
            f.ShowDialog();
            this.Show();

        }

        private void btnTheLoai1_Click(object sender, EventArgs e)
        {
            TheLoai f = new TheLoai();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void btnSach_Click(object sender, EventArgs e)
        {
            Sach f = new Sach();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien f = new NhanVien();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void btnPhanLoai_Click(object sender, EventArgs e)
        {
            PhanLoai f = new PhanLoai();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void btnTacGia_Click(object sender, EventArgs e)
        {
            TacGia f = new TacGia();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
        private void btnSangTac_Click(object sender, EventArgs e)
        {
            SangTac f = new SangTac();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }
    }
}
