using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class DonHangKh
    {
        public DonHangKh()
        {
            ChiTietDonHang = new HashSet<ChiTietDonHang>();
        }

        public string MaDh { get; set; }
        public string MaKh { get; set; }
        public decimal? PhiVanChuyen { get; set; }
        public string PtgiaoDich { get; set; }
        public DateTime? NgayDatMua { get; set; }
        public int? TinhTrangDh { get; set; }
        public double? Tongtien { get; set; }
        public string Ghichu { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }

        public virtual AspNetUsers MaKhNavigation { get; set; }
        public virtual ICollection<ChiTietDonHang> ChiTietDonHang { get; set; }
    }
}
