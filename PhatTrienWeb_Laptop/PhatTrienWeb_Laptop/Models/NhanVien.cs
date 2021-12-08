using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
{
    public class NhanVien
    {
        string maNV;
        string tenDangNhap;
        string tenNV;
        DateTime ngaySinh;
        string gioiTinh;
        string chucVu;
        string diaChi;
        DateTime ngayVL;
        string soDT;
        string matKhau;
        string xacNhanMatKhau;
        public NhanVien()
        {
        }

        public NhanVien(string maNV, string tenDangNhap, string tenNV, DateTime ngaySinh, string gioiTinh, string chucVu, string diaChi, DateTime ngayVL, string soDT)
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

        [Key]
        [Display(Name = "Mã Nhân Viên")]
        [StringLength(6, ErrorMessage = "Tên đăng nhập phải dưới 6 ký tự")]
        public string MaNV { get => maNV; set => maNV = value; }
        [Required]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(10, ErrorMessage = "Tên đăng nhập phải dưới 10 ký tự")]
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        [Required]
        [Display(Name = "Tên Nhân Viên")]
        [StringLength(50, ErrorMessage = "Tên nhân viên phải dưới 50 ký tự")]
        public string TenNV { get => tenNV; set => tenNV = value; }
        [Display(Name = "Ngày Sinh")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySinh { get => ngaySinh; set => ngaySinh = value; }
        [Required]
        [Display(Name = "Giới tính")]
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        [Required]
        [Display(Name = "Chức Vụ")]
        public string ChucVu { get => chucVu; set => chucVu = value; }

        [Display(Name = "Địa chỉ")]
        [StringLength(100, ErrorMessage = "Địa chỉ phải dưới 100 ký tự")]
        public string DiaChi { get => diaChi; set => diaChi = value; }
        [Display(Name = "Ngày vào làm")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayVL { get => ngayVL; set => ngayVL = value; }
        [Phone]
        [Display(Name = "Số Điện thoại")]
        [StringLength(10, ErrorMessage = "Số điện thoại phải dưới 10 ký tự")]
        public string SoDT { get => soDT; set => soDT = value; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập vào mật khẩu")]
        [Display(Name = "Mật Khẩu")]
        [StringLength(20, ErrorMessage = "Mật khẩu phải dưới 20 ký tự")]
        public string MatKhau { get => matKhau; set => matKhau = value; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Vui lòng nhập lại mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu không trùng khớp")]
        [Display(Name = "Xác nhận mật khẩu")]
        [StringLength(20, ErrorMessage = "Mật khẩu phải dưới 20 ký tự")]
        public string XacNhanMatKhau { get => xacNhanMatKhau; set => xacNhanMatKhau = value; }
    }
}
