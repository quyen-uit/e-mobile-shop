namespace e_mobile_shop.ViewModels
{
    public partial class ChiTietDonHangViewModel
    {
        public string MaDh { get; set; }
        public string MaSp { get; set; }
        public int? SoLuong { get; set; }
        public double? ThanhTien { get; set; }
        public string MaCtdh { get; set; }

        public virtual DonHangViewModel MaDhNavigation { get; set; }
        public virtual SanPhamViewModel MaSpNavigation { get; set; }
    }
}
