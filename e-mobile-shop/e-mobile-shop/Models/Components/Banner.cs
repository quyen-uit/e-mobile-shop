using e_mobile_shop.Models;
using e_mobile_shop.Models.Repository.MobileShopRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class BannerViewComponent:ViewComponent
    {
        private readonly IMobileShopRepository _context;
        public  BannerViewComponent(IMobileShopRepository context)
        {
          _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
        
            return View(await _context.GetBannerKhuyenMais());
        }   
    }
}
