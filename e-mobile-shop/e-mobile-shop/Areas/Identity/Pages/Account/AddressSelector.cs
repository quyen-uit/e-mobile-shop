using e_mobile_shop.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Areas.Identity.Pages.Account
{
    public class AddressSelector:Controller
    {
        public IActionResult Ward_Bind(int districtId)
        {
            var listWard = DataAccess.context.Ward.Where(x => x.DistrictId == districtId).ToList();
            return new JsonResult(listWard);
        }

        public IActionResult District_Bind(int provinceId)
        {
            var listDistrict = DataAccess.context.District.Where(x => x.ProvinceId == provinceId).ToList();
            return new JsonResult(listDistrict);
        }
    }
}
