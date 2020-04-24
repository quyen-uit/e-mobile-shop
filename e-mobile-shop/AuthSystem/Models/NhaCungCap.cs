using System;
using System.Collections.Generic;

namespace AuthSystem.Models
{
    public partial class NhaCungCap
    {
        public NhaCungCap()
        {
            ConfigApi = new HashSet<ConfigApi>();
            DanhsachdangkisanphamNcc = new HashSet<DanhsachdangkisanphamNcc>();
            HopDongNcc = new HashSet<HopDongNcc>();
            Oauth = new HashSet<Oauth>();
        }

        public string MaNcc { get; set; }
        public string TenNcc { get; set; }
        public string DiaChi { get; set; }
        public string SdtNcc { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string NetUser { get; set; }

        public virtual AspNetUsers NetUserNavigation { get; set; }
        public virtual ICollection<ConfigApi> ConfigApi { get; set; }
        public virtual ICollection<DanhsachdangkisanphamNcc> DanhsachdangkisanphamNcc { get; set; }
        public virtual ICollection<HopDongNcc> HopDongNcc { get; set; }
        public virtual ICollection<Oauth> Oauth { get; set; }
    }
}
