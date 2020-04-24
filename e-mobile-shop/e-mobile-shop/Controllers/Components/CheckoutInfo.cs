using e_mobile_shop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class CheckoutInfoViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            var result = DataAccess.context.AspNetUsers.Where(x => x.Id.Equals(Id)).ToListAsync();

            return View(await result);
        }
    }
}
