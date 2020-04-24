using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_mobile_shop.Controllers
{
    public class SanPhamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SanPham(string Id)
        {
            return View(DataAccess.GetSanPham(Id));
        }

        public IActionResult DanhSach(string Id)
        {
            return View(DataAccess.ReadSanPham(Id));
        }


    }
}