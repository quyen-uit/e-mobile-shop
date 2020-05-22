using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace e_mobile_shop.Models
{
    public partial class ClientDbContext : DbContext
    {
        public ClientDbContext()
        {
        }

        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AnhSanPham> AnhSanPham { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BannerKhuyenMai> BannerKhuyenMai { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<DonHang> DonHang { get; set; }
        public virtual DbSet<LoaiSp> LoaiSp { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<ThongSoKiThuat> ThongSoKiThuat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3PM237;Initial Catalog=eShopDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnhSanPham>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Anh1).HasColumnType("text");

                entity.Property(e => e.Anh2).HasColumnType("text");

                entity.Property(e => e.Anh3).HasColumnType("text");

                entity.Property(e => e.MaSp)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.AnhSanPham)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_AnhSanPham_SanPham");
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Avatar).HasColumnType("text");

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(20);

                entity.Property(e => e.DiaChi).HasColumnType("text");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.HoTen).HasMaxLength(100);

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<BannerKhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKm);

                entity.Property(e => e.MaKm)
                    .HasColumnName("MaKM")
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien).HasMaxLength(100);

                entity.Property(e => e.MaSp)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.ThongTin).HasColumnType("text");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.BannerKhuyenMai)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_BannerKhuyenMai_SanPham");
            });

            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.HasKey(e => e.MaBl);

                entity.Property(e => e.MaBl)
                    .HasColumnName("MaBL")
                    .ValueGeneratedNever();

                entity.Property(e => e.DaTraLoi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(450);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.NgayDang).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasColumnType("ntext");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.BinhLuan)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK_BinhLuan_AspNetUsers");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.BinhLuan)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_BinhLuan_SanPham");
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => e.MaCtdh)
                    .HasName("PK__ChiTietD__1E4E40F077BB8AE3");

                entity.Property(e => e.MaCtdh)
                    .HasColumnName("MaCTDH")
                    .HasMaxLength(20);

                entity.Property(e => e.MaDh)
                    .IsRequired()
                    .HasColumnName("MaDH")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MaSp)
                    .IsRequired()
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.MaDh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_DonHang");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietDonHang_SanPham");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDh);

                entity.Property(e => e.MaDh)
                    .HasColumnName("MaDH")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Diachi).HasMaxLength(100);

                entity.Property(e => e.Dienthoai)
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.Ghichu).HasColumnType("text");

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(450);

                entity.Property(e => e.NgayDatMua).HasColumnType("datetime");

                entity.Property(e => e.PhiVanChuyen).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PtgiaoDich)
                    .HasColumnName("PTGiaoDich")
                    .HasMaxLength(200);

                entity.Property(e => e.TinhTrangDh).HasColumnName("TinhTrangDH");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHang)
                    .HasForeignKey(d => d.MaKh)
                    .HasConstraintName("FK__DonHang__MaKH__7C4F7684");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai);

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.AnhDaiDien).HasColumnType("ntext");

                entity.Property(e => e.AnhKhac).HasColumnType("ntext");

                entity.Property(e => e.AnhNen).HasColumnType("ntext");

                entity.Property(e => e.GiaGoc).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.GiaTien).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HangSx)
                    .IsRequired()
                    .HasColumnName("HangSX")
                    .HasMaxLength(5)
                    .IsFixedLength()
                    .HasDefaultValueSql("('NOTTT')");

                entity.Property(e => e.IsOnline).HasColumnName("isOnline");

                entity.Property(e => e.Ishot).HasColumnName("ishot");

                entity.Property(e => e.Isnew).HasColumnName("isnew");

                entity.Property(e => e.LoaiSp)
                    .IsRequired()
                    .HasColumnName("LoaiSP")
                    .HasMaxLength(5)
                    .IsFixedLength()
                    .HasDefaultValueSql("('NOTTT')");

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.Property(e => e.SoLuotXemSp).HasColumnName("SoLuotXemSP");

                entity.Property(e => e.TenSp)
                    .IsRequired()
                    .HasColumnName("TenSP")
                    .HasMaxLength(50);

                entity.Property(e => e.XuatXu).HasMaxLength(50);

                entity.HasOne(d => d.LoaiSpNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.LoaiSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_LoaiSp");
            });

            modelBuilder.Entity<ThongSoKiThuat>(entity =>
            {
                entity.HasKey(e => e.MaTskt)
                    .HasName("PK__ThongSoK__475C93A1CED312BD");

                entity.Property(e => e.MaTskt)
                    .HasColumnName("MaTSKT")
                    .HasMaxLength(10);

                entity.Property(e => e.GiaTri)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.MaSp)
                    .IsRequired()
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.ThuocTinh)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ThongSoKiThuat)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ThongSoKiThuat_SanPham");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
