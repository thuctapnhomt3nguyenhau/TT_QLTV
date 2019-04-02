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

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
