using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoAn_CuaHangLaptop.Models
{
    public class ManHinh
    {
        string maMH;
        string kichThuoc;
        string doPhanGiai;
        string tanSoQuet;
        string congNgheMH;
        string camUng;

        public ManHinh()
        {
        }

        public ManHinh(string maMH, string kichThuoc, string doPhanGiai, string tanSoQuet, string congNgheMH, string camUng)
        {
            this.MaMH = maMH;
            this.KichThuoc = kichThuoc;
            this.DoPhanGiai = doPhanGiai;
            this.TanSoQuet = tanSoQuet;
            this.CongNgheMH = congNgheMH;
            this.CamUng = camUng;
        }

        public string MaMH { get => maMH; set => maMH = value; }
        public string KichThuoc { get => kichThuoc; set => kichThuoc = value; }
        public string DoPhanGiai { get => doPhanGiai; set => doPhanGiai = value; }
        public string TanSoQuet { get => tanSoQuet; set => tanSoQuet = value; }
        public string CongNgheMH { get => congNgheMH; set => congNgheMH = value; }
        public string CamUng { get => camUng; set => camUng = value; }
    }
}
