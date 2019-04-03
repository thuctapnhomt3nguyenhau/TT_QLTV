using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class SangTacDTO
    {
        private int maST;
        private int maTG;
        private int maSach;

        public int MaST { get => maST; set => maST = value; }
        public int MaTG { get => maTG; set => maTG = value; }
        public int MaSach { get => maSach; set => maSach = value; }

        public SangTacDTO( int maST , int maTG ,int maSach)
        {
            this.maST = maST;
            this.maTG = maTG;
            this.maSach = maSach;
        }
        public SangTacDTO( DataRow row)
        {
            Int32.TryParse(row["MASANGTAC"].ToString(), out maST);
            Int32.TryParse(row["MATG"].ToString(), out maTG);
            Int32.TryParse(row["MASACH"].ToString(), out maSach);
        }
    }
}
