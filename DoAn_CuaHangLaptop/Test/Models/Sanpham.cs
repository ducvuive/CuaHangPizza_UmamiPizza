using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Models
{
    public partial class Sanpham
    {
        public Sanpham()
        {
            Cthd = new HashSet<Cthd>();
        }
        [Display(Name = "Mã sản phẩm")]
        public string Masp { get; set; }
        [Display(Name = "Màn hình")]
        public string Tensp { get; set; }
        [Display(Name = "Số lượng")]
        public int Danhmuc { get; set; }
        [Display(Name = "Tên sản phẩm")]
        public int? Soluong { get; set; }
        [Display(Name = "Màu sắc")]
        public string Mota { get; set; }
        [Display(Name = "Đơn giá")]
        public int Size { get; set; }
        [Display(Name = "Size")]
        public long? Dongia { get; set; }
        [Display(Name = "Hình ảnh")]
        public string Hinhanh { get; set; }
        public virtual Size SizeNavigation { get; set; }
        public virtual Danhmucsanpham DanhmucNavigation { get; set; }
        public virtual ICollection<Cthd> Cthd { get; set; }
        [NotMapped]
        public IFormFile HinhAnhFile { get; set; }
    }
}
