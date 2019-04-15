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
    public partial class Sach : Form
    {
        BindingSource SachList = new BindingSource();
        public Sach()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            dgvSach.DataSource = SachList;
            LoadListSach();
            AddBinding();
        }
        void LoadListSach()
        {
            SachList.DataSource = SachDAO.Instance.GetSACH();
            //EditDataGridView();
        }
        void AddBinding()
        {
            lblMaSach.DataBindings.Add(new Binding("Text", dgvSach.DataSource, "MASACH", true, DataSourceUpdateMode.Never));
            txtTenSach.DataBindings.Add(new Binding("Text", dgvSach.DataSource, "TENSACH", true, DataSourceUpdateMode.Never));
            txtGiaTri.DataBindings.Add(new Binding("Text", dgvSach.DataSource, "GIATRI", true, DataSourceUpdateMode.Never));
        }
       // private void EditDataGridView()
        //{
            //dgvSach.Columns["MaSach"].Visible = false;
            //dgvSach.Columns["TenSach"].HeaderText = "Tên Sách";
           // dgvSach.Columns["GiaTri"].HeaderText = "Giá Trị";          
           
       // }

            private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm");
            string str = txtSearch.Text;
            dgvSach.DataSource = SachList;
            SachList.DataSource = SachDAO.Instance.SearchSach(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn thêm sách có tên là: " + txtTenSach.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtTenSach.Text == "" || txtGiaTri.Text == "" ||  Int64.TryParse(txtGiaTri.Text, out check) == false)
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                  
                }
                else
                {
                    string tenSach = txtTenSach.Text;                  
                    string giaTri = txtGiaTri.Text;                  
                    if (SachDAO.Instance.INSERTSACH(tenSach, giaTri))
                    {
                        MessageBox.Show("Thêm sách thành công! ");
                        LoadListSach();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm sách! ");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn sửa sách có tên là: " + txtTenSach.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (lblMaSach.Text == ""||   txtTenSach.Text == "" || txtGiaTri.Text == "" ||  Int64.TryParse(txtGiaTri.Text, out check) == false)
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                }
                else
                {
                    int maSach;
                    Int32.TryParse(lblMaSach.Text, out maSach);
                    string tenSach = txtTenSach.Text;                  
                    string giaTri = txtGiaTri.Text;                  
                   
                    if (SachDAO.Instance.UPDATESACH(maSach, tenSach, giaTri))
                    {
                        MessageBox.Show("Sửa thông tin sách thành công! ");
                        LoadListSach();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa thông tin sách! ");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa sách có mã là: " + txtTenSach.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maSach;
                Int32.TryParse(lblMaSach.Text, out maSach);
                if (SachDAO.Instance.DELETESACH(maSach))
                {
                    MessageBox.Show("Xóa sách thành công! ");
                    LoadListSach();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa sách! ");
                }
            }
        }
        void Reset()
        {
            lblMaSach.Text = "";
            txtTenSach.Text = "";
            txtGiaTri.Text = "";
          
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadListSach();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Bạn có thật sự muốn hủy các thao tac vừa nhập ", "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                Reset();
            }
        }
    }
}
