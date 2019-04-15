using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLTV.DTO;

namespace QLTV.DAO
{
    class PhanLoaiDAO
    {
        private static PhanLoaiDAO instance;

        internal static PhanLoaiDAO Instance
        {
            get { if (instance == null) instance = new PhanLoaiDAO(); return instance; }
            private set { instance = value; }
        }

        public List<PhanLoaiDTO> GetPL()
        {
            List<PhanLoaiDTO> listPhanLoai = new List<PhanLoaiDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("dbo.PHANLOAI_GETALL");
            foreach (DataRow item in data.Rows)
            {
                PhanLoaiDTO phanloai = new PhanLoaiDTO(item);
                listPhanLoai.Add(phanloai);
            }
            return listPhanLoai;
        }

        public List<MaSach_DTO> GetListMaSach()
        {
            List<MaSach_DTO> listMaSach = new List<MaSach_DTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MASACH FROM dbo.SACH");
            foreach (DataRow item in data.Rows)
            {
                MaSach_DTO maSach = new MaSach_DTO(item);
                listMaSach.Add(maSach);
            }
            return listMaSach;
        }

        public List<MaTheLoai_DTO> GetListMaTheLoai()
        {
            List<MaTheLoai_DTO> listMaTheLoai = new List<MaTheLoai_DTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT MATHELOAI FROM dbo.THELOAI");
            foreach (DataRow item in data.Rows)
            {
                MaTheLoai_DTO maTheLoai = new MaTheLoai_DTO(item);
                listMaTheLoai.Add(maTheLoai);
            }
            return listMaTheLoai;
        }

        public bool InsertPL(string KIEUPL, int MASACH, int MATHELOAI)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC SP_PHANLOAI_INSERT @KIEUPL , @MASACH , @MATHELOAI ", new object[] { KIEUPL , MASACH , MATHELOAI });

            return result > 0;
        }

        public bool UpdatePL(string KIEUPL, int MASACH, int MATHELOAI, int MAPL)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC SP_PHANLOAI_UPDATE @MAPL , @KIEUPL , @MASACH , @MATHELOAI ", new object[] { MAPL , KIEUPL , MASACH , MATHELOAI });

            return result > 0;
        }

        public bool DeletePL(int MAPL)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC SP_PHANLOAI_DELETE @MAPL", new object[] { MAPL });

            return result > 0;
        }

        public List<PhanLoaiDTO> SearchPL(string str)
        {
            List<PhanLoaiDTO> PhanLoaiList = new List<PhanLoaiDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC SP_PHANLOAI_SEARCH @SEARCHVALUE ", new object[] { str });
            foreach (DataRow item in data.Rows)
            {
                PhanLoaiDTO PhanLoai = new PhanLoaiDTO(item);
                PhanLoaiList.Add(PhanLoai);
            }
            return PhanLoaiList;
        }
    }
}
