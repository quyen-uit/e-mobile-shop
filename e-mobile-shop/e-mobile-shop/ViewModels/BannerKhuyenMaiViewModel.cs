namespace e_mobile_shop.ViewModels
{
    public partial class BannerKhuyenMaiViewModel
    {
        public string MaSp { get; set; }
        public string AnhDaiDien { get; set; }
        public string MaKm { get; set; }
        public string ThongTin { get; set; }
        public int? Status { get; set; }

        public virtual SanPhamViewModel MaSpNavigation { get; set; }
    }
}
