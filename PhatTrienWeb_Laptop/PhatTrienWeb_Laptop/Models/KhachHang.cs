using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Models
{
    public class KhachHang
    {
        string maKH;
        string tenKH;
        string soDT;
        string email;
        string gioiTinh;

        public KhachHang() { }
        public KhachHang(string maKH, string tenKH, string soDT, string email, string gioiTinh)
        {
            this.MaKH = maKH;
            this.TenKH = tenKH;
            this.SoDT = soDT;
            this.Email = email;
            this.GioiTinh = gioiTinh;
        }

        public string MaKH { get => maKH; set => maKH = value; }
        public string TenKH { get => tenKH; set => tenKH = value; }
        public string SoDT { get => soDT; set => soDT = value; }
        public string Email { get => email; set => email = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
    }
}
