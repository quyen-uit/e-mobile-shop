using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class HopDongNcc
    {
        public string MaHd { get; set; }
        public string MaNcc { get; set; }
        public DateTime? NgayKy { get; set; }
        public int? ThoiHanHd { get; set; }
        public DateTime? TggiaoHang { get; set; }
        public string MaSp { get; set; }
        public int? SltoiThieu { get; set; }
        public int? SlcungCap { get; set; }
        public DateTime? Dateaccept { get; set; }
        public bool? IsBuy { get; set; }
        public int? SoNgayGiao { get; set; }
        public decimal? DonGia { get; set; }
        public bool? TinhTrang { get; set; }
        public bool? TtthanhToan { get; set; }

        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual SanPham MaSpNavigation { get; set; }
    }
}
