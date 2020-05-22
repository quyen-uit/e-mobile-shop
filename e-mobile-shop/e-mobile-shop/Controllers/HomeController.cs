using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using e_mobile_shop.Models;
using e_mobile_shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using e_mobile_shop.Controllers.Components;
using Microsoft.AspNetCore.Http;
using e_mobile_shop.Models.Helpers;
using Microsoft.EntityFrameworkCore;

namespace e_mobile_shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (TempData["GioHang"] == null)
                TempData["GioHang"] = 0;
            return View(DataAccess.ViewSanPham());
        }


        public async Task<IActionResult> testPaging(
            string sortOrder,    
            string currentFilter,    
            string giaTien,    
            int? pageNumber, 
            string loaiSp)
        {
            ViewData["CurrentSort"] = sortOrder;
            if(string.IsNullOrEmpty(sortOrder))
            {
                ViewData["SortByName"] = "by_name";
            }
            if (sortOrder == "high_first")
            {
                ViewData["SortByPrice"] = "high_first";
            }
            else ViewData["SortByPrice"] = "low_first";

            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "high_first" : "";
            ViewData["DateSortParm"] = sortOrder == "high_first" ? "high_first" : "low_first";

            if (giaTien != null)
            {
                pageNumber = 1;
            }
            else
            {
                giaTien = currentFilter;
            }
            ViewData["CurrentFilter"] = giaTien;
            var sanphams = from s in DataAccess.context.SanPham  select s;
            if (!String.IsNullOrEmpty(giaTien))
            {
                string[] paramStrs = new string[2];
                if (giaTien.Contains('&'))
                {
                    paramStrs = giaTien.Split('&');
                    sanphams = sanphams.Where(s => s.GiaGoc <= int.Parse(paramStrs[1]) && s.GiaGoc >= int.Parse(paramStrs[0]));
                }
                else
                {
                    paramStrs[0] = giaTien;
                    paramStrs[1] = "";
                    sanphams = sanphams.Where(s => s.GiaGoc <= int.Parse(paramStrs[0]));
                }
            }

            if(!string.IsNullOrEmpty(loaiSp))
            {
                ViewData["LoaiSp"] = loaiSp;
                sanphams = sanphams.Where(s => s.LoaiSp == loaiSp);
            }
            switch (sortOrder)
            {
                case "high_first":
                    sanphams = sanphams.OrderByDescending(s => s.GiaGoc);
                    break;
                case "low_first":
                    sanphams = sanphams.OrderBy(s => s.GiaGoc);
                    break;
                
                default:
                    sanphams = sanphams.OrderBy(s => s.TenSp);
                    break;
            }
            int pageSize =12;
            return View(await PaginatedList<SanPham>.CreateAsync(sanphams.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpGet]
        public IActionResult TestPage()
        {
            return View();
        }
        [HttpPost]
        public IActionResult TestPage(IFormCollection fc)
        {
            ViewData["giatien"] = fc["GiaTien"].ToString();
            return View();
        }
        public void GiaTien()
        {
            ViewData["giatien"] = "5000000";
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



    }
}
