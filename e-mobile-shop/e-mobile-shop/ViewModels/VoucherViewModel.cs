namespace e_mobile_shop.ViewModels
{
    public partial class VoucherViewModel
    {
        public string VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public string VoucherName { get; set; }
        public int? VoucherDiscount { get; set; }
        public string VoucherType { get; set; }
        public int? Status { get; set; }

        public virtual VoucherTypeViewModel VoucherTypeNavigation { get; set; }
    }
}
