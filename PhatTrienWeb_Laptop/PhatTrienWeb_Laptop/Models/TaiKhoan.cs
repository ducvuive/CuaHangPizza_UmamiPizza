using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Models
{
    public class TaiKhoan
    {
        string tenDangNhap;
        string matKhau;

        public TaiKhoan(string tenDangNhap, string matKhau)
        {
            this.tenDangNhap = tenDangNhap;
            this.matKhau = matKhau;
        }

        public TaiKhoan()
        {
        }

        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
