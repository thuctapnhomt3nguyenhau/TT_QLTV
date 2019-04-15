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
    public partial class TacGia : Form
    {
        BindingSource tacGiaList = new BindingSource();

        public TacGia()
        {
            InitializeComponent();
            LoadFirstTime();
        }
        private void LoadFirstTime()
        {
            dgvTacGia.DataSource = tacGiaList;
            LoadListTacGia();
            EditDataGridView();
            BindingDataToFrom();
        }

        private void LoadListTacGia()
        {
            try
            {
                tacGiaList.DataSource = TacGiaDAO.Instance.GetAll();
            }
            catch (Exception err)
            {
                MessageBox.Show("Không tìm thấy danh sách tác giả. Vui lòng khởi động lại!");
                Console.WriteLine(err);
            }
        }

        private void EditDataGridView()
        {
            dgvTacGia.Columns["MATACGIA"].HeaderText = "Mã tác giả";
            dgvTacGia.Columns["TENTACGIA"].HeaderText = "Tên tác giả";
        }

        private void BindingDataToFrom()
        {
            txtMaTacGia.DataBindings.Add(new Binding("Text", dgvTacGia.DataSource, "MATACGIA", true, DataSourceUpdateMode.Never));
            txtTenTacGia.DataBindings.Add(new Binding("Text", dgvTacGia.DataSource, "TENTACGIA", true, DataSourceUpdateMode.Never));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenTacGia;
            try
            {
                tenTacGia = txtTenTacGia.Text;
                TacGiaDAO.Instance.Insert(tenTacGia);
                LoadListTacGia();

            }
            catch (Exception err)
            {
                Console.WriteLine(err);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int maTacGia;
            string tenTacGia;
            try
            {
                Int32.TryParse(txtMaTacGia.Text, out maTacGia);
                tenTacGia = txtTenTacGia.Text;
                TacGiaDAO.Instance.Update(maTacGia, tenTacGia);
                MessageBox.Show("Cập nhật thành công");
                LoadListTacGia();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra");
                Console.WriteLine(err);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn xóa tác giả: " + txtTenTacGia.Text, "Thông báo", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                int maTacGia;
                Int32.TryParse(txtMaTacGia.Text, out maTacGia);
                try
                {
                    TacGiaDAO.Instance.Delete(maTacGia);
                    MessageBox.Show("Xóa tác giả " + txtTenTacGia.Text + " thành công!");
                    LoadListTacGia();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                    Console.WriteLine(error);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadListTacGia();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtTenTacGia.Text = "";
            textBox2.Text = "";
            txtMaTacGia.Text = "";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchString;
            try
            {
                searchString = textBox2.Text;
                if (searchString == "") MessageBox.Show("Chưa nhập thông tin tìm kiếm");
                tacGiaList.DataSource = TacGiaDAO.Instance.Search(searchString);

            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra");
                Console.WriteLine(err);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
