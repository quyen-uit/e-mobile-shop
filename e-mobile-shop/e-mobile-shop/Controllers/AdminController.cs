using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using e_mobile_shop.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace e_mobile_shop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult QuanLyDienThoai()
        {
            return View(DataAccess.ReadSanPham("15674"));
        }
        public ActionResult ThemDienThoai()
        {
            return View();
        }
        [HttpPost]


        [HttpPost]
        public ActionResult ThemDienThoai(SanPham model, IFormFile AnhDaiDien)
        {
            string message = "";
            if (ModelState.IsValid)
            {
  
                model.MaSp = "spm";
                model.LoaiSp = "15674";
                model.AnhDaiDien = UploadedFile(AnhDaiDien, "ProductAvatar");
                               
                DataAccess.context.SanPham.Add(model);
                DataAccess.context.SaveChanges();
                return RedirectToAction("QuanLyDienThoai","Admin");
            }
            else
            {
                return View(model);
            }
           
        }

        private string UploadedFile(IFormFile file, string folder)
        {
            string uniqueFileName = null;

            if (file != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);
                uniqueFileName = "new" + Guid.NewGuid().ToString() + "." + file.FileName.Split(".")[1].ToLower();
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

    }
}