using System;
using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class DonHangViewModel
    {
        public DonHangViewModel()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHangViewModel>();
        }

        public string MaDh { get; set; }
        public string MaKh { get; set; }
        public double? PhiVanChuyen { get; set; }
        public string PtgiaoDich { get; set; }
        public DateTime? NgayDatMua { get; set; }
        public int? TinhTrangDh { get; set; }
        public double? Tongtien { get; set; }
        public string Ghichu { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public int? Status { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public double? GiamGia { get; set; }

        public virtual ICollection<ChiTietDonHangViewModel> ChiTietDonHang { get; set; }
    }
}
