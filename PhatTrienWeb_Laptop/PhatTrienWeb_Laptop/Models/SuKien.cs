using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Models
{
    public class SuKien
    {
        string maSK;
        string tenSK;
        int phanTramGiamGia;
        DateTime ngayBD;
        DateTime ngayKT;

        public SuKien(string maSK, string tenSK, int phanTramGiamGia, DateTime ngayBD, DateTime ngayKT)
        {
            this.maSK = maSK;
            this.tenSK = tenSK;
            this.phanTramGiamGia = phanTramGiamGia;
            this.ngayBD = ngayBD;
            this.ngayKT = ngayKT;
        }

        public string MaSK { get => maSK; set => maSK = value; }
        public string TenSK { get => tenSK; set => tenSK = value; }
        public int PhanTramGiamGia { get => phanTramGiamGia; set => phanTramGiamGia = value; }
        public DateTime NgayBD { get => ngayBD; set => ngayBD = value; }
        public DateTime NgayKT { get => ngayKT; set => ngayKT = value; }
    }
}
