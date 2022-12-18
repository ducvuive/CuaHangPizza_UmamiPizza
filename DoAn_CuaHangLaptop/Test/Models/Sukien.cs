using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Sukien
    {
        public Sukien()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public string Mask { get; set; }
        [Required]
        [Display(Name = "Tên sự kiện ")]
        public string Tensk { get; set; }
        [Required]
        [Display(Name = "Phần trăm giảm giá")]
        public int? Phantramgiamgia { get; set; }
        [Required]
        [Display(Name = "Ngày bắt đầu sự kiện")]
        public DateTime? Ngaybd { get; set; }
        [Required]
        [Display(Name = "Ngày kết thúc sự kiện")]
        public DateTime? Ngaykt { get; set; }

        public virtual ICollection<Hoadon> Hoadon { get; set; }
    }
}
