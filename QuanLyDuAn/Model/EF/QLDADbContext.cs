namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLDADbContext : DbContext
    {
        public QLDADbContext()
            : base("name=QLDADbContext")
        {
        }

        public virtual DbSet<BangCong> BangCongs { get; set; }
        public virtual DbSet<BoPhan> BoPhans { get; set; }
        public virtual DbSet<ChiTietLichLamViec> ChiTietLichLamViecs { get; set; }
        public virtual DbSet<CongViec> CongViecs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LichLamViec> LichLamViecs { get; set; }
        public virtual DbSet<LoaiCongViec> LoaiCongViecs { get; set; }
        public virtual DbSet<NhacNho> NhacNhoes { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<NhanVienQuyen> NhanVienQuyens { get; set; }
        public virtual DbSet<PhongBan> PhongBans { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<VaiTro> VaiTroes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BangCong>()
                .Property(e => e.MaCC)
                .IsUnicode(false);

            modelBuilder.Entity<BangCong>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<BangCong>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<BoPhan>()
                .Property(e => e.MaBP)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietLichLamViec>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietLichLamViec>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<ChiTietLichLamViec>()
                .Property(e => e.GhiChu)
                .IsUnicode(false);

            modelBuilder.Entity<CongViec>()
                .Property(e => e.MaCV)
                .IsUnicode(false);

            modelBuilder.Entity<CongViec>()
                .Property(e => e.MaKH)
                .IsUnicode(false);

            modelBuilder.Entity<CongViec>()
                .Property(e => e.MaLCV)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.MaKH)
                .IsFixedLength();

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoTK)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<LichLamViec>()
                .Property(e => e.MaLLV)
                .IsUnicode(false);

            modelBuilder.Entity<LichLamViec>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<LichLamViec>()
                .Property(e => e.TGLam)
                .IsUnicode(false);

            modelBuilder.Entity<LoaiCongViec>()
                .Property(e => e.MaLCV)
                .IsUnicode(false);

            modelBuilder.Entity<NhacNho>()
                .Property(e => e.MaNN)
                .IsUnicode(false);

            modelBuilder.Entity<NhacNho>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaVT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MaBP)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.TaiKhoan)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.MatKhau)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoTK)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVien>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<NhanVienQuyen>()
                .Property(e => e.MaVT)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.MaPB)
                .IsUnicode(false);

            modelBuilder.Entity<PhongBan>()
                .Property(e => e.SoDT)
                .IsUnicode(false);

            modelBuilder.Entity<Quyen>()
                .Property(e => e.TenQuyen)
                .IsUnicode(false);

            modelBuilder.Entity<VaiTro>()
                .Property(e => e.MaVT)
                .IsUnicode(false);
        }
    }
}
