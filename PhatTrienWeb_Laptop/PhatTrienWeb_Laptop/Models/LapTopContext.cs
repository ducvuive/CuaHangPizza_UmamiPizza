using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using PhatTrienWeb_Laptop.Models;

namespace PhatTrienWeb_Laptop.Models
{
    public class LapTopContext
    {
        readonly IConfiguration configuration;
        public string ConnectionString { get; set; }

        public LapTopContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }

        //===================TÀI KHOẢN =============================
        public List<TaiKhoan> layDSTaiKhoan()
        {
            List<TaiKhoan> dsTaiKhoan = new List<TaiKhoan>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Select * from TAIKHOAN";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dsTaiKhoan.Add(new TaiKhoan()
                            {
                                TenDangNhap = reader["tendangnhap"].ToString(),
                                MatKhau = reader["matkhau"].ToString(),
                            });

                        }
                    }
                }
            }
            return dsTaiKhoan;
        }
        public bool ktTenDangNhap(string tendangnhap)
        {

            List<TaiKhoan> list = new List<TaiKhoan>();
            list = layDSTaiKhoan();
            foreach (TaiKhoan temp in list)
            {
                if (temp.TenDangNhap == tendangnhap) return false;
            }
            return true;
        }


        public int taoTaiKhoan(string tendangnhap, string matkhau)
        {
            int count = 0;
            if (!ktTenDangNhap(tendangnhap)) return 0;
            else
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO TAIKHOAN VALUES (@tenDangNhap,@matKhau) ";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@tenDangNhap", tendangnhap.ToString());
                    cmd.Parameters.AddWithValue("@matKhau", matkhau.ToString());
                    cmd.ExecuteNonQuery();
                    count++;
                }
                return count;
            }

        }

        public int capNhatTaiKhoan(string tendangnhap, string matkhau)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE taikhoan
                                    SET matkhau = @matkhau
                                    WHERE tendangnhap = @tendangnhap;";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("tendangnhap", tendangnhap.ToString());
                cmd.Parameters.AddWithValue("matkhau", matkhau.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public void xoaTaiKhoan(string tendangnhap)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from taikhoan where tendangnhap = @tendangnhap; ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("tendangnhap", tendangnhap);
                cmd.ExecuteNonQuery();

            }
        }
        public TaiKhoan layThongTinTK(string tendangnhap)
        {
            TaiKhoan tk = new TaiKhoan();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from TaiKhoan where tendangnhap =@tendangnhap";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tendangnhap", tendangnhap);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tk.TenDangNhap = reader["tendangnhap"].ToString();
                        tk.MatKhau = reader["matkhau"].ToString();
                    };

                }
            }
            return tk;
        }

        //===================END TÀI KHOẢN =============================

        //===================NHÂN VIÊN =========================
        public List<NhanVien> layDSNhanVien()
        {
            List<NhanVien> dsNhanVien = new List<NhanVien>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "Select * from NHANVIEN";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            dsNhanVien.Add(new NhanVien()
                            {
                                MaNV = reader["manv"].ToString(),
                                TenDangNhap = reader["tendangnhap"].ToString(),
                                TenNV = reader["tenNV"].ToString(),
                                NgaySinh = (DateTime)reader["ngaysinh"],
                                GioiTinh = reader["gioitinh"].ToString(),
                                ChucVu = reader["chucvu"].ToString(),
                                DiaChi = reader["diachi"]?.ToString(),
                                NgayVL = (DateTime)reader["ngayvl"],
                                SoDT = reader["sodt"]?.ToString(),
                            });

                        }
                    }
                }
            }
            return dsNhanVien;
        }

        public void xuLyTaoNhanVien(NhanVien nv)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"INSERT INTO nhanvien(TENDANGNHAP,TENNV,NGAYSINH,GIOITINH,CHUCVU,DIACHI,NGAYVL,SODT)
                                     VALUES
                                     (@tendangnhap,@tennv,@ngaysinh,@gioitinh,@chucvu,@diachi,@ngayvl,@sodt)";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tenDangNhap", nv.TenDangNhap.ToString());
                cmd.Parameters.AddWithValue("@tennv", nv.TenNV.ToString());
                cmd.Parameters.AddWithValue("@ngaysinh", nv.NgaySinh);
                cmd.Parameters.AddWithValue("@gioitinh", nv.GioiTinh.ToString());
                cmd.Parameters.AddWithValue("@chucvu", nv.ChucVu.ToString());
                cmd.Parameters.AddWithValue("@diachi", nv.DiaChi?.ToString());
                cmd.Parameters.AddWithValue("@ngayvl", nv.NgayVL);
                cmd.Parameters.AddWithValue("@sodt", nv.SoDT?.ToString());
                cmd.ExecuteNonQuery();
            }
        }
        public bool ktNgayVL(DateTime ngaySinh, DateTime ngayVL)
        {
            int namSinh = ngaySinh.Year;
            int namVL = ngayVL.Year;
            if (namSinh > namVL)
            {
                return false;
            }
            else
            {
                if (namVL - namSinh < 16) return false;

            }
            return true;
        }

        public int taoNhanVien(NhanVien nv)
        {
            int count = 1;
            if (!ktTenDangNhap(nv.TenDangNhap))
            {
                return 0;
            }
            else if (!ktNgayVL(nv.NgaySinh, nv.NgayVL))
            {
                return 1;
            }
            else
            {
                taoTaiKhoan(nv.TenDangNhap, nv.MatKhau);
                xuLyTaoNhanVien(nv);
                count++;
            }

            return count;
        }

        public NhanVien layThongTinNV(string manv)
        {
            NhanVien nv = new NhanVien();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from Nhanvien where manv =@manv";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@manv", manv);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        nv.MaNV = reader["manv"].ToString();
                        nv.TenDangNhap = reader["tendangnhap"].ToString();
                        nv.TenNV = reader["tenNV"].ToString();
                        nv.NgaySinh = (DateTime)reader["ngaysinh"];
                        nv.GioiTinh = reader["gioitinh"].ToString();
                        nv.ChucVu = reader["chucvu"].ToString();
                        nv.DiaChi = reader["diachi"]?.ToString();
                        nv.NgayVL = (DateTime)reader["ngayvl"];
                        nv.SoDT = reader["sodt"]?.ToString();
                    };

                }
            }
            return nv;
        }

        public int capNhatNhanVien(string manv, NhanVien nv)
        {
            int count = 0;
            if (!ktNgayVL(nv.NgaySinh, nv.NgayVL))
            {
                return 0;
            }
            else
            {
                capNhatTaiKhoan(nv.TenDangNhap, nv.MatKhau);
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE nhanvien
                                    SET
                                    TENNV = @tennv,
                                    NGAYSINH = @ngaysinh,
                                    GIOITINH = @gioitinh,
                                    CHUCVU = @chucvu,
                                    DIACHI = @diachi,
                                    NGAYVL = @ngayvl,
                                    SODT = @sodt
                                    WHERE MANV = @manv;";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("TENNV", nv.TenNV.ToString());
                    cmd.Parameters.AddWithValue("NGAYSINH", nv.NgaySinh);
                    cmd.Parameters.AddWithValue("GIOITINH", nv.GioiTinh.ToString());
                    cmd.Parameters.AddWithValue("CHUCVU", nv.ChucVu.ToString());
                    cmd.Parameters.AddWithValue("DIACHI", nv.DiaChi?.ToString());
                    cmd.Parameters.AddWithValue("NGAYVL", nv.NgayVL);
                    cmd.Parameters.AddWithValue("SODT", nv.SoDT?.ToString());
                    cmd.Parameters.AddWithValue("MANV", manv.ToString());
                    cmd.ExecuteNonQuery();
                    count++;
                }
            }

            return count;
        }

        public void xoaNhanVien(string manv, string tendangnhap)
        {

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from nhanvien where manv = @manv ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("manv", manv);
                cmd.ExecuteNonQuery();
            }
            xoaTaiKhoan(tendangnhap);
        }
        //===================END NHÂN VIÊN =========================
		 //CONTEXT SỤ Kiện
        public List<SuKien> laySuKien()
        {
            List<SuKien> list = new List<SuKien>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from sukien";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SuKien()
                        {
                            MaSK = reader["mask"].ToString(),
                            TenSK = reader["tensk"].ToString(),
                            PhanTramGiamGia = Convert.ToInt32(reader["PHANTRAMGIAMGIA"]),
                            NgayBD = (DateTime)reader["ngaybd"],
                            NgayKT = (DateTime)reader["ngaykt"]
                        });

                    }
                }
            }
            return list;
        }
        public bool kiemTraNgayBD_KT(DateTime ngaybd, DateTime ngaykt)
        {
                int compare1 = DateTime.Compare(ngaybd, ngaykt);
            if (compare1 < 0)
            {
                return true;
            }
            else return false;
        }
        public int taoSuKien(SuKien sk)
        {
            int count = 0;
            if (!kiemTraNgayBD_KT(sk.NgayBD, sk.NgayKT))
            {
                return 0;
            }
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into sukien value(?mask, ?tensk, ?phanTramGiamGia, ?ngayBD,?ngayKT);";
                //string query = "insert into khachhang value(?tendangnhap, ?tenkh, ?sodt, ?email, ?gioitinh) ";//ON DUPLICATE KEY UPDATE MaKH = ?makh
                MySqlCommand cmd = new MySqlCommand(query, conn);
                //cmd.Parameters.AddWithValue("makh", kh.MaKH.ToString());
                cmd.Parameters.AddWithValue("mask","");
                cmd.Parameters.AddWithValue("tensk", sk.TenSK.ToString());
                cmd.Parameters.AddWithValue("phanTramGiamGia", Convert.ToInt32(sk.PhanTramGiamGia));
                cmd.Parameters.AddWithValue("ngayBD", sk.NgayBD);
                cmd.Parameters.AddWithValue("ngayKT", sk.NgayKT);
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int capNhatSuKien(SuKien sk)
        {
            if (!kiemTraNgayBD_KT(sk.NgayBD, sk.NgayKT))
            {
                return 0;
            }
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = @"UPDATE sukien
                                    SET
                                    tensk = @tensk,
                                    phantramgiamgia = @phantramgiamgia,
                                    ngaybd = @ngaybd,
                                    ngaykt = @ngaykt
                                    WHERE mask = @mask;";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("tensk", sk.TenSK.ToString());
                cmd.Parameters.AddWithValue("phantramgiamgia", Convert.ToInt32(sk.PhanTramGiamGia));
                cmd.Parameters.AddWithValue("ngaybd", sk.NgayBD);
                cmd.Parameters.AddWithValue("ngaykt", sk.NgayKT);
                cmd.Parameters.AddWithValue("mask", sk.MaSK.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int xoaSuKien(string mask)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string temp = mask;
                string query = "delete from SuKien where mask = @mask ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mask", temp); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }
        public SuKien laySuKien(string mask)
        {

            SuKien sk = new SuKien();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string temp = mask;
                string query = "select * from SuKien where mask =@mask";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mask", temp);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        sk.MaSK = reader["mask"].ToString();
                        sk.TenSK = reader["tensk"].ToString();
                        sk.PhanTramGiamGia = Convert.ToInt32(reader["PHANTRAMGIAMGIA"]);
                        sk.NgayBD = (DateTime)reader["ngaybd"];
                        sk.NgayKT = (DateTime)reader["ngaykt"];
                    };

                }
            }
            return sk;
        }
        //===================END SỰ KIỆN =========================
		 //===================BEGIN KHACH HANG =========================

        public List<KhachHang> layKhachHang()
        {
            List<KhachHang> list = new List<KhachHang>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from KhachHang";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new KhachHang()
                        {
                            MaKH = reader["makh"]?.ToString(),
                            TenDN = reader["tendangnhap"]?.ToString(),
                            TenKH = reader["tenKH"]?.ToString(),
                            SoDT = reader["soDT"]?.ToString(),
                            Email = reader["email"]?.ToString(),
                            GioiTinh = reader["gioiTinh"]?.ToString(),
                        });

                    }
                }
            }
            return list;
        }
        public int taoKhachHang(KhachHang kh)
        {
            int count = 1;
            if (!ktTenDangNhap(kh.TenDN))
            {
                return 0;
            }
            else if (!ktEmail(kh.Email)){
                return 1;
            }
            else
            {
                taoTaiKhoan(kh.TenDN, kh.MatKhau);
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO laptop.`khachhang`(TENDANGNHAP,TENKH,SODT,EMAIL,GIOITINH)VALUES(?tendangnhap, ?tenkh, ?sodt, ?email, ?gioitinh);";
                    //string query = "insert into khachhang value(?tendangnhap, ?tenkh, ?sodt, ?email, ?gioitinh) ";//ON DUPLICATE KEY UPDATE MaKH = ?makh
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("makh", kh.MaKH.ToString());
                    cmd.Parameters.AddWithValue("tendangnhap", kh.TenDN.ToString());
                    cmd.Parameters.AddWithValue("tenkh", kh.TenKH.ToString());
                    cmd.Parameters.AddWithValue("sodt", kh.SoDT.ToString());
                    cmd.Parameters.AddWithValue("email", kh.Email.ToString());
                    cmd.Parameters.AddWithValue("gioitinh", kh.GioiTinh.ToString());
                    cmd.ExecuteNonQuery();
                    count++;
                }
            }
            return count;
        }

        public int capNhatKhachHang(KhachHang kh)
        {
            int count = 0;
            {
                using (MySqlConnection conn = GetConnection())
                {
                    conn.Open();
                    string makh = kh.MaKH;
                    string query = "update khachhang set tenkh=@Tenkh,tendangnhap=@Tendangnhap , sodt =@Sodt, email=@Email, gioitinh =@Gioitinh where makh = @makh";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@makh", kh.MaKH.ToString());
                    cmd.Parameters.AddWithValue("@tendangnhap", kh.TenDN.ToString());
                    cmd.Parameters.AddWithValue("makh", kh.MaKH.ToString());
                    cmd.Parameters.AddWithValue("tenkh", kh.TenKH.ToString());
                    cmd.Parameters.AddWithValue("sodt", kh.SoDT.ToString());
                    cmd.Parameters.AddWithValue("email", kh.Email.ToString());
                    cmd.Parameters.AddWithValue("gioitinh", kh.GioiTinh.ToString());
                    cmd.ExecuteNonQuery();
                    count++;
                }
            }
            return count;
        }

        public int xoaKhachHang(string makh)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                //if (kh == null) return 0;
                conn.Open();
                string temp = makh;
                string query = "delete from khachhang where makh = @makh ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makh", temp); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            KhachHang kh = layKhachHang(makh);
            xoaTaiKhoan(kh.TenDN);
            return count;
        }
        public KhachHang layKhachHang(string makh)
        {

            KhachHang kh = new KhachHang();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string temp = makh;
                string query = "select * from KhachHang where makh =@makh";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@makh", temp);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kh.MaKH = reader["makh"]?.ToString();
                        kh.TenDN = reader["tendangnhap"]?.ToString();
                        kh.TenKH = reader["tenKH"]?.ToString();
                        kh.SoDT = reader["soDT"]?.ToString();
                        kh.Email = reader["email"]?.ToString();
                        kh.GioiTinh = reader["gioiTinh"]?.ToString();
                    };
                }
            }
            return kh;
        }
        public bool ktEmail(string email)
        {
            List<KhachHang> list = new List<KhachHang>();
            list = layKhachHang();
            foreach (KhachHang temp in list)
            {
                if (temp.Email == email) return false;
            }
            return true;
        }
		 //===================END KHACHHANG =========================

	 //DANH MUC MODEL
        public List<DanhMuc> LayDSDanhMuc()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from DanhMucSanPham";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new DanhMuc()
                        {
                            MaDM = reader["madm"].ToString(),
                            TenDM = reader["TenDM"].ToString(),
                        });

                    }
                }
            }
            return list;
        }

        public DanhMuc LayDanhMuc(string madm)
        {

            DanhMuc dm = new DanhMuc();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from DanhMucSanPham where madm =@madm";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@madm", madm);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dm.MaDM = reader["madm"].ToString();
                        dm.TenDM = reader["tendm"].ToString();
                    }
                }
                return dm;
            }
        }

        public int TaoDanhMuc(DanhMuc dm)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into DanhMucSanPham values(?madm, ?tendm) ";//ON DUPLICATE KEY UPDATE madm = ?madm
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("madm", "");
                cmd.Parameters.AddWithValue("tendm", dm.TenDM.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int CapNhatDanhMuc(DanhMuc dm)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string madm = dm.MaDM;
                string query = "update DanhMucSanPham set tendm=@tendm where madm = @madm";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@madm", madm);
                cmd.Parameters.AddWithValue("tendm", dm.TenDM.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int XoaDanhMuc(string madm)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from DanhMucSanPham where madm = @madm ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@madm", madm); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        // BO NHO RAM MODEL
        public List<BoNhoRAM> LayDSBoNhoRAM()
        {
            List<BoNhoRAM> list = new List<BoNhoRAM>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from BoNhoRAM";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BoNhoRAM()
                        {
                            MaRAM = reader["MARAM"]?.ToString(),
                            DungLuongRAM = reader["DUNGLUONGRAM"]?.ToString(),
                            LoaiRAM = reader["loairam"]?.ToString(),
                            BusRAM = reader["BUSRAM"]?.ToString(),
                            HoTroToiDa = reader["HOTROTOIDA"]?.ToString(),
                        });

                    }
                }
            }
            return list;
        }

        public BoNhoRAM LayBoNhoRAM(string maram)
        {

            BoNhoRAM BNR = new BoNhoRAM();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from BoNhoRAM where maram =@maram";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maram", maram);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BNR.MaRAM = reader["MARAM"].ToString();
                        BNR.DungLuongRAM = reader["DUNGLUONGRAM"]?.ToString();
                        BNR.LoaiRAM = reader["LOAIRAM"]?.ToString();
                        BNR.BusRAM = reader["BUSRAM"]?.ToString();
                        BNR.HoTroToiDa = reader["HOTROTOIDA"]?.ToString();

                    };

                }
            }
            return BNR;
        }

        public int TaoBoNhoRAM(BoNhoRAM bnr)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into bonhoram value(?maram, ?dungluongram, ?loairam, ?busram, ?hotrotoida) ";//ON DUPLICATE KEY UPDATE maram = ?maram
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("maram", "");
                cmd.Parameters.AddWithValue("dungluongram", bnr.DungLuongRAM?.ToString());
                cmd.Parameters.AddWithValue("loairam", bnr.LoaiRAM?.ToString());
                cmd.Parameters.AddWithValue("busram", bnr.BusRAM?.ToString());
                cmd.Parameters.AddWithValue("hotrotoida", bnr.HoTroToiDa?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int CapNhatBoNhoRAM(BoNhoRAM bnr)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string maram = bnr.MaRAM;
                string query = "update bonhoram set dungluongram=@dungluongram, loairam =@loairam, busram=@busram, hotrotoida =@hotrotoida where maram = @maram";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maram", maram);
                cmd.Parameters.AddWithValue("dungluongram", bnr.DungLuongRAM?.ToString());
                cmd.Parameters.AddWithValue("loairam", bnr.LoaiRAM?.ToString());
                cmd.Parameters.AddWithValue("busram", bnr.BusRAM?.ToString());
                cmd.Parameters.AddWithValue("hotrotoida", bnr.HoTroToiDa?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int XoaBoNhoRAM(string maram)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from bonhoram where maram = @maram ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@maram", maram); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        //BO XU LY MODEL BoXuLy

        public List<BoXuLy> LayDSBoXuLy()
        {
            List<BoXuLy> list = new List<BoXuLy>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from BoXuLy";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BoXuLy()
                        {
                            MaBXL = reader["MABXL"].ToString(),
                            CongNgheCPU = reader["CONGNGHECPU"]?.ToString(),
                            SoNhan = Convert.ToInt32(reader["SONHAN"]),
                            SoLuong = Convert.ToInt32(reader["SOLUONG"]),
                            TocDoCPU = reader["TocDoCPU"]?.ToString(),
                            TocDoToiDa = reader["TocDoToiDa"]?.ToString(),
                            BoNhoDem = reader["BoNhoDem"]?.ToString(),
                        });

                    }
                }
            }
            return list;
        }

        public BoXuLy LayBoXuLy(string mabxl)
        {

            BoXuLy BXL = new BoXuLy();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from boxuly where mabxl =@mabxl";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mabxl", mabxl);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BXL.MaBXL = reader["MABXL"].ToString();
                        BXL.CongNgheCPU = reader["CONGNGHECPU"]?.ToString();
                        BXL.SoNhan = Convert.ToInt32(reader["SONHAN"]);
                        BXL.SoLuong = Convert.ToInt32(reader["SOLUONG"]);
                        BXL.TocDoCPU = reader["TocDoCPU"]?.ToString();
                        BXL.TocDoToiDa = reader["TocDoToiDa"]?.ToString();
                        BXL.BoNhoDem = reader["BoNhoDem"]?.ToString();
                    };

                }
            }
            return BXL;
        }

        public int TaoBoXuLy(BoXuLy bxl)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into BoXuLy value(?mabxl, ?congnghecpu, ?sonhan, ?soluong, ?tocdocpu, ?tocdotoida, ?bonhodem) ";//ON DUPLICATE KEY UPDATE mabxl = ?mabxl
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("mabxl", "");
                cmd.Parameters.AddWithValue("congnghecpu", bxl.CongNgheCPU?.ToString());
                cmd.Parameters.AddWithValue("sonhan", Convert.ToInt32(bxl.SoNhan));
                cmd.Parameters.AddWithValue("soluong", Convert.ToInt32(bxl.SoLuong));
                cmd.Parameters.AddWithValue("tocdocpu", bxl.TocDoCPU?.ToString());
                cmd.Parameters.AddWithValue("tocdotoida", bxl.TocDoToiDa?.ToString());
                cmd.Parameters.AddWithValue("bonhodem", bxl.BoNhoDem?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int CapNhatBoXuLy(BoXuLy bxl)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string mabxl = bxl.MaBXL;
                string query = "update BoXuLy set congnghecpu=@congnghecpu, sonhan =@sonhan, soluong=@soluong, tocdocpu =@tocdocpu, tocdotoida=@tocdotoida, bonhodem=@bonhodem where mabxl = @mabxl";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mabxl", mabxl);
                cmd.Parameters.AddWithValue("congnghecpu", bxl.CongNgheCPU?.ToString());
                cmd.Parameters.AddWithValue("sonhan", Convert.ToInt32(bxl.SoNhan));
                cmd.Parameters.AddWithValue("soluong", Convert.ToInt32(bxl.SoLuong));
                cmd.Parameters.AddWithValue("tocdocpu", bxl.TocDoCPU?.ToString());
                cmd.Parameters.AddWithValue("tocdotoida", bxl.TocDoToiDa?.ToString());
                cmd.Parameters.AddWithValue("bonhodem", bxl.BoNhoDem?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int XoaBoXuLy(string mabxl)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from BoXuLy where mabxl = @mabxl ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mabxl", mabxl); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        //CONG KET NOI MODEL CongKetNoi

        public List<CongKetNoi> LayDSCongKetNoi()
        {
            List<CongKetNoi> list = new List<CongKetNoi>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from CongKetNoi";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new CongKetNoi()
                        {
                            MaCKN = reader["MACKN"].ToString(),
                            CongGiaoTiep = reader["CONGGIAOTIEP"]?.ToString(),
                            KetNoiKhongDay = reader["KETNOIKHONGDAY"]?.ToString(),
                            KheDocTheNho = reader["KHEDOCTHENHO"]?.ToString(),
                            WebCam = reader["WEBCAM"]?.ToString(),
                            TinhNangKhac = reader["TINHNANGKHAC"]?.ToString(),
                            DenBanPhim = reader["DENBANPHIM"]?.ToString(),
                        });

                    }
                }
            }
            return list;
        }

        public CongKetNoi LayCongKetNoi(string mackn)
        {

            CongKetNoi CKN = new CongKetNoi();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from CongKetNoi where mackn =@mackn";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mackn", mackn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CKN.MaCKN = reader["MACKN"].ToString();
                        CKN.CongGiaoTiep = reader["CONGGIAOTIEP"]?.ToString();
                        CKN.KetNoiKhongDay = reader["KETNOIKHONGDAY"]?.ToString();
                        CKN.KheDocTheNho = reader["KHEDOCTHENHO"]?.ToString();
                        CKN.WebCam = reader["WEBCAM"]?.ToString();
                        CKN.TinhNangKhac = reader["TINHNANGKHAC"]?.ToString();
                        CKN.DenBanPhim = reader["DENBANPHIM"]?.ToString();
                    };

                }
            }
            return CKN;
        }

        public int TaoCongKetNoi(CongKetNoi ckn)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into CongKetNoi value(?mackn, ?conggiaotiep, ?ketnoikhongday, ?khedocthenho, ?webcam, ?tinhnangkhac, ?denbanphim) ";//ON DUPLICATE KEY UPDATE mackn = ?mackn
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("mackn", "");
                cmd.Parameters.AddWithValue("conggiaotiep", ckn.CongGiaoTiep?.ToString());
                cmd.Parameters.AddWithValue("ketnoikhongday", ckn.KetNoiKhongDay?.ToString());

                cmd.Parameters.AddWithValue("khedocthenho", ckn.KheDocTheNho?.ToString());

                cmd.Parameters.AddWithValue("webcam", ckn.WebCam?.ToString());

                cmd.Parameters.AddWithValue("tinhnangkhac", ckn.TinhNangKhac?.ToString());

                cmd.Parameters.AddWithValue("denbanphim", ckn.DenBanPhim?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int CapNhatCongKetNoi(CongKetNoi ckn)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string mackn = ckn.MaCKN;
                string query = "update CongKetNoi set conggiaotiep=@conggiaotiep, ketnoikhongday =@ketnoikhongday, khedocthenho=@khedocthenho, webcam =@webcam, tinhnangkhac=@tinhnangkhac, denbanphim=@denbanphim where mackn = @mackn";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mackn", mackn);
                cmd.Parameters.AddWithValue("conggiaotiep", ckn.CongGiaoTiep?.ToString());
                cmd.Parameters.AddWithValue("ketnoikhongday", ckn.KetNoiKhongDay?.ToString());
                cmd.Parameters.AddWithValue("khedocthenho", ckn.KheDocTheNho?.ToString());
                cmd.Parameters.AddWithValue("webcam", ckn.WebCam?.ToString());
                cmd.Parameters.AddWithValue("tinhnangkhac", ckn.TinhNangKhac?.ToString());
                cmd.Parameters.AddWithValue("denbanphim", ckn.DenBanPhim?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int XoaCongKetNoi(string mackn)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from congketnoi where mackn = @mackn ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mackn", mackn); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        //MAN HINH MODEL ManHinh

        public List<ManHinh> LayDSManHinh()
        {
            List<ManHinh> list = new List<ManHinh>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from ManHinh";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new ManHinh()
                        {
                            MaMH = reader["MAMH"].ToString(),
                            KichThuoc = reader["KICHTHUOC"].ToString(),
                            DoPhanGiai = reader["DOPHANGIAI"]?.ToString(),
                            TanSoQuet = reader["TANSOQUET"]?.ToString(),
                            CongNgheMH = reader["CONGNGHEMH"]?.ToString(),
                            CamUng = reader["CAMUNG"]?.ToString(),
                        });

                    }
                }
            }
            return list;
        }

        public ManHinh LayManHinh(string mamh)
        {

            ManHinh MH = new ManHinh();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from ManHinh where mamh =@mamh";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mamh", mamh);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        MH.MaMH = reader["MAMH"].ToString();
                        MH.KichThuoc = reader["KICHTHUOC"].ToString();
                        MH.DoPhanGiai = reader["DOPHANGIAI"]?.ToString();
                        MH.TanSoQuet = reader["TANSOQUET"]?.ToString();
                        MH.CongNgheMH = reader["CONGNGHEMH"]?.ToString();
                        MH.CamUng = reader["CAMUNG"]?.ToString();
                    };

                }
            }
            return MH;
        }

        public int TaoManHinh(ManHinh mh)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into manhinh value(?mamh, ?kichthuoc, ?dophangiai, ?tansoquet, ?congnghemh, ?camung) ";//ON DUPLICATE KEY UPDATE mamh = ?mamh
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("mamh", "");
                cmd.Parameters.AddWithValue("kichthuoc", mh.KichThuoc.ToString());
                cmd.Parameters.AddWithValue("dophangiai", mh.DoPhanGiai?.ToString());
                cmd.Parameters.AddWithValue("tansoquet", mh.TanSoQuet?.ToString());
                cmd.Parameters.AddWithValue("congnghemh", mh.CongNgheMH?.ToString());
                cmd.Parameters.AddWithValue("camung", mh.CamUng?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int CapNhatManHinh(ManHinh mh)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string mamh = mh.MaMH;
                string query = "update manhinh set kichthuoc=@kichthuoc, dophangiai =@dophangiai, tansoquet=@tansoquet, congnghemh =@congnghemh, camung=@camung where mamh = @mamh";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mamh", mamh);
                cmd.Parameters.AddWithValue("kichthuoc", mh.KichThuoc.ToString());
                cmd.Parameters.AddWithValue("dophangiai", mh.DoPhanGiai?.ToString());
                cmd.Parameters.AddWithValue("tansoquet", mh.TanSoQuet?.ToString());
                cmd.Parameters.AddWithValue("congnghemh", mh.CongNgheMH?.ToString());
                cmd.Parameters.AddWithValue("camung", mh.CamUng?.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int XoaManHinh(string mamh)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from manhinh where mamh = @mamh ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@mamh", mamh); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        //SAN PHAM MODEL SanPham

        public List<SanPham> LayDSSanPham()
        {
            List<SanPham> list = new List<SanPham>();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from SanPham";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new SanPham()
                        {
                            MaSP = reader["MaSP"].ToString(),
                            ManHinh = reader["ManHinh"].ToString(),
                            BoXuLy = reader["BoXuLy"].ToString(),
                            RAM = reader["RAM"].ToString(),
                            CongKN = reader["CongKetNoi"].ToString(),
                            DanhMuc = reader["DanhMuc"].ToString(),
                            TenSP = reader["TenSP"].ToString(),
                            SoLuong = Convert.ToInt32(reader["SoLuong"]),
                            MauSac = reader["MauSac"].ToString(),
                            OCung = reader["OCung"].ToString(),
                            CardMH = reader["CardManHinh"].ToString(),
                            DacBiet = reader["DacBiet"]?.ToString(),
                            HDH = reader["HDH"].ToString(),
                            ThietKe = reader["ThietKe"].ToString(),
                            KichThuoc_TrongLuong = reader["KichThuoc_TrongLuong"].ToString(),
                            Webcam = reader["Webcam"]?.ToString(),
                            Pin = reader["Pin"].ToString(),
                            RaMat = Convert.ToInt32(reader["RaMat"]),
                            MoTa = reader["MoTa"].ToString(),
                            DonGia = Convert.ToInt64(reader["DonGia"]),
                            HinhAnh = reader["HinhAnh"].ToString(),
                        });

                    }
                }
            }
            return list;
        }

        public SanPham LaySanPham(string masp)
        {

            SanPham SP = new SanPham();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "select * from SanPham where masp=@masp";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@masp", masp);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        SP.MaSP = reader["MaSP"].ToString();
                        SP.ManHinh = reader["ManHinh"].ToString();
                        SP.BoXuLy = reader["BoXuLy"].ToString();
                        SP.RAM = reader["RAM"].ToString();
                        SP.CongKN = reader["CongKetNoi"].ToString();
                        SP.DanhMuc = reader["DanhMuc"].ToString();
                        SP.TenSP = reader["TenSP"].ToString();
                        SP.SoLuong = Convert.ToInt32(reader["SoLuong"]);
                        SP.MauSac = reader["MauSac"].ToString();
                        SP.OCung = reader["OCung"].ToString();
                        SP.CardMH = reader["CardManHinh"].ToString();
                        SP.DacBiet = reader["DacBiet"]?.ToString();
                        SP.HDH = reader["HDH"].ToString();
                        SP.ThietKe = reader["ThietKe"].ToString();
                        SP.KichThuoc_TrongLuong = reader["KichThuoc_TrongLuong"].ToString();
                        SP.Webcam = reader["Webcam"]?.ToString();
                        SP.Pin = reader["Pin"].ToString();
                        SP.RaMat = Convert.ToInt32(reader["RaMat"]);
                        SP.MoTa = reader["MoTa"].ToString();
                        SP.DonGia = Convert.ToInt64(reader["DonGia"]);
                        SP.HinhAnh = reader["HinhAnh"].ToString();
                    };

                }
            }
            return SP;
        }

        public int TaoSanPham(SanPham sp)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "insert into SANPHAM value (?masp, ?manhinh, ?boxuly, ?RAM, ?congketnoi, ?danhmuc, ?tensp, ?soluong, ?mausac, ?ocung, ?cardmanhinh, ?dacbiet, ?hdh, ?thietke,?kichthuoc_trongluong, ?webcam, ?pin, ?ramat,?mota, ?dongia, ?hinhanh) ";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("masp", "");
                cmd.Parameters.AddWithValue("manhinh", sp.ManHinh.ToString());
                cmd.Parameters.AddWithValue("boxuly", sp.BoXuLy.ToString());
                cmd.Parameters.AddWithValue("RAM", sp.RAM.ToString());
                cmd.Parameters.AddWithValue("congketnoi", sp.CongKN.ToString());
                cmd.Parameters.AddWithValue("danhmuc", sp.DanhMuc.ToString());
                cmd.Parameters.AddWithValue("tensp", sp.TenSP.ToString());
                cmd.Parameters.AddWithValue("soluong", Convert.ToInt32(sp.SoLuong));
                cmd.Parameters.AddWithValue("mausac", sp.MauSac.ToString());
                cmd.Parameters.AddWithValue("ocung", sp.OCung.ToString());
                cmd.Parameters.AddWithValue("cardmanhinh", sp.CardMH.ToString());
                cmd.Parameters.AddWithValue("dacbiet", sp.DacBiet?.ToString());
                cmd.Parameters.AddWithValue("hdh", sp.HDH.ToString());
                cmd.Parameters.AddWithValue("thietke", sp.ThietKe.ToString());
                cmd.Parameters.AddWithValue("kichthuoc_trongluong", sp.KichThuoc_TrongLuong.ToString());
                cmd.Parameters.AddWithValue("webcam", sp.Webcam?.ToString());
                cmd.Parameters.AddWithValue("pin", sp.Pin.ToString());
                cmd.Parameters.AddWithValue("ramat", Convert.ToInt32(sp.RaMat));
                cmd.Parameters.AddWithValue("mota", sp.MoTa.ToString());
                cmd.Parameters.AddWithValue("dongia", Convert.ToInt64(sp.DonGia));
                cmd.Parameters.AddWithValue("hinhanh", sp.HinhAnh.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int CapNhatSanPham(SanPham sp)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string masp = sp.MaSP;
                string query = @"update sanpham set masp=@masp, manhinh=@manhinh, boxuly=@boxuly, RAM=@RAM, congketnoi=@congketnoi, danhmuc=@danhmuc, tensp=@tensp,
                                                           soluong=@soluong, mausac=@mausac, ocung=@ocung, cardmanhinh=@cardmanhinh, dacbiet=@dacbiet, hdh=@hdh, thietke=@thietke,
                                                           kichthuoc_trongluong=@kichthuoc_trongluong, webcam=@webcam, pin=@pin, ramat=@ramat,mota=@mota, dongia=@dongia, hinhanh=@hinhanh ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@masp", masp);
                cmd.Parameters.AddWithValue("manhinh", sp.ManHinh.ToString());
                cmd.Parameters.AddWithValue("boxuly", sp.BoXuLy.ToString());
                cmd.Parameters.AddWithValue("RAM", sp.RAM.ToString());
                cmd.Parameters.AddWithValue("congketnoi", sp.CongKN.ToString());
                cmd.Parameters.AddWithValue("danhmuc", sp.DanhMuc.ToString());
                cmd.Parameters.AddWithValue("tensp", sp.TenSP.ToString());
                cmd.Parameters.AddWithValue("soluong", Convert.ToInt32(sp.SoLuong.ToString()));
                cmd.Parameters.AddWithValue("mausac", sp.MauSac.ToString());
                cmd.Parameters.AddWithValue("ocung", sp.OCung.ToString());
                cmd.Parameters.AddWithValue("cardmanhinh", sp.CardMH.ToString());
                cmd.Parameters.AddWithValue("dacbiet", sp.DacBiet?.ToString());
                cmd.Parameters.AddWithValue("hdh", sp.HDH.ToString());
                cmd.Parameters.AddWithValue("thietke", sp.ThietKe.ToString());
                cmd.Parameters.AddWithValue("kichthuoc_trongluong", sp.KichThuoc_TrongLuong.ToString());
                cmd.Parameters.AddWithValue("webcam", sp.Webcam?.ToString());
                cmd.Parameters.AddWithValue("pin", sp.Pin.ToString());
                cmd.Parameters.AddWithValue("ramat", Convert.ToInt32(sp.RaMat.ToString()));
                cmd.Parameters.AddWithValue("mota", sp.MoTa.ToString());
                cmd.Parameters.AddWithValue("dongia", Convert.ToInt64(sp.DonGia.ToString()));
                cmd.Parameters.AddWithValue("hinhanh", sp.HinhAnh.ToString());
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

        public int XoaSanPham(string masp)
        {
            int count = 0;
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string query = "delete from sanpham where masp = @masp ";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@masp", masp); //Binding
                cmd.ExecuteNonQuery();
                count++;
            }
            return count;
        }

    }
}
