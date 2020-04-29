﻿using System;
using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            AnhSanPham = new HashSet<AnhSanPham>();
            BannerKhuyenMai = new HashSet<BannerKhuyenMai>();
            BinhLuan = new HashSet<BinhLuan>();
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            ThongSoKiThuat = new HashSet<ThongSoKiThuat>();
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

        public virtual LoaiSp LoaiSpNavigation { get; set; }
        public virtual ICollection<AnhSanPham> AnhSanPham { get; set; }
        public virtual ICollection<BannerKhuyenMai> BannerKhuyenMai { get; set; }
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual ICollection<ThongSoKiThuat> ThongSoKiThuat { get; set; }
    }
}