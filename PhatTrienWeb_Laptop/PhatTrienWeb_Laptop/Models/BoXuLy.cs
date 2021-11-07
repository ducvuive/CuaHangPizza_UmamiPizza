using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Models
{
    public class BoXuLy
    {
        string maBXL;
        string congNgheCPU;
        int soNhan;
        int soLuong;
        string tocDoCPU;
        string tocDoToiDa;
        string boNhoDem;

        public BoXuLy()
        {
        }

        public BoXuLy(string maBXL, string congNgheCPU, int soNhan, int soLuong, string tocDoCPU, string tocDoToiDa, string boNhoDem)
        {
            this.MaBXL = maBXL;
            this.CongNgheCPU = congNgheCPU;
            this.SoNhan = soNhan;
            this.SoLuong = soLuong;
            this.TocDoCPU = tocDoCPU;
            this.TocDoToiDa = tocDoToiDa;
            this.BoNhoDem = boNhoDem;
        }

        public string MaBXL { get => maBXL; set => maBXL = value; }
        public string CongNgheCPU { get => congNgheCPU; set => congNgheCPU = value; }
        public int SoNhan { get => soNhan; set => soNhan = value; }
        public int SoLuong { get => soLuong; set => soLuong = value; }
        public string TocDoCPU { get => tocDoCPU; set => tocDoCPU = value; }
        public string TocDoToiDa { get => tocDoToiDa; set => tocDoToiDa = value; }
        public string BoNhoDem { get => boNhoDem; set => boNhoDem = value; }
    }
}
