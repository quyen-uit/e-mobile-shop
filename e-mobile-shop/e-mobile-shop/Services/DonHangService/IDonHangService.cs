using e_mobile_shop.Core.Models;
using System.Collections.Generic;

namespace e_mobile_shop.Services
{
    public interface IDonHangService
    {
        List<DonHang> GetAllToNotify();
    }
}
