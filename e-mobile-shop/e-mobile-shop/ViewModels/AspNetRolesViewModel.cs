using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class AspNetRolesViewModel
    {
        public AspNetRolesViewModel()
        {
            AspNetRoleClaims = new HashSet<AspNetRoleClaimsViewModel>();
            AspNetUserRoles = new HashSet<AspNetUserRolesViewModel>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }

        public virtual ICollection<AspNetRoleClaimsViewModel> AspNetRoleClaims { get; set; }
        public virtual ICollection<AspNetUserRolesViewModel> AspNetUserRoles { get; set; }
    }
}
