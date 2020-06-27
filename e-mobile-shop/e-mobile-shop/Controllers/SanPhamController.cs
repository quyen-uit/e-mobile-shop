using System;
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
        private readonly ClientDbContext context;
        private readonly DataAccess dataAccess;
        public SanPhamController(ClientDbContext _context)
        {
            context = _context;
            dataAccess = new DataAccess();
        }
        public IActionResult Index()
        {
            return View();
        }

        [Route("chi-tiet/{id}")]
        public IActionResult SanPham(string Id)
        {
            return View(dataAccess.GetSanPham(Id));
        }

        [Route("danh-sach/{id}")]
        public async Task<IActionResult> DanhSach(int? pageNumber, string Id)
        {
            var sanphams = from s in context.SanPham select s ;

            if (Id != "LSP0001")
            {
                sanphams= context.SanPham.Where(x => x.LoaiSp == Id);
            }
            else
            {
                 sanphams = context.SanPham.Where(x => x.LoaiSp != "LSP0002" && x.LoaiSp != "LSP0007" && x.LoaiSp != "LSP0008");
            }

            int pageSize = 16;

            return View(await PaginatedList<SanPham>.CreateAsync(sanphams.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
        public IActionResult DanhSach1(string Id)
        {
            return View(dataAccess.ReadSanPham(Id));
        }

    }
}