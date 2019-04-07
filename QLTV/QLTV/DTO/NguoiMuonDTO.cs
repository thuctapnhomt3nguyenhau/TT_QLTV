using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class NguoiMuonDTO
    {
        private int maNM;
        private string tenNM;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string diaChi;
        private string sDT;

        public int MaNM { get => maNM; set => maNM = value; }
        public string TenNM { get => tenNM; set => tenNM = value; }
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string SDT { get => sDT; set => sDT = value; }

        public NguoiMuonDTO(int maNM, string tenNM, DateTime ngaySinh, string gioiTinh, string diaChi, string sDT)
        {
            this.maNM = maNM;
            this.tenNM = tenNM;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.sDT = sDT;
        }

        public NguoiMuonDTO(DataRow row)
        {
            Int32.TryParse(row["MANM"].ToString(), out maNM);
            this.tenNM = row["HOTEN"].ToString();
            DateTime.TryParse(row["NS"].ToString(), out ngaySinh);
            this.gioiTinh = row["GT"].ToString();
            this.diaChi = row["DC"].ToString();
            this.sDT = row["SDT"].ToString();
        }
    }
}
