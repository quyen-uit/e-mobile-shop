using System;
using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class AspNetUsersViewModel
    {
        public AspNetUsersViewModel()
        {
            AspNetUserClaims = new HashSet<AspNetUserClaimsViewModel>();
            AspNetUserLogins = new HashSet<AspNetUserLoginsViewModel>();
            AspNetUserRoles = new HashSet<AspNetUserRolesViewModel>();
            AspNetUserTokens = new HashSet<AspNetUserTokensViewModel>();
            BinhLuan = new HashSet<BinhLuanViewModel>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string Cmnd { get; set; }
        public string HoTen { get; set; }
        public DateTime? NgaySinh { get; set; }
        public int? GioiTinh { get; set; }
        public string DiaChi { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<AspNetUserClaimsViewModel> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLoginsViewModel> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRolesViewModel> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserTokensViewModel> AspNetUserTokens { get; set; }
        public virtual ICollection<BinhLuanViewModel> BinhLuan { get; set; }
    }
}
