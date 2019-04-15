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
    public partial class MuonSach : Form
    {
        BindingSource MSList = new BindingSource();
        public MuonSach()
        {
            InitializeComponent();
            Load();
        }
        void Load()
        {
            dgvMuonSach.DataSource = MSList;
            LoadListMS();
            LoadIntoComBoBoxMANV(cboMaNV);
            LoadIntoComBoBoxMANM(cboMaNM);
            LoadIntoComBoBoxMASACH(cboMaSach);
            AddBinding();
        }
        void LoadListMS()
        {
            MSList.DataSource = MuonSachDAO.Instance.GetMS();

        }
        void LoadIntoComBoBoxMANV(ComboBox cb)
        {
            cb.DataSource = MuonSachDAO.Instance.GetListMaNV();
            cb.DisplayMember = "MANV";
        }
        void LoadIntoComBoBoxMANM(ComboBox cb)
        {
            cb.DataSource = MuonSachDAO.Instance.GetListMaNM();
            cb.DisplayMember = "MANM";
        }
        void LoadIntoComBoBoxMASACH(ComboBox cb)
        {
            cb.DataSource = MuonSachDAO.Instance.GetListMaSach();
            cb.DisplayMember = "MASACH";
        }

        void AddBinding()
        {
            lblMaMuon.DataBindings.Add(new Binding("Text", dgvMuonSach.DataSource, "MAMUON", true, DataSourceUpdateMode.Never));
            cboMaNV.DataBindings.Add(new Binding("Text", dgvMuonSach.DataSource, "MANV", true, DataSourceUpdateMode.Never));
            cboMaNM.DataBindings.Add(new Binding("Text", dgvMuonSach.DataSource, "MANM", true, DataSourceUpdateMode.Never));
            cboMaSach.DataBindings.Add(new Binding("Text", dgvMuonSach.DataSource, "MASACH", true, DataSourceUpdateMode.Never));
            dtpThoiGian.DataBindings.Add(new Binding("Text", dgvMuonSach.DataSource, "THOIGIAN", true, DataSourceUpdateMode.Never));
            var fmaleBinding = new Binding("Checked", dgvMuonSach.DataSource, "DATRAHAYCHUA", true, DataSourceUpdateMode.Never);
            fmaleBinding.Format += (s, args) => args.Value = ((string)args.Value) == "Đã Trả";
            fmaleBinding.Parse += (s, args) => args.Value = (bool)args.Value ? "Đã Trả" : "Chưa Trả";
            radDaTra.DataBindings.Add(fmaleBinding);
            radDaTra.CheckedChanged += (s, args) => radChuaTra.Checked = !radDaTra.Checked;
        }




        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboMaNV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtSearch.Text == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm");
            string str = txtSearch.Text;
            dgvMuonSach.DataSource = MSList;
            MSList.DataSource = MuonSachDAO.Instance.SEARCHMS(str);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn thêm mã mượn sách là: " + cboMaNM.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (cboMaNV.Text == "" || cboMaNM.Text == "" || cboMaSach.Text == "" || dtpThoiGian.Text == "")
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");

                }
                else
                {
                    int maNV;
                    Int32.TryParse(cboMaNV.Text, out maNV);
                    int maNM;
                    Int32.TryParse(cboMaNM.Text, out maNM);
                    int maSach;
                    Int32.TryParse(cboMaSach.Text, out maSach);
                    DateTime thoiGian;
                    DateTime.TryParse(dtpThoiGian.Text, out thoiGian);
                    string daTraHayChua = radDaTra.Checked ? "Đã Trả" : "Chưa Trả";
                    if (MuonSachDAO.Instance.INSERTMS(maNV, maNM, maSach, thoiGian, daTraHayChua))
                    {
                        MessageBox.Show("Thêm thông tin mượn sách thành công! ");
                        LoadListMS();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi thêm thông tin mượn sách! ");
                    }
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            long check;
            if (MessageBox.Show("Bạn có thật sự muốn sửa thông tin mượn sách có tên là: " + cboMaSach.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                if (lblMaMuon.Text == "" || cboMaNV.Text == "" || cboMaNM.Text == "" || cboMaSach.Text == "" || dtpThoiGian.Text == "")
                {
                    MessageBox.Show("Sai hoặc thiếu thông tin");
                }
                else
                {
                    int maMuon;
                    Int32.TryParse(lblMaMuon.Text, out maMuon);
                    int maNV;
                    Int32.TryParse(cboMaNV.Text, out maNV);
                    int maNM;
                    Int32.TryParse(cboMaNM.Text, out maNM);
                    int maSach;
                    Int32.TryParse(cboMaSach.Text, out maSach);
                    DateTime thoiGian;
                    DateTime.TryParse(dtpThoiGian.Text, out thoiGian);
                    string daTraHayChua = radDaTra.Checked ? "Đã Trả" : "Chưa Trả";
                    if (MuonSachDAO.Instance.UPDATEMS(maMuon, maNV, maNM, maSach, thoiGian, daTraHayChua))
                    {
                        MessageBox.Show("Sửa thông tin mượn sách thành công! ");
                        LoadListMS();
                    }
                    else
                    {
                        MessageBox.Show("Có lỗi khi sửa thông tin mượn sách! ");
                    }
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa thông tin mượn sách có mã là: " + lblMaMuon.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maMuon;
                Int32.TryParse(lblMaMuon.Text, out maMuon);
                if (MuonSachDAO.Instance.DELETEMS(maMuon))
                {
                    MessageBox.Show("Xóa thông tin mượn sách thành công! ");
                    LoadListMS();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi xóa thông tin mượn sách! ");
                }
            }
        }
        void Reset()
        {
            lblMaMuon.Text = "";
            cboMaNV.Text = "";
            cboMaNM.Text = "";
            cboMaSach.Text = "";
            dtpThoiGian.Text = "";


        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            LoadListMS();
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
    
    
 
    

