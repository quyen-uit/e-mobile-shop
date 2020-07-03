using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Models;
using e_mobile_shop.Models.Helpers;
using e_mobile_shop.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_mobile_shop.Controllers
{
    public class UserController : Controller
    {
        private readonly ClientDbContext context;
        private DataAccess dataAccess;
        public UserController(ClientDbContext _context)
        {
            context = _context;
           
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Edit(string id)
        {
            return View(context.AspNetUsers.Find(id));
        }
        [HttpPost]
        public IActionResult Edit(AspNetUsers model)
        {

            AspNetUsers user = context.AspNetUsers.Find(model.Id);
            
            AspNetUsers newModel = user;
            newModel.HoTen = model.HoTen;
            newModel.Cmnd = model.Cmnd;
            newModel.PhoneNumber = model.PhoneNumber;
            newModel.DiaChi = model.DiaChi;
            newModel.NgaySinh = model.NgaySinh;
            newModel.GioiTinh = model.GioiTinh;



            
            if(ModelState.IsValid)
            {
                context.Entry(user).CurrentValues.SetValues(newModel);
                context.SaveChanges();
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

            context.TraLoi.Add(tl);
            context.SaveChanges();
            return RedirectToAction("SanPham", "SanPham", new { Id = maSp });
        }
        public IActionResult DeleteReply(string id, string maSp)
        {
            context.TraLoi.SingleOrDefault(x => x.Id == id).TrangThai = 0;
            context.SaveChanges();
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

            context.BinhLuan.Add(tl);
            context.SaveChanges();
            return RedirectToAction("SanPham", "SanPham", new { Id = maSp });
        }

        public IActionResult DeleteComment(string id, string maSp)
        {
            context.BinhLuan.SingleOrDefault(x => x.MaBl == id).Status = 0;
            context.SaveChanges();
            return RedirectToAction("SanPham", "SanPham", new { Id = maSp });
        }

        [HttpPost]
        public IActionResult EmailContact( string userId, IFormCollection fc)
        {
            var Option = new AuthMessageSenderOptions
            {
                SendGridKey = context.Parameters.Find("2").Value,
                SendGridUser = context.Parameters.Find("1").Value
            };

            var mailSender = new EmailSender(Option);


            mailSender.SendEmailAsync("thanglequoc1912@gmail.com", fc["TieuDe"].ToString(), fc["NoiDung"]);

            return RedirectToAction("Contact","Home").WithSuccess("","Gửi email thành công, chúng tôi sẽ phản hồi sớm nhất");
        }
    }
}