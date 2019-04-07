using QLTV.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV.GUI
{
    public partial class NguoiMuon : Form
    {
        BindingSource NguoiMuonList = new BindingSource();
        public NguoiMuon()
        {
            InitializeComponent();
            Load();
        }

        void Load()
        {
            dgvNguoiMuon.DataSource = NguoiMuonList;
            LoadListNguoiMuon();
            AddBinding();
            radNam.Checked = true;
        }
        void LoadListNguoiMuon()
        {
            NguoiMuonList.DataSource=NguoiMuonDAO.Instance.GetNguoiMuon();
            EditDataGridView();
        }

        void AddBinding()
        {
            lblMaNM.DataBindings.Add(new Binding("Text", dgvNguoiMuon.DataSource, "MANM", true, DataSourceUpdateMode.Never));
            txtHoTen.DataBindings.Add(new Binding("Text", dgvNguoiMuon.DataSource, "TENNM", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvNguoiMuon.DataSource, "DIACHI", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dgvNguoiMuon.DataSource, "SDT", true, DataSourceUpdateMode.Never));
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dgvNguoiMuon.DataSource, "NGAYSINH", true, DataSourceUpdateMode.Never));
            var fmaleBinding = new Binding("Checked", dgvNguoiMuon.DataSource, "GIOITINH", true, DataSourceUpdateMode.Never);
            // when Formatting (reading from datasource), return true for Female, else false
            fmaleBinding.Format += (s, args) => args.Value = ((string)args.Value) == "Nữ";
            // when Parsing (writing to datasource), return "Male" for true, else "Fmale"
            fmaleBinding.Parse += (s, args) => args.Value = (bool)args.Value ? "Nữ" : "Nam";
            // add the binding
            radNu.DataBindings.Add(fmaleBinding);

            // you don't need to bind the Male radiobutton, just make it do the opposite
            // of Male by handling the CheckedChanged event on Male:
            radNu.CheckedChanged += (s, args) => radNam.Checked = !radNu.Checked;

        }
        void EditDataGridView()
        {
            dgvNguoiMuon.Columns["MaNM"].Visible = false;
            dgvNguoiMuon.Columns["TenNM"].HeaderText = "Họ Tên";
            dgvNguoiMuon.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvNguoiMuon.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvNguoiMuon.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvNguoiMuon.Columns["SDT"].HeaderText = "Số điện thoại";
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn thêm người mượn có tên là: " + txtHoTen.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || Int64.TryParse(txtSDT.Text, out check) == false)
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                }
                else
                {
                    string hoTen = txtHoTen.Text;
                    DateTime ngaySinh;
                    DateTime.TryParse(dtpNgaySinh.Text, out ngaySinh);
                    string diaChi = txtDiaChi.Text;
                    string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
                    string sDT = txtSDT.Text; ;
                    if (NguoiMuonDAO.Instance.InsertNguoiMuon(hoTen, ngaySinh, gioiTinh, diaChi, sDT))
                    {
                        MessageBox.Show("Thêm thông tin thành công! ");
                        LoadListNguoiMuon();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm thông tin! ");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn sửa người mượn có tên là: " + txtHoTen.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtHoTen.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || Int64.TryParse(txtSDT.Text, out check) == false)
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                }
                else
                {
                    int maNM;
                    Int32.TryParse(lblMaNM.Text, out maNM);
                    string hoTen = txtHoTen.Text;
                    DateTime ngaySinh;
                    DateTime.TryParse(dtpNgaySinh.Text, out ngaySinh);
                    string diaChi = txtDiaChi.Text;
                    string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
                    string sDT = txtSDT.Text; ;
                    if (NguoiMuonDAO.Instance.UpdateNguoiMuon(maNM,hoTen, ngaySinh, gioiTinh, diaChi, sDT))
                    {
                        MessageBox.Show("Sửa thông tin thành công! ");
                        LoadListNguoiMuon();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa thông tin! ");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa người mượn có tên là: " + txtHoTen.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maNM;
                Int32.TryParse(lblMaNM.Text, out maNM);
                if (NguoiMuonDAO.Instance.DeleteNguoiMuon(maNM))
                {
                    MessageBox.Show("Xóa người mượn thành công! ");
                    LoadListNguoiMuon();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa người mượn! ");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadListNguoiMuon();
        }
        void Reset()
        {
            lblMaNM.Text = "";
            txtHoTen.Text = "";
            txtDiaChi.Text = "";
            dtpNgaySinh.Value = DateTime.Now;
            txtSDT.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn hủy các thao tac vừa nhập ", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Reset();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm");
            string str = txtSearch.Text;
            dgvNguoiMuon.DataSource = NguoiMuonList;
            NguoiMuonList.DataSource = NguoiMuonDAO.Instance.SearchNguoiMuon(str);
        }
    }
}
