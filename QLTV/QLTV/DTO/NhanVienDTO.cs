using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class NhanVienDTO
    {
        private int maNV;
        private string hoTen;
        private DateTime ngaySinh;
        private string gioiTinh;

        public int MaNV { get => maNV; set => maNV = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }

        public NhanVienDTO( int maNV,string hoTen,DateTime ngaySinh,string gioiTinh)
        {
            this.maNV = maNV;
            this.hoTen = hoTen;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
        }
        public NhanVienDTO(DataRow row)
        {
            Int32.TryParse(row["MANV"].ToString(), out this.maNV);
            this.hoTen = row["HOTEN"].ToString();
            this.ngaySinh = (DateTime)row["NGAYSINH"];        
            this.gioiTinh = row["GIOITINH"].ToString();     
        }
    }
}
