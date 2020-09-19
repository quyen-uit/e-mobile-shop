namespace e_mobile_shop.ViewModels
{
    public partial class ThongSoKiThuatViewModel
    {
        public string MaSp { get; set; }
        public string GiaTri { get; set; }
        public string MaTskt { get; set; }
        public string ThongSo { get; set; }

        public virtual SanPhamViewModel MaSpNavigation { get; set; }
        public virtual ThongSoViewModel ThongSoNavigation { get; set; }
    }
}
