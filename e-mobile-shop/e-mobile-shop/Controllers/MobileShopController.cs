using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace e_mobile_shop.Controllers
{
    public class MobileShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TrangChu()
        {
            return View();
        }

        public IActionResult TrangChu2(){
            return View();
        }
        
        
    }
}