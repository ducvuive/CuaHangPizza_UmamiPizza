using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Cthd
    {
        public int Mahd { get; set; }
        public string Masp { get; set; }
        public int? Soluong { get; set; }

        public virtual Hoadon MahdNavigation { get; set; }
        public virtual Sanpham MaspNavigation { get; set; }
    }
}
