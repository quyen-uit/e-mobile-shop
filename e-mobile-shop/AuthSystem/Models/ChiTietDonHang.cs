using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class ChiTietDonHang
    {
        public string MaDh { get; set; }
        public string MaSp { get; set; }
        public int? SoLuong { get; set; }
        public decimal? ThanhTien { get; set; }

        public virtual DonHangKh MaDhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
