using e_mobile_shop.Models;
using e_mobile_shop.Models.Repository.MobileShopRepository;
using e_mobile_shop.Models.Repository.SanPhamRepository;
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
        private readonly ISanPhamRepository _sanPhamRepository;
        public SanPhamNoiBatViewComponent(IMobileShopRepository context, ISanPhamRepository _sp)
        {
            _context = context;
            _sanPhamRepository=_sp;
            
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            ViewBag.LoaiSp = _context.GetLoaiSp(Id);
            ViewBag.SoLuongSp = _sanPhamRepository.CountSanPham(Id);
            return View(await _context.GetSanPhamNoiBat(Id));
        }
    }
}
