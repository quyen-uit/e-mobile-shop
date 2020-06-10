using System;
using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class ThongSoKiThuat
    {
        public string MaSp { get; set; }
        public string ThuocTinh { get; set; }
        public string GiaTri { get; set; }
        public string MaTskt { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
    }
}
