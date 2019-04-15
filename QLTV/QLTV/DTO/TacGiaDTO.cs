using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class TacGiaDTO
    {
        private int maTacGia;
        private string tenTacGia;

        public int MaTacGia { get => maTacGia; set => maTacGia = value; }
        public string TenTacGia { get => tenTacGia; set => tenTacGia = value; }


        public TacGiaDTO() { }

        public TacGiaDTO(DataRow row)
        {
            Int32.TryParse(row["MATG"].ToString(), out this.maTacGia);
            this.tenTacGia = row["TENTG"].ToString();
        }

        public TacGiaDTO(int maTacGia, string tenTacGia)
        {
            this.maTacGia = maTacGia;
            this.tenTacGia = tenTacGia;
        }
    }
}
