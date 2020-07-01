using System;
using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class Ward
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string LatiLongTude { get; set; }
        public int DistrictId { get; set; }
        public int SortOrder { get; set; }
        public bool? IsPublished { get; set; }
        public bool? IsDeleted { get; set; }

        public virtual District District { get; set; }
    }
}
