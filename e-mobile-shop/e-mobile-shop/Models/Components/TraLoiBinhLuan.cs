﻿using e_mobile_shop.Models.Repository.MobileShopRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class TraLoiBinhLuanViewComponent : ViewComponent
    {
        private readonly IMobileShopRepository context;
        public TraLoiBinhLuanViewComponent(IMobileShopRepository _context)
        {
            context = _context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            return View(await context.GetTraLoiBinhLuan(Id));
        }
    }
}
