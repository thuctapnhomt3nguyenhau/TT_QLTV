using QLTV.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;

        internal static NhanVienDAO Instance

        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set { instance = value; }
        }
        public List<NhanVienDTO> NVList { get; private set; }
        public List<NhanVienDTO> GetNV()
        {
            List<NhanVienDAO> list = new List<NhanVienDAO>();
            Datatable data = DataProvider.Instance.ExecuteQuery("dbo.USP_GETNV ");
            foreach (DataRow item in data.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO(item);
                list.Add(nv);
            }
            return list;
        }
        public bool INSERTNV(string hoTen, DateTime ngaySinh, string gioiTinh)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_INSERTSACH @HOTEN , @NGAYSINH , @GIOITINH ", new object[] { hoTen , ngaySinh , gioiTinh });

            return result > 0;
        }
        public bool UPDATENV(int maNV, string hoTen, DateTime ngaySinh, string gioiTinh)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_UPDATENV @MANV , @HOTEN , @NGAYSINH , @GIOITINH ", new object[] { maNV , hoTen , ngaySinh , gioiTinh });

            return result > 0;
        }
        public bool DELETENV(int maNV)
        {
            int result = DataProvider.Instance.ExecuteNonQuery(" EXEC USP_DELETENV @MASACH ", new object[] { maNV });

            return result > 0;
        }
        public List<NhanVienDTO> SEARCHNV(string str)
        {
            List<NhanVienDTO> NVList = new List<NhanVienDTO>();
            DataTable data = DataProvider.Instance.ExecuteQuery("EXEC USP_SEARCHSACH @search ", new object[] { str });
            foreach (DataRow item in data.Rows)
            {
                NhanVienDTO nv = new NhanVienDTO(item);
                NVList.Add(nv);
            }
            return NVList;
        }
    }
}
