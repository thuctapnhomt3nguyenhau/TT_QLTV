using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DTO;

namespace QLTV.DAO
{
    class SangTacDAO
    {
        private static SangTacDAO instance;

        internal static SangTacDAO Instance
        {
            get { if (instance == null) instance = new SangTacDAO(); return instance; }
            private set { instance = value; }
        }
        public List<SangTacDTO> GetDSST()
        {
            List<SangTacDTO> list = new List<SangTacDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.USP_SANGTAC_GETDSST");
            foreach (DataRow item in data.Rows)
            {
                SangTacDTO sangtac = new SangTacDTO(item);
                list.Add(sangtac);
            }
            return list;
        }
        public List<MATG_DTO> GetListMaTG()
        {
            List<MATG_DTO> maTGList = new List<MATG_DTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MATG FROM dbo.TACGIA");
            foreach (DataRow item in data.Rows)
            {
                MATG_DTO matg = new MATG_DTO(item);
                maTGList.Add(matg);
            }
            return maTGList;
        }
        public List<MASACH_DTO> GetListMaSach()
        {
            List<MASACH_DTO> maSachList = new List<MASACH_DTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MASACH FROM dbo.SACH");
            foreach (DataRow item in data.Rows)
            {
                MASACH_DTO masach = new MASACH_DTO(item);
                maSachList.Add(masach);
            }
            return maSachList;
        }
        public bool InsertST(int maTG, int maSach)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_SANGTAC_INSERT @maTG ,  @maSach  ", new object[] { maTG, maSach });

            return result > 0;
        }
        public bool UpdateST(int maST, int maTG, int maSach)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_SANGTAC_UPDATE @maST , @maTG , @maSach  ", new object[] { maST, maTG, maSach });

            return result > 0;
        }
        public bool DeleteST(int maST)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_SANGTAC_DELETE @maST ", new object[] { maST });

            return result > 0;
        }
        public List<SangTacDTO> SearchST(string str)
        {
            List<SangTacDTO> SangTacList = new List<SangTacDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_SANGTAC_SEARCH @search ", new object[] { str });
            foreach (DataRow item in data.Rows)
            {
                SangTacDTO Stac = new SangTacDTO(item);
                SangTacList.Add(Stac);
            }
            return SangTacList;
        }
    }
}
