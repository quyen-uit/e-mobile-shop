using e_mobile_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class SanPhamTheoGiaViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string giaTien)
        {
            if (!String.IsNullOrEmpty(giaTien))
            {
                var result = (from t in DataAccess.context.SanPham
                              where t.GiaGoc <= int.Parse(giaTien)
                              select t).ToListAsync();
                return View(await result);
            }
            else return View( await DataAccess.context.SanPham.ToListAsync());

           
        }
    }
}
