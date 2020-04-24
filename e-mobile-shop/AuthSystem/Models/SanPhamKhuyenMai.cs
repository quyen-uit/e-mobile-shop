using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class SanPhamKhuyenMai
    {
        public string MaKm { get; set; }
        public string MaSp { get; set; }
        public string MoTa { get; set; }
        public int? GiamGia { get; set; }

        public virtual KhuyenMai MaKmNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
