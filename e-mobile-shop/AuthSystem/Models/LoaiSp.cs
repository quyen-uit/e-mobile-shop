using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class LoaiSp
    {
        public LoaiSp()
        {
            SanPham = new HashSet<SanPham>();
        }

        public string MaLoai { get; set; }
        public string TenLoai { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
