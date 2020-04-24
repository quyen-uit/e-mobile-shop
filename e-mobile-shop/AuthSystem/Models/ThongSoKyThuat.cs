using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class ThongSoKyThuat
    {
        public string MaSp { get; set; }
        public string ThuocTinh { get; set; }
        public string GiaTri { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
    }
}
