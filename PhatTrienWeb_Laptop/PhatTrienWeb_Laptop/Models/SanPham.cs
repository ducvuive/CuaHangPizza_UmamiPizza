using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
{
    public class SanPham
    {
        string maSP;
        string tenSP;
        int soLuong;
        string mauSac;
        string boXuLy;
        string rAM;
        string oCung;
        string manHinh;
        string cardMH;
        string congKN;
        string dacBiet;
        string hDH;
        string thietKe;
        string kichThuoc_TrongLuong;
        string webcam;
        string pin;
        int raMat;
        string moTa;
        long donGia;
        string hinhAnh;
        string danhMuc;

        public SanPham()
        {
        }

        public SanPham(string maSP, string tenSP, int soLuong, string mauSac, string boXuLy, string rAM, string oCung, string manHinh, string cardMH, string congKN, string dacBiet, string hDH, string thietKe, string kichThuoc_TrongLuong, string webcam, string pin, int raMat, string moTa, long donGia, string hinhAnh, string danhMuc)
        {
            this.MaSP = maSP;
            this.TenSP = tenSP;
            this.SoLuong = soLuong;
            this.MauSac = mauSac;
            this.BoXuLy = boXuLy;
            this.RAM = rAM;
            this.OCung = oCung;
            this.ManHinh = manHinh;
            this.CardMH = cardMH;
            this.CongKN = congKN;
            this.DacBiet = dacBiet;
            this.HDH = hDH;
            this.ThietKe = thietKe;
            this.KichThuoc_TrongLuong = kichThuoc_TrongLuong;
            this.Webcam = webcam;
            this.Pin = pin;
            this.RaMat = raMat;
            this.MoTa = moTa;
            this.DonGia = donGia;
            this.HinhAnh = hinhAnh;
            this.DanhMuc = danhMuc;
        }

        public string MaSP { get => maSP; set => maSP = value; }
        public string TenSP { get => tenSP; set => tenSP = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string MauSac { get => mauSac; set => mauSac = value; }
        public string BoXuLy { get => boXuLy; set => boXuLy = value; }
        public string RAM { get => rAM; set => rAM = value; }
        public string OCung { get => oCung; set => oCung = value; }
        public string ManHinh { get => manHinh; set => manHinh = value; }
        public string CardMH { get => cardMH; set => cardMH = value; }
        public string CongKN { get => congKN; set => congKN = value; }
        public string DacBiet { get => dacBiet; set => dacBiet = value; }
        public string HDH { get => hDH; set => hDH = value; }
        public string ThietKe { get => thietKe; set => thietKe = value; }
        public string KichThuoc_TrongLuong { get => kichThuoc_TrongLuong; set => kichThuoc_TrongLuong = value; }
        public string Webcam { get => webcam; set => webcam = value; }
        public string Pin { get => pin; set => pin = value; }
        public int RaMat { get => raMat; set => raMat = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public long DonGia { get => donGia; set => donGia = value; }
        public string HinhAnh { get => hinhAnh; set => hinhAnh = value; }
        public string DanhMuc { get => danhMuc; set => danhMuc = value; }
    }
}
