using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
{
    public class BoNhoRAM
    {
        string maRAM;
        string dungLuongRAM;
        string loaiRAM;
        string busRAM;
        string hoTroToiDa;

        public BoNhoRAM()
        {
        }

        public BoNhoRAM(string maRAM, string dungLuongRAM, string loaiRAM, string busRAM, string hoTroToiDa)
        {
            this.MaRAM = maRAM;
            this.DungLuongRAM = dungLuongRAM;
            this.LoaiRAM = loaiRAM;
            this.BusRAM = busRAM;
            this.HoTroToiDa = hoTroToiDa;
        }

        public string MaRAM { get => maRAM; set => maRAM = value; }
        public string DungLuongRAM { get => dungLuongRAM; set => dungLuongRAM = value; }
        public string LoaiRAM { get => loaiRAM; set => loaiRAM = value; }
        public string BusRAM { get => busRAM; set => busRAM = value; }
        public string HoTroToiDa { get => hoTroToiDa; set => hoTroToiDa = value; }
    }
}
