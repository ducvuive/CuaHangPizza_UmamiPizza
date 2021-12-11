using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
{
    public class CongKetNoi
    {
        string maCKN;
        string congGiaoTiep;
        string ketNoiKhongDay;
        string kheDocTheNho;
        string webCam;
        string tinhNangKhac;
        string denBanPhim;

        public CongKetNoi()
        {
        }

        public CongKetNoi(string maCKN, string congGiaoTiep, string ketNoiKhongDay, string kheDocTheNho, string webCam, string tinhNangKhac, string denBanPhim)
        {
            this.MaCKN = maCKN;
            this.CongGiaoTiep = congGiaoTiep;
            this.KetNoiKhongDay = ketNoiKhongDay;
            this.KheDocTheNho = kheDocTheNho;
            this.WebCam = webCam;
            this.TinhNangKhac = tinhNangKhac;
            this.DenBanPhim = denBanPhim;
        }

        public string MaCKN { get => maCKN; set => maCKN = value; }
        public string CongGiaoTiep { get => congGiaoTiep; set => congGiaoTiep = value; }
        public string KetNoiKhongDay { get => ketNoiKhongDay; set => ketNoiKhongDay = value; }
        public string KheDocTheNho { get => kheDocTheNho; set => kheDocTheNho = value; }
        public string WebCam { get => webCam; set => webCam = value; }
        public string TinhNangKhac { get => tinhNangKhac; set => tinhNangKhac = value; }
        public string DenBanPhim { get => denBanPhim; set => denBanPhim = value; }
    }
}
