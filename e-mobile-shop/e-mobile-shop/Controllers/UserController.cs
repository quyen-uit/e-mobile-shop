using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Models;
using e_mobile_shop.Models.Helpers;
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
    }
}