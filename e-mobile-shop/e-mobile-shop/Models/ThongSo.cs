using System;
using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class ThongSo
    {
        public string TenThongSo { get; set; }
        public string MaThongSo { get; set; }
        public string MaLoai { get; set; }

        public virtual LoaiSp MaLoaiNavigation { get; set; }
    }
}
