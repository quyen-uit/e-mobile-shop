using System;
using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class DonHang
    {
        public DonHang()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public string MaDh { get; set; }
        public string MaKh { get; set; }
        public double? PhiVanChuyen { get; set; }
        public string PtgiaoDich { get; set; }
        public DateTime NgayDatMua { get; set; }
        public int? TinhTrangDh { get; set; }
        public double? Tongtien { get; set; }
        public string Ghichu { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public int? Status { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
