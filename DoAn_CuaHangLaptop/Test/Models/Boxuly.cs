using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Boxuly
    {
        public Boxuly()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Display(Name = "Mã bộ xử lý")]
        public string Mabxl { get; set; }
        [Display(Name = "Mã bộ xử lý")]
        public string Congnghecpu { get; set; }
        [Display(Name = "Số nhân")]
        public int? Sonhan { get; set; }
        [Display(Name = "Số luồng")]
        public int? Soluong { get; set; }
        [Display(Name = "Tốc độ CPU")]
        public string Tocdocpu { get; set; }
        [Display(Name = "Tốc độ tối đa")]
        public string Tocdotoida { get; set; }
        [Display(Name = "Bộ nhớ đệm")]
        public string Bonhodem { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
