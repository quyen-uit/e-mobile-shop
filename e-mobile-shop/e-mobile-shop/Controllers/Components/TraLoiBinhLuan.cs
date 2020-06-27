using e_mobile_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class TraLoiBinhLuanViewComponent : ViewComponent
    {
        private readonly ClientDbContext context;
        public TraLoiBinhLuanViewComponent(ClientDbContext _context)
        {
            context = _context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            var result = context.TraLoi.Where(x => x.MaBinhLuan == Id && x.TrangThai!=0 ).ToListAsync();
            return View(await result);
        }
    }
}
