using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Danhmucsanpham
    {
        public Danhmucsanpham()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Display(Name = "Mã danh mục")]
        public int Madm { get; set; }
        [Display(Name = "Tên danh mục")]
        public string Tendm { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
