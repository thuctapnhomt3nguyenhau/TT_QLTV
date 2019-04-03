using System;
using System.Data;
using QLTV.DAO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTV.GUI
{
    public partial class SangTac : Form
    {
        BindingSource SangTacList = new BindingSource();

        public SangTac()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            dgvSangTac.DataSource = SangTacList;
            LoadListSangTac();
            AddBinding();
            LoadIntoComBoBoxTG(cboMaTG);
            LoadIntoComBoBoxSA(cboMasach);
        }
        void LoadListSangTac()
        {
            SangTacList.DataSource = SangTacDAO.Instance.GetDSST();
            
        }
        void LoadIntoComBoBoxTG(ComboBox cb)
        {
            cb.DataSource = SangTacDAO.Instance.GetListMaTG();
            cb.DisplayMember = "MATG";
        }
        void LoadIntoComBoBoxSA(ComboBox cb)
        {
            cb.DataSource = SangTacDAO.Instance.GetListMaSach();
            cb.DisplayMember = "MASACH";
        }
        void AddBinding()
        {
            lblMasangtac.DataBindings.Add(new Binding("Text", dgvSangTac.DataSource, "MAST", true, DataSourceUpdateMode.Never));
            cboMaTG.DataBindings.Add(new Binding("Text", dgvSangTac.DataSource, "MATG", true, DataSourceUpdateMode.Never));
            cboMasach.DataBindings.Add(new Binding("Text", dgvSangTac.DataSource, "MASACH", true, DataSourceUpdateMode.Never));
            
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            double check;
            if (MessageBox.Show("Bạn có thật sự muốn thêm một sáng tác có mã tác giả là: " + lblMasangtac.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cboMaTG.Text =="" || cboMasach.Text == "" )
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                    
                }
                else
                {

                    int maTG;
                    Int32.TryParse(cboMaTG.Text, out maTG);
                    int maSach;
                    Int32.TryParse(cboMasach.Text, out maSach);
                    if (SangTacDAO.Instance.InsertST( maTG,  maSach))
                    {
                        MessageBox.Show("Thêm thông tin thành công! ");
                        LoadListSangTac();
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
            double check;
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin sáng tác có mã là: " + lblMasangtac.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cboMaTG.Text == "" || cboMasach.Text == "" )
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                    
                }
                else
                {
                    int maST;
                    int.TryParse(lblMasangtac.Text, out maST);
                    int maTG;
                    Int32.TryParse(cboMaTG.Text, out maTG);
                    int maSach;
                    Int32.TryParse(cboMasach.Text, out maSach);
                    if (SangTacDAO.Instance.UpdateST(maST, maTG, maSach))
                    {
                        MessageBox.Show("Sửa thông tin thành công! ");
                        LoadListSangTac();
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
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin sáng tác có mã là: " + lblMasangtac.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maST;
                Int32.TryParse(lblMasangtac.Text, out maST);
                if (SangTacDAO.Instance.DeleteST(maST))
                {
                    MessageBox.Show("Xóa thông tin thành công! ");
                    LoadListSangTac();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa thông tin! ");
                }
            }
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadListSangTac();
        }
        void Reset()
        {
            lblMasangtac.Text = "";
            LoadIntoComBoBoxTG(cboMaTG);
            LoadIntoComBoBoxSA(cboMasach);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Reset();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm");
            string str = txtSearch.Text;
            dgvSangTac.DataSource = SangTacList;
            SangTacList.DataSource = SangTacDAO.Instance.SearchST(str);
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
