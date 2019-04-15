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
    
    public partial class PhanLoai : Form
    {
        BindingSource PhanLoaiList = new BindingSource();
        public PhanLoai()
        {
            InitializeComponent();
            Load();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void Load()
        {
            dgvPhanLoai.DataSource = PhanLoaiList;
            LoadListPhanLoai();
            LoadIntoComBoBoxMaSach(cbomasachPL);
            LoadIntoComBoBoxMaTheLoai(cbomatheloaiPL);
            AddBinding();
        }

        void LoadListPhanLoai()
        {
            PhanLoaiList.DataSource = PhanLoaiDAO.Instance.GetPL();
            EditDataGridViewPL();
        }

        void LoadIntoComBoBoxMaSach(ComboBox cb)
        {
            cb.DataSource = PhanLoaiDAO.Instance.GetListMaSach();
            cb.DisplayMember = "MASACH";
        }

        void LoadIntoComBoBoxMaTheLoai(ComboBox cb)
        {
            cb.DataSource = PhanLoaiDAO.Instance.GetListMaTheLoai();
            cb.DisplayMember = "MATHELOAI";
        }

        void AddBinding()
        {
            lblmaphanloai.DataBindings.Add(new Binding("Text", dgvPhanLoai.DataSource, "maPL", true, DataSourceUpdateMode.Never));
            txtkieuphanloai.DataBindings.Add(new Binding("Text", dgvPhanLoai.DataSource, "kieuPL", true, DataSourceUpdateMode.Never));
            cbomasachPL.DataBindings.Add(new Binding("Text", dgvPhanLoai.DataSource, "maSach", true, DataSourceUpdateMode.Never));
            cbomatheloaiPL.DataBindings.Add(new Binding("Text", dgvPhanLoai.DataSource, "maTheLoai", true, DataSourceUpdateMode.Never));
        }

        void EditDataGridViewPL()
        {
            dgvPhanLoai.Columns["maSach"].Visible = false;
            dgvPhanLoai.Columns["MASACH"].HeaderText = "Mã Sách";

            dgvPhanLoai.Columns["maTheLoai"].Visible = false;
            dgvPhanLoai.Columns["MATHELOAI"].HeaderText = "Mã Thể Loại Sách";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn thêm cách phân loại mới đó là: " + txtkieuphanloai.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtkieuphanloai.Text == "" || cbomasachPL.Text == "" || cbomatheloaiPL.Text == "")
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                    //                    LoadListNV();
                }
                else
                {
                    string kieuPL = txtkieuphanloai.Text;
                    int maSach;
                    Int32.TryParse(cbomasachPL.Text, out maSach);
                    int maTheLoai;
                    Int32.TryParse(cbomatheloaiPL.Text, out maTheLoai);
                    if (PhanLoaiDAO.Instance.InsertPL(kieuPL, maSach, maTheLoai))
                    {
                        MessageBox.Show("Thêm thông tin phân loại thành công! ");
                        LoadListPhanLoai();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm thông tin phân loại! ");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn sửa cách phân loại có tên là: " + txtkieuphanloai.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (txtkieuphanloai.Text == "" || cbomasachPL.Text == "" || cbomatheloaiPL.Text == "")
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                }
                else
                {
                    string kieuPL = txtkieuphanloai.Text;
                    int maSach;
                    Int32.TryParse(cbomasachPL.Text, out maSach);
                    int maTheLoai;
                    Int32.TryParse(cbomatheloaiPL.Text, out maTheLoai);
                    int maPL;
                    Int32.TryParse(lblmaphanloai.Text, out maPL);
                    if (PhanLoaiDAO.Instance.UpdatePL(kieuPL, maSach, maTheLoai, maPL))
                    {
                        MessageBox.Show("Sửa thông tin phân loại thành công! ");
                        LoadListPhanLoai();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa thông tin phân loại! ");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa kiểu phân loại có tên là: " + txtkieuphanloai.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maPL;
                Int32.TryParse(lblmaphanloai.Text, out maPL);

                if (PhanLoaiDAO.Instance.DeletePL(maPL))
                {
                    MessageBox.Show("Xóa thông tin về kiểu phân loại thành công! ");
                    LoadListPhanLoai();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa thông tin kiểu phân loại đó! ");
                }
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadListPhanLoai();
        }

        void Reset()
        {
            lblmaphanloai.Text = "";
            txtkieuphanloai.Text = "";
            LoadIntoComBoBoxMaSach(cbomasachPL);
            LoadIntoComBoBoxMaTheLoai(cbomatheloaiPL);
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
            dgvPhanLoai.DataSource = PhanLoaiList;
            PhanLoaiList.DataSource = PhanLoaiDAO.Instance.SearchPL(str);
        }
    }
}
