using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public string Makh { get; set; }
        [Display(Name = "Tên Đăng Nhập")]
        [StringLength(20, ErrorMessage = "Tên đăng nhập phải dưới 20 ký tự")]
        [Required]
        public string Tendangnhap { get; set; }
        [Display(Name = "Tên Khách Hàng")]
        [StringLength(50, ErrorMessage = "Tên khách hàng phải dưới 50 ký tự")]
        [Required]
        public string Tenkh { get; set; }
        [Phone(ErrorMessage = "Số điện thoại không đúng định dạng")]
        [Display(Name = "Số Điện thoại")]
        [StringLength(10, ErrorMessage = "Số điện thoại phải dưới 10 ký tự")]
        [Required]
        public string Sodt { get; set; }
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        [StringLength(50, ErrorMessage = "Email phải dưới 50 ký tự")]
        public string Email { get; set; }
        [Display(Name = "Giới tính")]
        public string Gioitinh { get; set; }
        [Display(Name = "Tên Đăng Nhập")]
        [StringLength(20, ErrorMessage = "Tên đăng nhập phải dưới 20 ký tự")]
        public virtual Taikhoan TendangnhapNavigation { get; set; }
        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
