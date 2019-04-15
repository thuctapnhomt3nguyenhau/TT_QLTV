using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLTV.DAO;

namespace QLTV.GUI
{
    public partial class NhanVien : Form
    {
        BindingSource NVList = new BindingSource();

        public NhanVien()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            dgvNhanVien.DataSource = NVList;
            LoadListNV();
           AddBinding();
        }
        void LoadListNV()
        {
          NVList.DataSource = NhanVienDAO.Instance.GetNV();
            //EditDataGridView();
        }
        void AddBinding()
        {
            lblMaNV.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "MANV", true, DataSourceUpdateMode.Never));
            txtHoTen.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "HOTEN", true, DataSourceUpdateMode.Never));           
            dtpNgaySinh.DataBindings.Add(new Binding("Text", dgvNhanVien.DataSource, "NGAYSINH", true, DataSourceUpdateMode.Never));
            var fmaleBinding = new Binding("Checked", dgvNhanVien.DataSource, "GIOITINH", true, DataSourceUpdateMode.Never);
           fmaleBinding.Format += (s, args) => args.Value = ((string)args.Value) == "Nữ";
           fmaleBinding.Parse += (s, args) => args.Value = (bool)args.Value ? "Nữ" : "Nam";    
            radNu.DataBindings.Add(fmaleBinding);
            radNu.CheckedChanged += (s, args) => radNam.Checked = !radNu.Checked;
        }  
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           if (txtSearch.Text == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm");
            string str = txtSearch.Text;
            dgvNhanVien.DataSource = NVList;
            NVList.DataSource = NhanVienDAO.Instance.SEARCHNV(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn thêm nhân viên có tên là: " + txtHoTen.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtHoTen.Text == "" || dtpNgaySinh.Text == ""    )
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
             
                }
                else
                {
                    string hoTen = txtHoTen.Text;
                    DateTime ngaySinh;
                    DateTime.TryParse(dtpNgaySinh.Text, out ngaySinh);
                    string gioiTinh = radNam.Checked ? "Nam" : "Nữ";                  
                     if (NhanVienDAO.Instance.INSERTNV(hoTen, ngaySinh, gioiTinh))
                    {
                        MessageBox.Show("Thêm nhân viên thành công! ");
                        LoadListNV();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm nhân viên! ");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn sửa nhân viên có tên là: " + txtHoTen.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (lblMaNV.Text == "" || txtHoTen.Text == "" || dtpNgaySinh.Text == "" )
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                }
                else
                {
                    int maNV;
                    Int32.TryParse(lblMaNV.Text, out maNV);
                    string hoTen = txtHoTen.Text;
                    DateTime ngaySinh;
                    DateTime.TryParse(dtpNgaySinh.Text, out ngaySinh);                  
                    string gioiTinh = radNam.Checked ? "Nam" : "Nữ";
                    if (NhanVienDAO.Instance.UPDATENV(maNV, hoTen, ngaySinh, gioiTinh))
                    {
                        MessageBox.Show("Sửa nhân viên thành công! ");
                        LoadListNV();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa nhân viên! ");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa nhân viên có mã là: " + txtHoTen.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maNV;
                Int32.TryParse(lblMaNV.Text, out maNV);
                if (NhanVienDAO.Instance.DELETENV(maNV))
                {
                    MessageBox.Show("Xóa nhân viên thành công! ");
                    LoadListNV();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa nhân viên! ");
                }
            }
        }
        void Reset()
        {
            lblMaNV.Text = "";
            txtHoTen.Text = "";
            dtpNgaySinh.Text = "";

        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadListNV();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có thật sự muốn hủy các thao tác vừa nhập ", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Reset();
            }
        }
    }
}

    
   
    


