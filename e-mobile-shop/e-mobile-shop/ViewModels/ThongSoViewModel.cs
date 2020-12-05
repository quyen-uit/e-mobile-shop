using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class ThongSoViewModel
    {
        public ThongSoViewModel()
        {
            ThongSoKiThuat = new HashSet<ThongSoKiThuatViewModel>();
        }

        public string TenThongSo { get; set; }
        public string MaThongSo { get; set; }
        public string MaLoai { get; set; }

        public virtual LoaiSpViewModel MaLoaiNavigation { get; set; }
        public virtual ICollection<ThongSoKiThuatViewModel> ThongSoKiThuat { get; set; }
    }
}
