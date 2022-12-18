using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Test.Models;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Test.Data
{
    public partial class LapTopContext : IdentityDbContext<AppUser>
    {
        public LapTopContext()
        {
        }

        public LapTopContext(DbContextOptions<LapTopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cthd> Cthd { get; set; }
        public virtual DbSet<Danhmucsanpham> Danhmucsanpham { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Sanpham> Sanpham { get; set; }
        public virtual DbSet<Sukien> Sukien { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<Size> Size { get; set; }
        public virtual DbSet<AppUser> AppUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=admin;database=LapTop");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Cthd>(entity =>
            {
                entity.HasKey(e => new { e.Mahd, e.Masp })
                    .HasName("PRIMARY");

                entity.ToTable("cthd");

                entity.HasIndex(e => e.Masp)
                    .HasName("FK_CTHD2");

                entity.Property(e => e.Mahd)
                    .HasColumnName("MAHD")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Masp)
                    .HasColumnName("MASP")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MahdNavigation)
                    .WithMany(p => p.Cthd)
                    .HasForeignKey(d => d.Mahd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.Cthd)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CTHD2");
            });

            modelBuilder.Entity<Danhmucsanpham>(entity =>
            {
                entity.HasKey(e => e.Madm)
                    .HasName("PRIMARY");

                entity.ToTable("danhmucsanpham");

                entity.Property(e => e.Madm)
                    .HasColumnName("MADM")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Tendm)
                    .HasColumnName("TENDM")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahd)
                    .HasName("PRIMARY");

                entity.ToTable("hoadon");

                entity.HasIndex(e => e.Makh)
                    .HasName("FK_THUOC");

                //entity.HasIndex(e => e.Manv)
                //    .HasName("FK_LAP");

                entity.HasIndex(e => e.Mask)
                    .HasName("FK_HD_SK");

                entity.Property(e => e.Mahd)
                    .HasColumnName("MAHD")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Diachigiaohang)
                    .HasColumnName("DIACHIGIAOHANG")
                    .HasMaxLength(100);

                entity.Property(e => e.Makh)
                    .IsRequired()
                    .HasColumnName("MAKH")
                    .HasMaxLength(6)
                    .IsFixedLength();

                //entity.Property(e => e.Manv)
                //    .IsRequired()
                //    .HasColumnName("MANV")
                //    .HasMaxLength(6)
                //    .IsFixedLength();

                entity.Property(e => e.Mask)
                    .HasColumnName("MASK")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Ngayhd)
                    .HasColumnName("NGAYHD")
                    .HasColumnType("date");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

                entity.Property(e => e.Tongtien).HasColumnName("TONGTIEN");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THUOC");

                //entity.HasOne(d => d.ManvNavigation)
                //    .WithMany(p => p.Hoadon)
                //    .HasForeignKey(d => d.Manv)
                //    .OnDelete(DeleteBehavior.ClientSetNull)
                //    .HasConstraintName("FK_LAP");

                entity.HasOne(d => d.MaskNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Mask)
                    .HasConstraintName("FK_HD_SK");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PRIMARY");

                entity.ToTable("khachhang");

                entity.HasIndex(e => e.Tendangnhap)
                    .HasName("FK_CO2");

                entity.Property(e => e.Makh)
                    .HasColumnName("MAKH")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(50);

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Sodt)
                    .HasColumnName("SODT")
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.Tendangnhap)
                    .IsRequired()
                    .HasColumnName("TENDANGNHAP")
                    .HasMaxLength(10);

                entity.Property(e => e.Tenkh)
                    .HasColumnName("TENKH")
                    .HasMaxLength(50);

                entity.HasOne(d => d.TendangnhapNavigation)
                    .WithMany(p => p.Khachhang)
                    .HasForeignKey(d => d.Tendangnhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO2");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv)
                    .HasName("PRIMARY");

                entity.ToTable("nhanvien");

                entity.HasIndex(e => e.Tendangnhap)
                    .HasName("FK_CO1");

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Chucvu)
                    .HasColumnName("CHUCVU")
                    .HasMaxLength(10);

                entity.Property(e => e.Diachi)
                    .HasColumnName("DIACHI")
                    .HasMaxLength(100);

                entity.Property(e => e.Gioitinh)
                    .HasColumnName("GIOITINH")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Ngaysinh)
                    .HasColumnName("NGAYSINH")
                    .HasColumnType("date");

                entity.Property(e => e.Ngayvl)
                    .HasColumnName("NGAYVL")
                    .HasColumnType("date");

                entity.Property(e => e.Sodt)
                    .HasColumnName("SODT")
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.Tendangnhap)
                    .IsRequired()
                    .HasColumnName("TENDANGNHAP")
                    .HasMaxLength(20);

                entity.Property(e => e.Tennv)
                    .HasColumnName("TENNV")
                    .HasMaxLength(50);

                entity.HasOne(d => d.TendangnhapNavigation)
                    .WithMany(p => p.Nhanvien)
                    .HasForeignKey(d => d.Tendangnhap)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CO1");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PRIMARY");

                entity.ToTable("sanpham");

                entity.HasIndex(e => e.Danhmuc)
                    .HasName("FK_THUOC1");

                entity.Property(e => e.Masp)
                    .HasColumnName("MASP")
                    .HasMaxLength(6)
                    .IsFixedLength();


                entity.Property(e => e.Danhmuc)
                    .IsRequired()
                    .HasColumnName("DANHMUC")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(200);


                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(200);

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tensp)
                    .HasColumnName("TENSP")
                    .HasMaxLength(100);


                entity.HasOne(d => d.DanhmucNavigation)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.Danhmuc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THUOC1");
                entity.HasOne(d => d.SizeNavigation)
                    .WithMany(p => p.Sanpham)
                    .HasForeignKey(d => d.Size)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THUOC3");
            });

            modelBuilder.Entity<Sukien>(entity =>
            {
                entity.HasKey(e => e.Mask)
                    .HasName("PRIMARY");

                entity.ToTable("sukien");

                entity.Property(e => e.Mask)
                    .HasColumnName("MASK")
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(e => e.Ngaybd)
                    .HasColumnName("NGAYBD")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaykt)
                    .HasColumnName("NGAYKT")
                    .HasColumnType("date");

                entity.Property(e => e.Phantramgiamgia).HasColumnName("PHANTRAMGIAMGIA");

                entity.Property(e => e.Tensk)
                    .HasColumnName("TENSK")
                    .HasMaxLength(50);

            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Tendangnhap)
                    .HasName("PRIMARY");

                entity.ToTable("taikhoan");

                entity.Property(e => e.Tendangnhap)
                    .HasColumnName("TENDANGNHAP")
                    .HasMaxLength(20);

                entity.Property(e => e.Matkhau)
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
            // Bỏ tiền tố AspNet của các bảng: mặc định các bảng trong IdentityDbContext có
            // tên với tiền tố AspNet như: AspNetUserRoles, AspNetUser ...
            // Đoạn mã sau chạy khi khởi tạo DbContext, tạo database sẽ loại bỏ tiền tố đó
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
