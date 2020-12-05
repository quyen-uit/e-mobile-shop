using System;
using System.Collections.Generic;

namespace e_mobile_shop.Core.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            SanPham = new HashSet<SanPham>();
        }

        public string MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public int Sdt { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
