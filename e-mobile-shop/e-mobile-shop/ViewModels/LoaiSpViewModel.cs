using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class LoaiSpViewModel
    {
        public LoaiSpViewModel()
        {
            SanPham = new HashSet<SanPhamViewModel>();
            ThongSo = new HashSet<ThongSoViewModel>();
        }

        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string Icon { get; set; }

        public virtual ICollection<SanPhamViewModel> SanPham { get; set; }
        public virtual ICollection<ThongSoViewModel> ThongSo { get; set; }
    }
}
