using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Manhinh
    {
        public Manhinh()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Display(Name = "Mã màn hình")]
        public string Mamh { get; set; }
        [Display(Name = "Kích thước")]
        public string Kichthuoc { get; set; }
        [Display(Name = "Độ phân giải")]
        public string Dophangiai { get; set; }
        [Display(Name = "Tần số quét")]
        public string Tansoquet { get; set; }
        [Display(Name = "Công nghệ màn hình")]
        public string Congnghemh { get; set; }
        [Display(Name = "Cảm ứng")]
        public string Camung { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
