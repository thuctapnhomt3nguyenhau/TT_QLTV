using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class MANM_DTO
    {
        private int maNM;

        public int MaNM { get => maNM; set => maNM = value; }
        public MANM_DTO(int maNM)
        {
            this.maNM = maNM;
        }
        public MANM_DTO(DataRow row)
        {
            Int32.TryParse(row["MANM"].ToString(), out this.maNM);
        }
    }
}
