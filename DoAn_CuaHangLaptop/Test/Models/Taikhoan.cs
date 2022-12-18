using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Taikhoan
    {
        public Taikhoan()
        {
            Khachhang = new HashSet<Khachhang>();
            Nhanvien = new HashSet<Nhanvien>();
        }

        public string Tendangnhap { get; set; }
        public string Matkhau { get; set; }

        public virtual ICollection<Khachhang> Khachhang { get; set; }
        public virtual ICollection<Nhanvien> Nhanvien { get; set; }
    }
}
