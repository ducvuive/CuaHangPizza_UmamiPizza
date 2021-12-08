using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
{
    public class KhachHang
    {
        string maKH;
        string tenDN;
        string tenKH;
        string soDT;
        string email;
        string gioiTinh;
        string matKhau;
        string xacNhanMatKhau;
        public KhachHang() { }

        public KhachHang(string maKH, string tenDN, string tenKH, string soDT, string email, string gioiTinh)
        {
            this.MaKH = maKH;
            this.TenDN = tenDN;
            this.TenKH = tenKH;
            this.SoDT = soDT;
            this.Email = email;
            this.GioiTinh = gioiTinh;
        }
        [Key]
        public string MaKH { get => maKH; set => maKH = value; }
        [Display(Name = "Tên Khách Hàng")]
        [StringLength(50, ErrorMessage = "Tên khách hàng phải dưới 50 ký tự")]
        [Required]
        public string TenKH { get => tenKH; set => tenKH = value; }
        [Display(Name = "Tên Đăng Nhập")]
        [StringLength(20, ErrorMessage = "Tên đăng nhập phải dưới 20 ký tự")]
        [Required]
        public string TenDN { get => tenDN; set => tenDN = value; }
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Display(Name = "Số Điện thoại")]
        [StringLength(10, ErrorMessage = "Số điện thoại phải dưới 10 ký tự")]
        [Required]
        public string SoDT { get => soDT; set => soDT = value; }
        [Display(Name = "Giới tính")]
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [StringLength(50, ErrorMessage = "Email phải dưới 50 ký tự")]
        public string Email { get => email; set => email = value; }

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
