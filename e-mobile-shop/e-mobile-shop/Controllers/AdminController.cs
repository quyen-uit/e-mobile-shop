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
using Microsoft.AspNetCore.Authorization;
using e_mobile_shop.Models.Helpers;

namespace e_mobile_shop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        public AdminController(IWebHostEnvironment hostEnvironment)
        {
            webHostEnvironment = hostEnvironment;
        }

        // [Authorize(Roles = "Quản trị viên")]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult QuanLy(string Id)
        {
            return View(DataAccess.ReadSanPham(Id));
        }
        public IActionResult QuanLyDienThoai()
        {
            return View(DataAccess.ReadSanPham("15674"));
        }
        public IActionResult ThemDienThoai()
        {
            return View();
        }

        public IActionResult XoaSanPham(string Id)
        {
            DataAccess.context.SanPham.Find(Id).IsOnline = 0;
            DataAccess.context.SaveChanges();
            return RedirectToAction("QuanLy", "Admin", new { id = DataAccess.context.SanPham.Find(Id).LoaiSp }).WithSuccess("Thành công", "Bạn đã xóa sản phẩm khỏi danh sách.");
        }

        public IActionResult ChinhSua()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChinhSua(IFormFile AnhDaiDien, IFormCollection fc)
        {


            DataAccess.context.SanPham.Find(fc["Id"]).TenSp = fc["TenSp"];

            DataAccess.context.SaveChanges();
            return RedirectToAction("QuanLy", "Admin", new { id = DataAccess.context.SanPham.Find(fc["Id"]).LoaiSp }).WithSuccess("Chỉnh sửa thành công", "");

        }

        [HttpPost]
        public ActionResult ThemDienThoai(SanPham model,
            IFormFile AnhDaiDien,
            IFormCollection fc,
            IFormFile productImages1,
            IFormFile productImages2,
            IFormFile productImages3
            )
        {
            string message = "";

            if (ModelState.IsValid)
            {

                model.MaSp = (DataAccess.context.SanPham.ToList().Count() + 1).ToString();
                model.LoaiSp = fc["LoaiSp"].ToString();
                model.AnhDaiDien = UploadedFile(AnhDaiDien, "ProductAvatar");

                DataAccess.context.SanPham.Add(model);
                DataAccess.context.SaveChanges();

                AnhSanPham pic = new AnhSanPham()
                {
                    Id = (DataAccess.context.AnhSanPham.ToList().Count() + 1).ToString(),
                    MaSp = model.MaSp,
                    Anh1 = UploadedFile(productImages1, "ProductImages"),
                    Anh2 = UploadedFile(productImages2, "ProductImages"),
                    Anh3 = UploadedFile(productImages3, "ProductImages")
                };

                DataAccess.context.AnhSanPham.Add(pic);
                DataAccess.context.SaveChanges();

                for (int i = 1; i < 10; i++)
                {
                    var param = "attribute_" + i.ToString() + "_name";
                    var param2 = "attribute_" + i.ToString() + "_value";
                    if (fc[param].ToString()!="" && fc[param2].ToString() != "")
                    {
                        var thongSoKiThuat = new ThongSoKiThuat()
                        {
                            MaTskt = (DataAccess.context.ThongSoKiThuat.ToList().Count() + 1).ToString(),
                            ThuocTinh = fc[param],
                            GiaTri = fc[param2],
                            MaSp = model.MaSp
                        };
                        DataAccess.context.ThongSoKiThuat.Add(thongSoKiThuat);
                        DataAccess.context.SaveChanges();
                    }
                    else break;

                }
                return RedirectToAction("QuanLyDienThoai", "Admin");
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

        [HttpGet]
        public IActionResult RegisterWithRoles()
        {
            return View();
        }


        public IActionResult Detail(string id)
        {
            return View(DataAccess.context.SanPham.Find(id));
        }

    }
}