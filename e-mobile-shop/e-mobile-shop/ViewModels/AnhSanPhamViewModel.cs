namespace e_mobile_shop.ViewModels
{
    public partial class AnhSanPhamViewModel
    {
        public string Anh1 { get; set; }
        public string Anh2 { get; set; }
        public string Anh3 { get; set; }
        public string Id { get; set; }
        public string MaSp { get; set; }

        public virtual SanPhamViewModel MaSpNavigation { get; set; }
    }
}
