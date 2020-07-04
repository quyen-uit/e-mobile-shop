using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace e_mobile_shop.Models
{
    public partial class Voucher
    {
        public string VoucherId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập mã khuyến mãi.")]
        [StringLength(maximumLength: 50, ErrorMessage = "Mã khuyến mãi chỉ được nhập tối đa 50 kí tự")]
        public string VoucherCode { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập tên khuyến mãi.")]
        public string VoucherName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Vui lòng nhập giá trị.")]
        public int? VoucherDiscount { get; set; }
        public string VoucherType { get; set; }
        public int? Status { get; set; }

        public virtual VoucherType VoucherTypeNavigation { get; set; }
    }
}
