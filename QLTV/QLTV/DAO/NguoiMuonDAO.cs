using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DAO
{
    class NguoiMuonDAO
    {
        private static NguoiMuonDAO instance;

        internal static NguoiMuonDAO Instance
        {
            get { if (instance == null) instance = new NguoiMuonDAO(); return instance; }
            private set { instance = value; }
        }
        public List<NguoiMuonDTO> GetNguoiMuon()
        {
            List<NguoiMuonDTO> list = new List<NguoiMuonDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.USP_GetNguoiMuon");
            foreach (DataRow item in data.Rows)
            {
                NguoiMuonDTO nm = new NguoiMuonDTO(item);
                list.Add(nm);
            }
            return list;
        }
        public bool InsertNguoiMuon(string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sdt )
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC dbo.USP_InsertNguoiMuon @hoten , @ngaysinh , @gioitinh , @diachi , @sdt ", new object[] { hoten, ngaysinh, gioitinh, diachi, sdt });

            return result > 0;
        }
        public bool UpdateNguoiMuon(int manm,string hoten, DateTime ngaysinh, string gioitinh, string diachi, string sdt)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC dbo.USP_UpdateNguoiMuon @manm , @hoten , @ngaysinh , @gioitinh , @diachi , @sdt ", new object[] { manm, hoten, ngaysinh, gioitinh, diachi, sdt });

            return result > 0;
        }
        public bool DeleteNguoiMuon(int manm)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC dbo.USP_DeleteNguoiMuon @manm ", new object[] { manm });

            return result > 0;
        }
        public List<NguoiMuonDTO> SearchNguoiMuon(string str)
        {
            List<NguoiMuonDTO> NguoiMuonList = new List<NguoiMuonDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_SearchNguoiMuon @search ", new object[] { str });
            foreach (DataRow item in data.Rows)
            {
                NguoiMuonDTO nguoimuon = new NguoiMuonDTO(item);
                NguoiMuonList.Add(nguoimuon);
            }
            return NguoiMuonList;
        }
    }
}
