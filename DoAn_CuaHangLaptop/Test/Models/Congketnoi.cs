using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Congketnoi
    {
        public Congketnoi()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Display(Name = "Mã cổng kết nối")]
        public string Mackn { get; set; }
        [Display(Name = "Cổng giao tiếp")]
        public string Conggiaotiep { get; set; }
        [Display(Name = "Kết nối không dây")]
        public string Ketnoikhongday { get; set; }
        [Display(Name = "Khe đọc thẻ nhớ")]
        public string Khedocthenho { get; set; }
        [Display(Name = "Webcam")]
        public string Webcam { get; set; }
        [Display(Name = "Tính năng khác")]
        public string Tinhnangkhac { get; set; }
        [Display(Name = "Đèn bàn phím")]
        public string Denbanphim { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
