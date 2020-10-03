using System;
using System.Collections.Generic;

namespace e_mobile_shop.Core.Models
{
    public partial class NhaSanXuat
    {
        public NhaSanXuat()
        {
            SanPham = new HashSet<SanPham>();
        }

        public string MaNsx { get; set; }
        public string TenNsx { get; set; }
        public string QuocGia { get; set; }
        public int Status { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<SanPham> SanPham { get; set; }
    }
}
