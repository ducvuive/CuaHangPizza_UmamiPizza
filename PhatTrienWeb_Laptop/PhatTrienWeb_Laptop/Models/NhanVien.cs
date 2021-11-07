using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Models
{
    public class NhanVien
    {
        string maNV;
        string tenDangNhap;
        string tenNV;
        string ngaySinh;
        string gioiTinh;
        string chucVu;
        string diaChi;
        string ngayVL;
        string soDT;

        public NhanVien()
        {
        }

        public NhanVien(string maNV, string tenDangNhap, string tenNV, string ngaySinh, string gioiTinh, string chucVu, string diaChi, string ngayVL, string soDT)
        {
            this.maNV = maNV;
            this.tenDangNhap = tenDangNhap;
            this.tenNV = tenNV;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.chucVu = chucVu;
            this.diaChi = diaChi;
            this.ngayVL = ngayVL;
            this.soDT = soDT;
        }

        public string MaNV { get => maNV; set => maNV = value; }
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        public string TenNV { get => tenNV; set => tenNV = value; }
        public string NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public string NgayVL { get => ngayVL; set => ngayVL = value; }
        public string SoDT { get => soDT; set => soDT = value; }

    }
}
