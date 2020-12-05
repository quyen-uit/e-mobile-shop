namespace e_mobile_shop.Models
{
    public partial class ChiTietDonHang
    {
        public string MaDh { get; set; }
        public string MaSp { get; set; }
        public int? SoLuong { get; set; }
        public double? ThanhTien { get; set; }
        public string MaCtdh { get; set; }

        public virtual DonHang MaDhNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
