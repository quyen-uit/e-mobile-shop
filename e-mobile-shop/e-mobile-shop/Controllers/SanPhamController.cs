﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Models;
using e_mobile_shop.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> DanhSach(int? pageNumber, string Id)
        {
            var sanphams = (from s in DataAccess.context.SanPham where s.LoaiSp == Id select s);

            int pageSize = 16;

            return View(await PaginatedList<SanPham>.CreateAsync(sanphams.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public IActionResult DanhSach1(string Id)
        {
            return View(DataAccess.ReadSanPham(Id));
        }

    }
}