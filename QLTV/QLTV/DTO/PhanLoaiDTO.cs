using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class PhanLoaiDTO
    {
        private int maPL;
        private string kieuPL;
        private int maSach;
        private string tenSach;
        private int maTheLoai;
        private string tenTheLoai;

        public int MaPL { get => maPL; set => maPL = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public int MaTheLoai { get => maTheLoai; set => maTheLoai = value; }
        public string KieuPL { get => kieuPL; set => kieuPL = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string TenTheLoai { get => tenTheLoai; set => tenTheLoai = value; }

        public PhanLoaiDTO(int maPL, string kieuPL, int maSach, string tenSach, int maTheLoai, string tenTheLoai)
        {
            this.maPL = maPL;
            this.kieuPL = kieuPL;
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.maTheLoai = maTheLoai;
            this.tenTheLoai = tenTheLoai;
        }

        public PhanLoaiDTO(DataRow row)
        {
            Int32.TryParse(row["MAPL"].ToString(), out this.maPL);
            this.kieuPL = row["KIEUPL"].ToString();
            Int32.TryParse(row["MASACH"].ToString(), out this.maSach);
            this.tenSach = row["TENSACH"].ToString();
            Int32.TryParse(row["MATHELOAI"].ToString(), out this.maTheLoai);
            this.tenTheLoai = row["TENTHELOAI"].ToString();
        }
    }
}
