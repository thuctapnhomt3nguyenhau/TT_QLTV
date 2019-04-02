using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class MaTheLoai_DTO
    {
        private int maTheLoai;

        public int MaTheLoai { get => maTheLoai; set => maTheLoai = value; }

        public MaTheLoai_DTO(int maTheLoai)
        {
            this.maTheLoai = maTheLoai;
        }

        public MaTheLoai_DTO(DataRow row)
        {
            Int32.TryParse(row["MATHELOAI"].ToString(), out this.maTheLoai);
        }
    }
}
