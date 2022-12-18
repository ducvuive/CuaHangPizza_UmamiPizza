using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public string Manv { get; set; }
        public string Tendangnhap { get; set; }
        public string Tennv { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Gioitinh { get; set; }
        public string Chucvu { get; set; }
        public string Diachi { get; set; }
        public DateTime? Ngayvl { get; set; }
        public string Sodt { get; set; }

        public virtual Taikhoan TendangnhapNavigation { get; set; }
        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
