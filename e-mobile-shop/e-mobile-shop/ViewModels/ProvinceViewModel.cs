using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class ProvinceViewModel
    {
        public ProvinceViewModel()
        {
            District = new HashSet<DistrictViewModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int? TelephoneCode { get; set; }
        public string ZipCode { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public int? SortOrder { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual CountryViewModel Country { get; set; }
        public virtual ICollection<DistrictViewModel> District { get; set; }
    }
}
