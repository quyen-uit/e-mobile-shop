using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class DistrictViewModel
    {
        public DistrictViewModel()
        {
            Ward = new HashSet<WardViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LatiLongTude { get; set; }
        public int ProvinceId { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual ProvinceViewModel Province { get; set; }
        public virtual ICollection<WardViewModel> Ward { get; set; }
    }
}
