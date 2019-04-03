using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class MATG_DTO
    {
        private int matg;
        
        public int Matg { get => matg; set => matg = value; }
        public MATG_DTO(int matg)
        {
            this.matg = matg;
        }
        public MATG_DTO(DataRow row)
        {
            Int32.TryParse(row["MATG"].ToString(), out this.matg);
        }

    }
}
