using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class ThongSo
    {
        public ThongSo()
        {
            ThongSoKiThuat = new HashSet<ThongSoKiThuat>();
        }

        public string TenThongSo { get; set; }
        public string MaThongSo { get; set; }
        public string MaLoai { get; set; }

        public virtual LoaiSp MaLoaiNavigation { get; set; }
        public virtual ICollection<ThongSoKiThuat> ThongSoKiThuat { get; set; }
    }
}
