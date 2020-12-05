using System;

namespace e_mobile_shop.ViewModels
{
    public partial class BinhLuanViewModel
    {
        public string MaBl { get; set; }
        public string MaSp { get; set; }
        public string MaKh { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DaTraLoi { get; set; }
        public int? Parent { get; set; }
        public int? Status { get; set; }

        public virtual AspNetUsersViewModel MaKhNavigation { get; set; }
        public virtual SanPhamViewModel MaSpNavigation { get; set; }
    }
}
