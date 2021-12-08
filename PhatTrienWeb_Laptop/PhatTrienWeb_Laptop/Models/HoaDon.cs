using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PhatTrienWeb_Laptop.Models
{
    public class HoaDon
    {
        string maHD;
        string maKH;
        string maNV;
        string maSK;
        DateTime ngayHD;
        string diaChiGiaoHang;
        long tongTien;
        long thanhTien;

        public HoaDon()
        {
        }

        public HoaDon(string maHD, string maKH, string maNV, string maSK, DateTime ngayHD, string diaChiGiaoHang, long tongTien, long thanhTien)
        {
            this.maHD = maHD;
            this.maKH = maKH;
            this.maNV = maNV;
            this.maSK = maSK;
            this.ngayHD = ngayHD;
            this.diaChiGiaoHang = diaChiGiaoHang;
            this.tongTien = tongTien;
            this.thanhTien = thanhTien;
        }

        [Key]
        [Display(Name = "Mã hóa đơn")]
        public string MaHD { get => maHD; set => maHD = value; }
        [Required]
        [Display(Name = "Mã khách hàng")]
        public string MaKH { get => maKH; set => maKH = value; }
        [Required]
        [Display(Name = "Mã nhân viên")]
        public string MaNV { get => maNV; set => maNV = value; }

        [Display(Name = "Mã sự kiện")]
        public string MaSK { get => maSK; set => maSK = value; }
        [Required]
        [Display(Name = "Ngày tạo hóa đơn")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayHD { get => ngayHD; set => ngayHD = value; }
        [Display(Name = "Địa chỉ giao hàng")]
        [StringLength(100, ErrorMessage = "Địa chỉ giao hàng phải dưới 100 ký tự")]
        public string DiaChiGiaoHang { get => diaChiGiaoHang; set => diaChiGiaoHang = value; }
        [Required]
        [Display(Name = "Tổng tiền")]
        public long TongTien { get => tongTien; set => tongTien = value; }
        [Required]
        [Display(Name = "Thành tiền")]
        public long ThanhTien { get => thanhTien; set => thanhTien = value; }

        [ForeignKey("MaKH")]
        public KhachHang kh { get; set; }
        [ForeignKey("MaNV")]
        public NhanVien nv { get; set; }
        [ForeignKey("MaSK")]
        public SuKien sk { get; set; }
    }


}
