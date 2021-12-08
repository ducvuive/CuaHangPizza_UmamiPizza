using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
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

        [Key]
        [Required(ErrorMessage = "Trường này không được trống")]
        [Display(Name = "Tên đăng nhập")]
        [StringLength(10, ErrorMessage = "Tên đăng nhập phải dưới 10 ký tự")]
        public string TenDangNhap { get => tenDangNhap; set => tenDangNhap = value; }
        [Required(ErrorMessage = "Trường này không được trống")]
        [Display(Name = "Mật khẩu")]
        [StringLength(20, ErrorMessage = "Mật khẩu phải dưới 20 ký tự")]
        public string MatKhau { get => matKhau; set => matKhau = value; }
    }
}
