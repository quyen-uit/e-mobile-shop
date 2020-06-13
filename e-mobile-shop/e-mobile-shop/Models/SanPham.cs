using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace e_mobile_shop.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            AnhSanPham = new HashSet<AnhSanPham>();
            BannerKhuyenMai = new HashSet<BannerKhuyenMai>();
            BinhLuan = new HashSet<BinhLuan>();
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
            ThongSoKiThuat = new HashSet<ThongSoKiThuat>();
        }

        public string MaSp { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tên sản phẩm.")]
        [StringLength(maximumLength:50,ErrorMessage ="Tên sản phẩm chỉ được nhập tối đa 50 kí tự")]
        public string TenSp { get; set; }
        public string LoaiSp { get; set; }
        public int? SoLuotXemSp { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập giá gốc.")]
        public decimal? GiaGoc { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập giá bán.")]
        public decimal? GiaTien { get; set; }
       // [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mô tả.")]
        public string MoTa { get; set; }
        public string AnhDaiDien { get; set; }
        public string AnhNen { get; set; }
        public string AnhKhac { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập số lượng.")]
        public int? SoLuong { get; set; }
        public bool Isnew { get; set; }
        public bool Ishot { get; set; }
        public int? Status { get; set; }
        public int? IsOnline { get; set; }
        public string MaNcc { get; set; }
        public string Nsx { get; set; }

        public virtual LoaiSp LoaiSpNavigation { get; set; }
        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual NhaSanXuat NsxNavigation { get; set; }
        public virtual ICollection<AnhSanPham> AnhSanPham { get; set; }
        public virtual ICollection<BannerKhuyenMai> BannerKhuyenMai { get; set; }
        public virtual ICollection<BinhLuan> BinhLuan { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
        public virtual ICollection<ThongSoKiThuat> ThongSoKiThuat { get; set; }
    }
}
