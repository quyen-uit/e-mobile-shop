using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            BinhLuan = new HashSet<BinhLuan>();
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            HopDongNcc = new HashSet<HopDongNcc>();
            SanPhamKhuyenMai = new HashSet<SanPhamKhuyenMai>();
            Sanphamcanmua = new HashSet<Sanphamcanmua>();
            ThongSoKyThuat = new HashSet<ThongSoKyThuat>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string LoaiSp { get; set; }
        public int? SoLuotXemSp { get; set; }
        public string HangSx { get; set; }
        public string XuatXu { get; set; }
        public decimal? GiaGoc { get; set; }
        public decimal? GiaTien { get; set; }
        public string MoTa { get; set; }
        public string AnhDaiDien { get; set; }
        public string AnhNen { get; set; }
        public string AnhKhac { get; set; }
        public int? SoLuong { get; set; }
        public bool? Isnew { get; set; }
        public bool? Ishot { get; set; }

        public virtual HangSanXuat HangSxNavigation { get; set; }
        public virtual LoaiSp LoaiSpNavigation { get; set; }
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual ICollection<HopDongNcc> HopDongNcc { get; set; }
        public virtual ICollection<SanPhamKhuyenMai> SanPhamKhuyenMai { get; set; }
        public virtual ICollection<Sanphamcanmua> Sanphamcanmua { get; set; }
        public virtual ICollection<ThongSoKyThuat> ThongSoKyThuat { get; set; }
    }
}
