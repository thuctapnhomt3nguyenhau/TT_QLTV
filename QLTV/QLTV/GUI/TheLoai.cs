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
    public partial class TheLoai : Form
    {
        BindingSource theLoaiList = new BindingSource();
        public TheLoai()
        {
            InitializeComponent();
            LoadFirstTime();
        }

        private void LoadFirstTime()
        {
            dgvTheLoai.DataSource = theLoaiList;
            LoadListTheLoai();
            EditDataGridView();
            BindingDataToFrom();
        }

        private void LoadListTheLoai()
        {
            try
            {
                theLoaiList.DataSource = TheLoaiDAO.Instance.GetAll();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra");
                Console.WriteLine(err);
            }
        }

        private void EditDataGridView()
        {
            dgvTheLoai.Columns["MATHELOAI"].HeaderText = "Mã thể loại";
            dgvTheLoai.Columns["TENTHELOAI"].HeaderText = "Tên thể loại";
           
        }

        private void BindingDataToFrom()
        {
            txtMaTheLoai.DataBindings.Add(new Binding("Text", dgvTheLoai.DataSource, "MATHELOAI", true, DataSourceUpdateMode.Never));
            txtTenTheLoai.DataBindings.Add(new Binding("Text", dgvTheLoai.DataSource, "TENTHELOAI", true, DataSourceUpdateMode.Never));

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenTheLoai;
            try
            {
                tenTheLoai = txtTenTheLoai.Text;
                TheLoaiDAO.Instance.Insert(tenTheLoai);
                LoadListTheLoai();

            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra");
                Console.WriteLine(err);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maTheLoai;
            string tenTheLoai;
            try
            {
                Int32.TryParse(txtMaTheLoai.Text, out maTheLoai);
                tenTheLoai = txtTenTheLoai.Text;
                TheLoaiDAO.Instance.Update(maTheLoai, tenTheLoai);
                MessageBox.Show("Cập nhật thành công");
                LoadListTheLoai();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra");
                Console.WriteLine(err);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
        
            if (MessageBox.Show("Bạn có thật sự muốn xóa thể loại: " + txtTenTheLoai.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maTheLoai;
                Int32.TryParse(txtMaTheLoai.Text, out maTheLoai);
                try
                {
                    TheLoaiDAO.Instance.Delete(maTheLoai);
                    MessageBox.Show("Xóa thể loại "+ txtTenTheLoai.Text + " thành công!");
                    LoadListTheLoai();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                    Console.WriteLine(error);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadListTheLoai();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString;
            try
            {
                searchString = txtSearch.Text;
                if (searchString == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm");
                theLoaiList.DataSource = TheLoaiDAO.Instance.Search(searchString);

            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra");
                Console.WriteLine(err);
            }
        }
    }
}
