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
    public class SanPhamNoiBatViewComponent:ViewComponent
    {
        private readonly IMobileShopRepository _context;
        public SanPhamNoiBatViewComponent(IMobileShopRepository context)
        {
            _context = context;
            
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            ViewBag.LoaiSp = _context.GetLoaiSp(Id);
            return View(await _context.GetSanPhamNoiBat(Id));
        }
    }
}
