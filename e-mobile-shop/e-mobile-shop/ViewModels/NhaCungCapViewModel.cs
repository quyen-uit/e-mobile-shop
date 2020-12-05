using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class NhaCungCapViewModel
    {
        public NhaCungCapViewModel()
        {
            SanPham = new HashSet<SanPhamViewModel>();
        }

        public string MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public int Sdt { get; set; }
        public string Email { get; set; }
        public int Status { get; set; }

        public virtual ICollection<SanPhamViewModel> SanPham { get; set; }
    }
}
