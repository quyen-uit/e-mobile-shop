using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Models;
using e_mobile_shop.Models.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_mobile_shop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            return View(e_mobile_shop.Models.DataAccess.context.AspNetUsers.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(AspNetUsers model)
        {

            AspNetUsers user = DataAccess.context.AspNetUsers.Find(model.Id);
            
            AspNetUsers newModel = user;
            newModel.HoTen = model.HoTen;
            newModel.Cmnd = model.Cmnd;
            newModel.PhoneNumber = model.PhoneNumber;
            newModel.DiaChi = model.DiaChi;
            newModel.NgaySinh = model.NgaySinh;
            newModel.GioiTinh = model.GioiTinh;



            
            if(ModelState.IsValid)
            {
                DataAccess.context.Entry(user).CurrentValues.SetValues(newModel);
                DataAccess.context.SaveChanges();
                return View(model).WithSuccess("", "Chỉnh sửa thành công");
            }else
            {
                return View(model);

            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult ReplyComment(string userId, string maBl,string maSp, IFormCollection fc )
        {
            TraLoi tl = new TraLoi()
            {
                MaBinhLuan = maBl,
                NoiDung = fc["ReplyComment"],
                MaKh = userId,
                NgayDang = DateTime.Now
            };

            DataAccess.context.TraLoi.Add(tl);
            DataAccess.context.SaveChanges();
            return RedirectToAction("SanPham", "SanPham", new { Id = maSp });
        }
        public IActionResult DeleteReply(string id, string maSp)
        {
            DataAccess.context.TraLoi.SingleOrDefault(x => x.Id == id).TrangThai = 0;
            DataAccess.context.SaveChanges();
            return RedirectToAction("SanPham", "SanPham", new { Id = maSp });
        }


        [HttpPost]
        [Authorize]
        public IActionResult Comment(string userId,  string maSp, IFormCollection fc)
        {
            BinhLuan tl = new BinhLuan()
            {
                NoiDung = fc["Comment"],
                MaKh = userId,
                NgayDang = DateTime.Now,
                MaSp=maSp
            };

            DataAccess.context.BinhLuan.Add(tl);
            DataAccess.context.SaveChanges();
            return RedirectToAction("SanPham", "SanPham", new { Id = maSp });
        }

        public IActionResult DeleteComment(string id, string maSp)
        {
            DataAccess.context.BinhLuan.SingleOrDefault(x => x.MaBl == id).Status = 0;
            DataAccess.context.SaveChanges();
            return RedirectToAction("SanPham", "SanPham", new { Id = maSp });
        }

    }
}