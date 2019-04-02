using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class MaSach_DTO
    {
        private int maSach;

        public int MaSach { get => maSach; set => maSach = value; }

        public MaSach_DTO(int maSach)
        {
            this.maSach = maSach;
        }

        public MaSach_DTO(DataRow row)
        {
            Int32.TryParse(row["MASACH"].ToString(), out this.maSach);
        }
    }
}
