using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class SachDTO
    {
        private int maSach;
        private string tenSach;
        private string giaTri;

        public int MaSach { get => maSach; set => maSach = value; }
        public string TenSach { get => tenSach; set => tenSach = value; }
        public string GiaTri { get => giaTri; set => giaTri = value; }
        public SachDTO(int maSach, string tenSach, string giaTri)
        {
            this.maSach = maSach;
            this.tenSach = tenSach;
            this.giaTri = giaTri;
        }
        public SachDTO(DataRow row)
        {
            Int32.TryParse(row["MASACH"].ToString(), out this.maSach);
            this.tenSach = row["TENSACH"].ToString();
            this.giaTri = row["GIATRI"].ToString();
        }
    }
}
