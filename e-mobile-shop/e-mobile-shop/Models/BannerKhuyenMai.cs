using System;
using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class BannerKhuyenMai
    {
        public string MaSp { get; set; }
        public string AnhDaiDien { get; set; }
        public string MaKm { get; set; }
        public string ThongTin { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
    }
}
