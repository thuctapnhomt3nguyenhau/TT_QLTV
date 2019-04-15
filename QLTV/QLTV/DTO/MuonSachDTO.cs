using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DTO
{
    class MuonSachDTO
    {
        private int maMuon;
        private int maNV;
        private int maNM;
        private int maSach;
        private DateTime thoiGian;
        private string daTraHayChua;

        public int MaMuon { get => maMuon; set => maMuon = value; }
        public int MaNV { get => maNV; set => maNV = value; }
        public int MaNM { get => maNM; set => maNM = value; }
        public int MaSach { get => maSach; set => maSach = value; }
        public DateTime ThoiGian { get => thoiGian; set => thoiGian = value; }
        public string DaTraHayChua { get => daTraHayChua; set => daTraHayChua = value; }

        public MuonSachDTO(int maMuon,int maNV,int maNM,int maSach,DateTime thoiGian, string daTraHayChua)
        {
            this.maMuon = maMuon;
            this.maNV = maNV;
            this.maNM = maNM;
            this.maSach = maSach;
            this.thoiGian = thoiGian;
            this.daTraHayChua = daTraHayChua;
        }
        public MuonSachDTO(DataRow row)
        {
            Int32.TryParse(row["MAMUON"].ToString(), out this.maMuon);
            Int32.TryParse(row["MANV"].ToString(), out this.maNV);
            Int32.TryParse(row["MANM"].ToString(), out this.maNM);
            Int32.TryParse(row["MASACH"].ToString(), out this.maSach);
            this.thoiGian = (DateTime)row["THOIGIAN"];
            this.daTraHayChua = row["DATRAHAYCHUA"].ToString();
        }
    }
}
