using e_mobile_shop.Models;
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
        private readonly ClientDbContext _context;
        public SanPhamNoiBatViewComponent(ClientDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            var result = (from t in _context.SanPham
                          where t.LoaiSp == Id
                          orderby t.GiaGoc descending
                          select t).Take(4).ToListAsync();
        
            return View(await result);
        }
    }
}
