using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class KhuyenMai
    {
        public KhuyenMai()
        {
            SanPhamKhuyenMai = new HashSet<SanPhamKhuyenMai>();
        }

        public string MaKm { get; set; }
        public DateTime? NgayBatDau { get; set; }
        public DateTime? NgayKetThuc { get; set; }
        public string NoiDung { get; set; }
        public string TenCt { get; set; }
        public string AnhCt { get; set; }

        public virtual ICollection<SanPhamKhuyenMai> SanPhamKhuyenMai { get; set; }
    }
}
