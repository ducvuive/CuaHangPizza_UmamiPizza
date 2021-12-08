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

        
    }
}
