using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Size
    {
        public Size()
        {
            Sanpham = new HashSet<Sanpham>();
        }
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Size")]
        public string size { get; set; }

        public virtual ICollection<Sanpham> Sanpham { get; set; }
    }
}
