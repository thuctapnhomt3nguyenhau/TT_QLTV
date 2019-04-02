using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DAO
{
    class SachDAO
    {
        private static SachDAO instance;

        internal static SachDAO Instance
        {
            get { if (instance == null) instance = new SachDAO(); return instance; }
            private set { instance = value; }
        }

        public List<SachDTO> SachList { get; private set; }

        public List<SachDTO> GetSACH()
        {
            List<SachDTO> list = new List<SachDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.USP_GETSACH ");
            foreach (DataRow item in data.Rows)
            {
                SachDTO s = new SachDTO(item);
                list.Add(s);
            }
            return list;
        }

        

        public bool INSERTSACH( string tenSach, string giaTri)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_INSERTSACH @TENSACH , @GIATRI ", new object[] { tenSach , giaTri });

            return result > 0;
        }
        public bool UPDATESACH(int maSach, string tenSach, string giaTri)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_UPDATESACH @MASACH , @TENSACH , @GIATRI ", new object[] { maSach , tenSach , giaTri });

            return result > 0;
        }
        public bool DELETESACH(int maSach)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_DELETESACH @MASACH ", new object[] { maSach });

            return result > 0;
        }
        public List<SachDTO> SearchSach(string str)
        {
            List<SachDTO> SachList = new List<SachDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_SEARCHSACH @search ", new object[] { str });
            foreach (DataRow item in data.Rows)
            {
                SachDTO sach = new SachDTO(item);
                SachList.Add(sach);
            }
            return SachList;
        }
    }

}

