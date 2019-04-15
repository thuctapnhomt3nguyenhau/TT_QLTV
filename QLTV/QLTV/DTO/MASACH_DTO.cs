using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class MASACH_DTO
    {
        private int maSach;    

        public int MaSach { get => maSach; set => maSach = value; }
      
        public MASACH_DTO(int maSach, string tenSach)
        {
            this.maSach = maSach;           
        }
        public MASACH_DTO(DataRow row)
        {
            Int32.TryParse(row["MASACH"].ToString(), out this.maSach);
      
        }
        public MASACH_DTO() { }
    }
}
