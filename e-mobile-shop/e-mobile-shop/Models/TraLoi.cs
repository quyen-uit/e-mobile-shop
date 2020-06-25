using System;
using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class TraLoi
    {
        public string Id { get; set; }
        public string MaBinhLuan { get; set; }
        public string NoiDung { get; set; }
        public DateTime? NgayDang { get; set; }
        public string HoTen { get; set; }
        public string MaKh { get; set; }
        public int? TrangThai { get; set; }
    }
}
