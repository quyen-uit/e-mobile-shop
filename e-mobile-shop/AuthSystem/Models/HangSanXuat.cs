using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class HangSanXuat
    {
        public HangSanXuat()
        {
            SanPham = new HashSet<SanPham>();
        }

        public string HangSx { get; set; }
        public string TenHang { get; set; }
        public string TruSoChinh { get; set; }
        public string QuocGia { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
