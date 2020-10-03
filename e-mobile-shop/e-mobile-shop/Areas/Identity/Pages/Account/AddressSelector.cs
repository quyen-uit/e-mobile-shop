using e_mobile_shop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace e_mobile_shop.Areas.Identity.Pages.Account
{
    public class AddressSelector : Controller
    {
        private readonly ClientDbContext _context;
        public AddressSelector(ClientDbContext context)
        {
            _context = context;
        }
        public IActionResult Ward_Bind(int districtId)
        {
            var listWard = _context.Ward.Where(x => x.DistrictId == districtId).ToList();
            return new JsonResult(listWard);
        }

        public IActionResult District_Bind(int provinceId)
        {
            var listDistrict = _context.District.Where(x => x.ProvinceId == provinceId).ToList();
            return new JsonResult(listDistrict);
        }
    }
}
