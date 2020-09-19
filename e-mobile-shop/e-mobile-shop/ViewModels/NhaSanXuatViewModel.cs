using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class NhaSanXuatViewModel
    {
        public NhaSanXuatViewModel()
        {
            SanPham = new HashSet<SanPhamViewModel>();
        }

        public string MaNsx { get; set; }
        public string TenNsx { get; set; }
        public string QuocGia { get; set; }
        public int Status { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<SanPhamViewModel> SanPham { get; set; }
    }
}
