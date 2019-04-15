using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class MANV_DTO
    {
        private int maNV;
        public int MaNV { get => maNV; set => maNV = value; }
        public MANV_DTO(int maNV)
        {
            this.maNV = maNV;
        }
        public MANV_DTO(DataRow row)
        {
            Int32.TryParse(row["MANV"].ToString(), out this.maNV);
        }

    }
}
