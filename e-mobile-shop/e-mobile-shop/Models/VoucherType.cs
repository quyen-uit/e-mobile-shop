using System.Collections.Generic;

namespace e_mobile_shop.Models
{
    public partial class VoucherType
    {
        public VoucherType()
        {
            Voucher = new HashSet<Voucher>();
        }

        public string VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }

        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
