using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Models;
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
            
            if(ModelState.IsValid)
            {
                DataAccess.context.Entry(user).CurrentValues.SetValues(model);
                DataAccess.context.SaveChanges();
                return View(model);
            }else
            {
                return View(model);

            }
        }
    }
}