using System.Collections.Generic;

namespace e_mobile_shop.ViewModels
{
    public partial class VoucherTypeViewModel
    {
        public VoucherTypeViewModel()
        {
            Voucher = new HashSet<VoucherViewModel>();
        }

        public string VoucherTypeId { get; set; }
        public string VoucherTypeName { get; set; }

        public virtual ICollection<VoucherViewModel> Voucher { get; set; }
    }
}
