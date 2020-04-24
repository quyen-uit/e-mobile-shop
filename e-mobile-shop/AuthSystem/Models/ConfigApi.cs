using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class ConfigApi
    {
        public int Id { get; set; }
        public string MaNcc { get; set; }
        public string LinkRequesrToken { get; set; }
        public string LinkAccessToken { get; set; }
        public string LinkKiemTraLuongTon { get; set; }
        public string LinkXacNhanGiaoHang { get; set; }

        public virtual NhaCungCap MaNccNavigation { get; set; }
    }
}
