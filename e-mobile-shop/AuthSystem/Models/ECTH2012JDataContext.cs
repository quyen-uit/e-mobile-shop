using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AuthSystem.Models
{
    public partial class ECTH2012JDataContext : DbContext
    {
        public ECTH2012JDataContext()
        {
        }

        public ECTH2012JDataContext(DbContextOptions<ECTH2012JDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<BinhLuan> BinhLuan { get; set; }
        public virtual DbSet<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual DbSet<ConfigApi> ConfigApi { get; set; }
        public virtual DbSet<DanhsachdangkisanphamNcc> DanhsachdangkisanphamNcc { get; set; }
        public virtual DbSet<DonHangKh> DonHangKh { get; set; }
        public virtual DbSet<GiaoDien> GiaoDien { get; set; }
        public virtual DbSet<HangSanXuat> HangSanXuat { get; set; }
        public virtual DbSet<HopDongNcc> HopDongNcc { get; set; }
        public virtual DbSet<KhuyenMai> KhuyenMai { get; set; }
        public virtual DbSet<Link> Link { get; set; }
        public virtual DbSet<LoaiSp> LoaiSp { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<Oauth> Oauth { get; set; }
        public virtual DbSet<SanPham> SanPham { get; set; }
        public virtual DbSet<SanPhamKhuyenMai> SanPhamKhuyenMai { get; set; }
        public virtual DbSet<Sanphamcanmua> Sanphamcanmua { get; set; }
        public virtual DbSet<ThongSoKyThuat> ThongSoKyThuat { get; set; }
        public virtual DbSet<Trackingaction> Trackingaction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                DbContextOptionsBuilder dbContextOptionsBuilder = optionsBuilder.UseSqlServer("Data Source=DESKTOP-R3PM237;Initial Catalog=EC-TH2012-J-Data;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
                    .HasName("PK_dbo.AspNetUserLogins");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId })
                    .HasName("PK_dbo.AspNetUserRoles");

                entity.HasIndex(e => e.RoleId)
                    .HasName("IX_RoleId");

                entity.HasIndex(e => e.UserId)
                    .HasName("IX_UserId");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.Property(e => e.RoleId).HasMaxLength(128);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("EmailIndex")
                    .IsUnique();

                entity.HasIndex(e => e.UserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Id).HasMaxLength(128);

                entity.Property(e => e.Avatar)
                    .HasColumnType("text")
                    .HasDefaultValueSql("('noavatar.jpg')");

                entity.Property(e => e.Cmnd)
                    .HasColumnName("CMND")
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(256);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

                entity.Property(e => e.MaNv)
                    .HasColumnName("MaNV")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.NgaySinh).HasColumnType("date");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<BinhLuan>(entity =>
            {
                entity.HasKey(e => e.MaBl);

                entity.Property(e => e.MaBl).HasColumnName("MaBL");

                entity.Property(e => e.DaTraLoi)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength()
                    .HasDefaultValueSql("('C')");

                entity.Property(e => e.Email).HasMaxLength(128);

                entity.Property(e => e.HoTen).HasMaxLength(50);

                entity.Property(e => e.MaKh)
                    .HasColumnName("MaKH")
                    .HasMaxLength(128);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.NgayDang).HasColumnType("datetime");

                entity.Property(e => e.NoiDung).HasColumnType("ntext");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.BinhLuan)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BinhLuan_AspNetUsers");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.BinhLuan)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_BinhLuan_SanPham");
            });

            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(e => new { e.MaDh, e.MaSp })
                    .HasName("PK__ChiTietD__F557D6E0BC3C681D");

                entity.Property(e => e.MaDh)
                    .HasColumnName("MaDH")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.ThanhTien).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.MaDhNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.MaDh)
                    .HasConstraintName("FK_ChiTietDonHang_DonHangKH");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ChiTietDonHang)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_ChiTietDonHang_SanPham");
            });

            modelBuilder.Entity<ConfigApi>(entity =>
            {
                entity.ToTable("ConfigAPI");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LinkAccessToken)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkKiemTraLuongTon)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkRequesrToken)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LinkXacNhanGiaoHang)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.ConfigApi)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK_Config_NhaCC");
            });

            modelBuilder.Entity<DanhsachdangkisanphamNcc>(entity =>
            {
                entity.ToTable("DanhsachdangkisanphamNCC");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ghichu).HasColumnType("text");

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MaSpcanMua).HasColumnName("MaSPCanMua");

                entity.Property(e => e.NgayDk)
                    .HasColumnName("NgayDK")
                    .HasColumnType("datetime");

                entity.Property(e => e.TienmoiSp).HasColumnName("TienmoiSP");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.DanhsachdangkisanphamNcc)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("FK_DKNCC_NCC");

                entity.HasOne(d => d.MaSpcanMuaNavigation)
                    .WithMany(p => p.DanhsachdangkisanphamNcc)
                    .HasForeignKey(d => d.MaSpcanMua)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_SPCM_DKNCC");
            });

            modelBuilder.Entity<DonHangKh>(entity =>
            {
                entity.HasKey(e => e.MaDh)
                    .HasName("PK__DonHangK__2725866122F32CEB");

                entity.ToTable("DonHangKH");

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
                    .IsRequired()
                    .HasColumnName("MaKH")
                    .HasMaxLength(128);

                entity.Property(e => e.NgayDatMua).HasColumnType("datetime");

                entity.Property(e => e.PhiVanChuyen).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.PtgiaoDich)
                    .HasColumnName("PTGiaoDich")
                    .HasMaxLength(200);

                entity.Property(e => e.TinhTrangDh).HasColumnName("TinhTrangDH");

                entity.HasOne(d => d.MaKhNavigation)
                    .WithMany(p => p.DonHangKh)
                    .HasForeignKey(d => d.MaKh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DonHangKH_AspNetUsers");
            });

            modelBuilder.Entity<GiaoDien>(entity =>
            {
                entity.HasIndex(e => e.ThuocTinh)
                    .IsUnique();

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.GiaTri).HasColumnType("ntext");

                entity.Property(e => e.ThuocTinh)
                    .IsRequired()
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<HangSanXuat>(entity =>
            {
                entity.HasKey(e => e.HangSx)
                    .HasName("PK__HangSanX__F984F384221F8726");

                entity.HasIndex(e => e.TenHang)
                    .IsUnique();

                entity.Property(e => e.HangSx)
                    .HasColumnName("HangSX")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.QuocGia).HasMaxLength(50);

                entity.Property(e => e.TenHang).HasMaxLength(50);

                entity.Property(e => e.TruSoChinh).HasMaxLength(200);
            });

            modelBuilder.Entity<HopDongNcc>(entity =>
            {
                entity.HasKey(e => e.MaHd)
                    .HasName("PK__HopDongN__2725A6E0B53555A1");

                entity.ToTable("HopDongNCC");

                entity.Property(e => e.MaHd)
                    .HasColumnName("MaHD")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Dateaccept).HasColumnType("datetime");

                entity.Property(e => e.DonGia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.NgayKy).HasColumnType("date");

                entity.Property(e => e.SlcungCap).HasColumnName("SLCungCap");

                entity.Property(e => e.SltoiThieu).HasColumnName("SLToiThieu");

                entity.Property(e => e.TggiaoHang)
                    .HasColumnName("TGGiaoHang")
                    .HasColumnType("datetime");

                entity.Property(e => e.ThoiHanHd).HasColumnName("ThoiHanHD");

                entity.Property(e => e.TtthanhToan).HasColumnName("TTThanhToan");

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.HopDongNcc)
                    .HasForeignKey(d => d.MaNcc)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_Table_NhaCungCap");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.HopDongNcc)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_HopDongNCC_SanPham");
            });

            modelBuilder.Entity<KhuyenMai>(entity =>
            {
                entity.HasKey(e => e.MaKm);

                entity.HasIndex(e => e.TenCt)
                    .IsUnique();

                entity.Property(e => e.MaKm)
                    .HasColumnName("MaKM")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.AnhCt)
                    .HasColumnName("AnhCT")
                    .HasColumnType("text");

                entity.Property(e => e.NgayBatDau).HasColumnType("date");

                entity.Property(e => e.NgayKetThuc).HasColumnType("date");

                entity.Property(e => e.NoiDung).HasColumnType("ntext");

                entity.Property(e => e.TenCt)
                    .IsRequired()
                    .HasColumnName("TenCT")
                    .HasMaxLength(128);
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasIndex(e => e.Text)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Group).HasMaxLength(50);

                entity.Property(e => e.Image).HasColumnType("text");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasMaxLength(128);

                entity.Property(e => e.Url).HasColumnType("text");
            });

            modelBuilder.Entity<LoaiSp>(entity =>
            {
                entity.HasKey(e => e.MaLoai)
                    .HasName("PK__LoaiSP__730A5759C6601AB6");

                entity.ToTable("LoaiSP");

                entity.HasIndex(e => e.TenLoai)
                    .IsUnique();

                entity.Property(e => e.MaLoai)
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.TenLoai)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<NhaCungCap>(entity =>
            {
                entity.HasKey(e => e.MaNcc)
                    .HasName("PK__NhaCungC__3A185DEBEBF82597");

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.DiaChi).HasMaxLength(200);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.NetUser)
                    .HasColumnName("Net_user")
                    .HasMaxLength(128);

                entity.Property(e => e.SdtNcc)
                    .HasColumnName("SDT_NCC")
                    .HasMaxLength(11)
                    .IsFixedLength();

                entity.Property(e => e.TenNcc)
                    .IsRequired()
                    .HasColumnName("TenNCC")
                    .HasMaxLength(50);

                entity.Property(e => e.Website).HasColumnType("text");

                entity.HasOne(d => d.NetUserNavigation)
                    .WithMany(p => p.NhaCungCap)
                    .HasForeignKey(d => d.NetUser)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK_NhaCC_Netuser");
            });

            modelBuilder.Entity<Oauth>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Callback)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ConsumerKey)
                    .HasColumnName("Consumer_key")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.DateComsumer)
                    .HasColumnName("Date_comsumer")
                    .HasColumnType("datetime");

                entity.Property(e => e.ExpiresTime).HasColumnType("datetime");

                entity.Property(e => e.MaNcc)
                    .HasColumnName("MaNCC")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.RequestToken)
                    .HasColumnName("Request_token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .HasMaxLength(120)
                    .IsUnicode(false);

                entity.Property(e => e.VerifierToken)
                    .HasColumnName("Verifier_token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaNccNavigation)
                    .WithMany(p => p.Oauth)
                    .HasForeignKey(d => d.MaNcc)
                    .HasConstraintName("PK_Oauth_NhaCC");
            });

            modelBuilder.Entity<SanPham>(entity =>
            {
                entity.HasKey(e => e.MaSp)
                    .HasName("PK__tmp_ms_x__2725081C792CCE6E");

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

                entity.HasOne(d => d.HangSxNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.HangSx)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_HangSanXuat");

                entity.HasOne(d => d.LoaiSpNavigation)
                    .WithMany(p => p.SanPham)
                    .HasForeignKey(d => d.LoaiSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SanPham_LoaiSP");
            });

            modelBuilder.Entity<SanPhamKhuyenMai>(entity =>
            {
                entity.HasKey(e => new { e.MaKm, e.MaSp });

                entity.Property(e => e.MaKm)
                    .HasColumnName("MaKM")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.MoTa).HasColumnType("ntext");

                entity.HasOne(d => d.MaKmNavigation)
                    .WithMany(p => p.SanPhamKhuyenMai)
                    .HasForeignKey(d => d.MaKm)
                    .HasConstraintName("FK_SanPhamKhuyenMai_KhuyenMai");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.SanPhamKhuyenMai)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_SanPhamKhuyenMai_SanPham");
            });

            modelBuilder.Entity<Sanphamcanmua>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.MaSp)
                    .IsRequired()
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Mota).HasColumnType("ntext");

                entity.Property(e => e.Ngaydang).HasColumnType("datetime");

                entity.Property(e => e.Ngayketthuc).HasColumnType("datetime");

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.Sanphamcanmua)
                    .HasForeignKey(d => d.MaSp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PK_SPCM_SP");
            });

            modelBuilder.Entity<ThongSoKyThuat>(entity =>
            {
                entity.HasKey(e => new { e.MaSp, e.ThuocTinh, e.GiaTri });

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.ThuocTinh).HasMaxLength(50);

                entity.Property(e => e.GiaTri).HasMaxLength(256);

                entity.HasOne(d => d.MaSpNavigation)
                    .WithMany(p => p.ThongSoKyThuat)
                    .HasForeignKey(d => d.MaSp)
                    .HasConstraintName("FK_ThongSoKyThuat_SanPham");
            });

            modelBuilder.Entity<Trackingaction>(entity =>
            {
                entity.Property(e => e.Action).HasMaxLength(50);

                entity.Property(e => e.Controller).HasMaxLength(50);

                entity.Property(e => e.MaSp)
                    .HasColumnName("MaSP")
                    .HasMaxLength(5)
                    .IsFixedLength();

                entity.Property(e => e.Ngaythuchien).HasColumnType("datetime");

                entity.Property(e => e.Username).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
