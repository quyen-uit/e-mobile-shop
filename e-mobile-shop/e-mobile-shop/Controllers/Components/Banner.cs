using e_mobile_shop.Models;
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
        private readonly ClientDbContext _context;
        public  BannerViewComponent(ClientDbContext context)
        {
          _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = _context.BannerKhuyenMai.ToListAsync();

            return View(await result);
        }   
    }
}
