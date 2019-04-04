using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class TheLoaiDTO
    {
        private int maTheLoai;
        private string tenTheLoai;

        public int MaTheLoai { get => this.maTheLoai; set => this.maTheLoai = value; }
        public string TenTheLoai { get => this.tenTheLoai; set => this.tenTheLoai = value; }

        public TheLoaiDTO() { }

        public TheLoaiDTO(int maTheLoai, string tenTheLoai)
        {
            this.maTheLoai = maTheLoai;
            this.tenTheLoai = tenTheLoai;
        }

        public TheLoaiDTO(DataRow row)
        {
            Int32.TryParse(row["MATHELOAI"].ToString(), out this.maTheLoai);
            this.tenTheLoai = row["TENTHELOAI"].ToString();

        }

    }
}
