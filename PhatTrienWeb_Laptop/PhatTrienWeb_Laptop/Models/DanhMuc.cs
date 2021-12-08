using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhatTrienWeb_Laptop.Models
{
    public class DanhMuc
    {
        string maDM;
        string tenDM;

        public string MaDM { get => maDM; set => maDM = value; }
        public string TenDM { get => tenDM; set => tenDM = value; }

        public DanhMuc()
        {
        }

        public DanhMuc(string maDM, string tenDM)
        {
            this.maDM = maDM;
            this.tenDM = tenDM;
        }
    }
}
