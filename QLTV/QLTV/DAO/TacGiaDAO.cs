using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DTO;

namespace QLTV.DAO
{
    class TacGiaDAO
    {
        private static TacGiaDAO instance;

        internal static TacGiaDAO Instance
        {
            get { if (instance == null) instance = new TacGiaDAO(); return instance; }
            private set { instance = value; }
        }

        public List<TacGiaDTO> GetAll()
        {
            List<TacGiaDTO> list = new List<TacGiaDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SP_TacGia_GetAll");
            foreach(DataRow row in data.Rows)
            {
                list.Add(new TacGiaDTO(row));
            }
            return list;
        }

        public bool Insert(string tenTacGia)
        {
            int check = 0;
            check = DataProvider.Instance.ExecuteNonQuery("SP_TacGia_Insert @tenTacGia", new object[] { tenTacGia });
            return check != 0;
        }

        public bool Delete(int maTacGia)
        {
            int check = 0;
            check = DataProvider.Instance.ExecuteNonQuery("SP_TacGia_Delete @maTacGia", new object[] { maTacGia });
            return check != 0;
        }
           
        public bool Update(int maTacGia, string tenTacGia)
        {
            int check = 0;
            check = DataProvider.Instance.ExecuteNonQuery("SP_TacGia_Update @maTacGia , @tenTacGia", new object[] { maTacGia, tenTacGia });
            return check != 0;
        }

        public List<TacGiaDTO> Search(string searchString)
        {
            List<TacGiaDTO> list = new List<TacGiaDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SP_TacGia_Search @searchString", new object[] { searchString });
            foreach(DataRow row in data.Rows)
            {
                list.Add(new TacGiaDTO(row));
            }
            return list;
        }
    }
}
