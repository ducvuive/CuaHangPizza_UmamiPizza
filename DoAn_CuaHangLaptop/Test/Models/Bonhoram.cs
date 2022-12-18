using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Bonhoram
    {
        public Bonhoram()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Display(Name = "Mã RAM")]
        public string Maram { get; set; }
        [Display(Name = "Dung lượng RAM")]
        public string Dungluongram { get; set; }
        [Display(Name = "Loại RAM")]
        public string Loairam { get; set; }
        [Display(Name = "Bus RAM")] 
        public string Busram { get; set; }
        [Display(Name = "Hỗ trợ tối đa")]
        public string Hotrotoida { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
