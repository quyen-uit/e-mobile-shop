using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class SanPhamViewModel
    {
        public SanPhamViewModel()
        {
            AnhSanPham = new HashSet<AnhSanPhamViewModel>();
            BannerKhuyenMai = new HashSet<BannerKhuyenMaiViewModel>();
            BinhLuan = new HashSet<BinhLuanViewModel>();
            ChiTietDonHang = new HashSet<ChiTietDonHangViewModel>();
            ThongSoKiThuat = new HashSet<ThongSoKiThuatViewModel>();
        }

        public string MaSp { get; set; }
        public string TenSp { get; set; }
        public string LoaiSp { get; set; }
        public int? SoLuotXemSp { get; set; }
        public decimal? GiaGoc { get; set; }
        public decimal? GiaTien { get; set; }
        public string MoTa { get; set; }
        public string AnhDaiDien { get; set; }
        public string AnhNen { get; set; }
        public string AnhKhac { get; set; }
        public int? SoLuong { get; set; }
<<<<<<< HEAD
        public bool? Isnew { get; set; }
        public bool? Ishot { get; set; }
=======
        public bool Isnew { get; set; }
        public bool Ishot { get; set; }
>>>>>>> origin/refactor-code-quyen
        public int? Status { get; set; }
        public int? IsOnline { get; set; }
        public string MaNcc { get; set; }
        public string Nsx { get; set; }

        public virtual LoaiSpViewModel LoaiSpNavigation { get; set; }
        public virtual NhaCungCapViewModel MaNccNavigation { get; set; }
        public virtual NhaSanXuatViewModel NsxNavigation { get; set; }
        public virtual ICollection<AnhSanPhamViewModel> AnhSanPham { get; set; }
        public virtual ICollection<BannerKhuyenMaiViewModel> BannerKhuyenMai { get; set; }
        public virtual ICollection<BinhLuanViewModel> BinhLuan { get; set; }
        public virtual ICollection<ChiTietDonHangViewModel> ChiTietDonHang { get; set; }
        public virtual ICollection<ThongSoKiThuatViewModel> ThongSoKiThuat { get; set; }
    }
}
