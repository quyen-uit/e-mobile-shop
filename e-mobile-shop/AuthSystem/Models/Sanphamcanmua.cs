using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class Sanphamcanmua
    {
        public Sanphamcanmua()
        {
            DanhsachdangkisanphamNcc = new HashSet<DanhsachdangkisanphamNcc>();
        }

        public int Id { get; set; }
        public string MaSp { get; set; }
        public int? Soluong { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public DateTime? Ngaydang { get; set; }
        public string Mota { get; set; }

        public virtual SanPham MaSpNavigation { get; set; }
        public virtual ICollection<DanhsachdangkisanphamNcc> DanhsachdangkisanphamNcc { get; set; }
    }
}
