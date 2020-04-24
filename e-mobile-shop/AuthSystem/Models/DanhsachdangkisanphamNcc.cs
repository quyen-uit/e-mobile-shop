using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class DanhsachdangkisanphamNcc
    {
        public int Id { get; set; }
        public int? MaSpcanMua { get; set; }
        public string MaNcc { get; set; }
        public string Ghichu { get; set; }
        public DateTime? NgayDk { get; set; }
        public int? Trangthai { get; set; }
        public int? TienmoiSp { get; set; }

        public virtual NhaCungCap MaNccNavigation { get; set; }
        public virtual Sanphamcanmua MaSpcanMuaNavigation { get; set; }
    }
}
