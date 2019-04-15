using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DAO;
using System.Data;

namespace QLTV.DAO
{
    class TheLoaiDAO
    {
        private static TheLoaiDAO instance;

        internal static TheLoaiDAO Instance
        {
            get { if (instance == null) instance = new TheLoaiDAO(); return instance; }
            private set { instance = value; }
        }

        public List<TheLoaiDTO> GetAll()
        {
            List<TheLoaiDTO> list = new List<TheLoaiDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SP_TheLoai_GetAll");
            foreach(DataRow row in data.Rows)
            {
                list.Add(new TheLoaiDTO(row));
            }
            return list;
        }

        public bool Insert(string tenTheLoai)
        {
            int check = 0;
            check = DataProvider.Instance.ExecuteNonQuery("SP_TheLoai_Insert @tenTheLoai", new object[] { tenTheLoai });
            return check != 0;
        }

        public bool Delete(int maTheLoai)
        {
            int check = 0;
            check = DataProvider.Instance.ExecuteNonQuery("SP_TheLoai_Delete @maTheLoai", new object[] { maTheLoai });
            return check != 0;
        }

        public bool Update(int maTheLoai, string tenTheLoai)
        {
            int check = 0;
            check = DataProvider.Instance.ExecuteNonQuery("SP_TheLoai_Update @maTheLoai , @tenTheLoai", new object[] { maTheLoai, tenTheLoai});
            return check != 0;
        }

        public List<TheLoaiDTO> Search(string searchString)
        {
            List<TheLoaiDTO> list = new List<TheLoaiDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SP_TheLoai_Search @searchString", new object[] { searchString });
            foreach(DataRow row in data.Rows)
            {
                list.Add(new TheLoaiDTO(row));
            }
            return list;
        }
    }
}
