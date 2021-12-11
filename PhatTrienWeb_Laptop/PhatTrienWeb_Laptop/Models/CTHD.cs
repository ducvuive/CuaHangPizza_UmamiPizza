using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhatTrienWeb_Laptop.Models
{
    public class CTHD
    {
        string maHD;
        string maSP;
        int soLuong;

        public CTHD() { }
        public CTHD(string maHD, string maSP, int soLuong)
        {
            this.maHD = maHD;
            this.maSP = maSP;
            this.soLuong = soLuong;
        }

        [Key]
        [Display(Name = "Mã hóa đơn")]
        public string MaHD { get => maHD; set => maHD = value; }
        [Key]
        [Display(Name = "Mã sản phẩm")]
        public string MaSP { get => maSP; set => maSP = value; }
        [Required]
        [Display(Name = "Số lượng")]
        public int SoLuong { get => soLuong; set => soLuong = value; }
        [ForeignKey("MaHD")]
        public HoaDon hd { get; set; }
        [ForeignKey("MaSP")]
        public SanPham sp { get; set; }
    }
}
