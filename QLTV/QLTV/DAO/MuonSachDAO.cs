using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DAO
{
    class MuonSachDAO
    {

        private static MuonSachDAO instance;

        internal static MuonSachDAO Instance
        {
            get { if (instance == null) instance = new MuonSachDAO(); return instance; }
            private set { instance = value; }
        }
        public List<MuonSachDTO> GetMS()
        {
            List<MuonSachDTO> list = new List<MuonSachDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.USP_GETMS");
            foreach (DataRow item in data.Rows)
            {
                MuonSachDTO ms = new MuonSachDTO(item);
                list.Add(ms);
            }
            return list;
        }
        public List<MANV_DTO> GetListMaNV()
        {
            List<MANV_DTO> maNVList = new List<MANV_DTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MANV FROM NHANVIEN");
            foreach (DataRow item in data.Rows)
            {
                MANV_DTO maNV = new MANV_DTO(item);
                maNVList.Add(maNV);
            }
            return maNVList;
        }
        public List<MANM_DTO> GetListMaNM()
        {
            List<MANM_DTO> maNMList = new List<MANM_DTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MANM FROM NGUOIMUON");
            foreach (DataRow item in data.Rows)
            {
                MANM_DTO maNM = new MANM_DTO(item);
                maNMList.Add(maNM);
            }
            return maNMList;
        }
        public List<MASACH_DTO> GetListMaSach()
        {
            List<MASACH_DTO> maSachList = new List<MASACH_DTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MASACH FROM SACH");
            foreach (DataRow item in data.Rows)
            {
                MASACH_DTO maSach = new MASACH_DTO(item);
                maSachList.Add(maSach);
            }
            return maSachList;
        }
        public bool INSERTMS(int maNV, int maNM,int maSach,DateTime thoiGian,string daTraHayChua)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_INSERTMS @MANV , @MANM , @MASACH , @THOIGIAN , @DATRAHAYCHUA  ", new object[] { maNV , maNM, maSach, thoiGian, daTraHayChua });

            return result > 0;
        }
        public bool UPDATEMS(int maMuon, int maNV, int maNM, int maSach, DateTime thoiGian, string daTraHayChua)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_UPDATEMS @MAMUON , @MANV , @MANM , @MASACH , @THOIGIAN , @DATRAHAYCHUA ", new object[] { maMuon, maNV, maNM, maSach, thoiGian, daTraHayChua });

            return result > 0;
        }
        public bool DELETEMS(int maMuon)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_DELETEMS @MAMUON ", new object[] { maMuon });

            return result > 0;
        }
        public List<MuonSachDTO> SEARCHMS(string str)
        {
            List<MuonSachDTO> MSList = new List<MuonSachDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_SEARCHMS @search ", new object[] { str });
            foreach (DataRow item in data.Rows)
            {
                MuonSachDTO ms = new MuonSachDTO(item);
                MSList.Add(ms);
            }
            return MSList;
        }
    }
}
