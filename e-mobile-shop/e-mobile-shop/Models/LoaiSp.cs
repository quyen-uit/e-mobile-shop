﻿using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            SanPham = new HashSet<SanPham>();
            ThongSo = new HashSet<ThongSo>();
        }

        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
        public virtual ICollection<ThongSo> ThongSo { get; set; }
    }
}
