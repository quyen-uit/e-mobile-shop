﻿using System;
using System.Collections.Generic;

namespace e_mobile_shop.Core.Models
{
    public partial class Voucher
    {
        public string VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public string VoucherName { get; set; }
        public int? VoucherDiscount { get; set; }
        public string VoucherType { get; set; }
        public int? Status { get; set; }

        public virtual VoucherType VoucherTypeNavigation { get; set; }
    }
}
