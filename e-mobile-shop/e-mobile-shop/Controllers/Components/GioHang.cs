using e_mobile_shop.Models;
using e_mobile_shop.Models.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class GioHangViewComponent : ViewComponent
    {
        private readonly ClientDbContext _context;
        public GioHangViewComponent(ClientDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var giohang = HttpContext.Session.GetObjectFromJson<Task<List<ChiTietDonHang>>>("GioHang");

            if(giohang==null)
            {
                var a  = new List<ChiTietDonHang>().AsQueryable<ChiTietDonHang>();
                giohang = a.ToListAsync();
            }

            return View(await giohang);
        }
    }
}
