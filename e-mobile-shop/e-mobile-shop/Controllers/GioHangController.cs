using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using e_mobile_shop.Models;
using Microsoft.AspNetCore.Mvc;
using e_mobile_shop.Models.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using e_mobile_shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace e_mobile_shop.Controllers
{
    public class GioHangController : Controller
    {

        UserManager<AppUser> UserManager;
        SignInManager<AppUser> SignInManager;
        public IActionResult XemGioHang()
        {
            var giohang = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");
            if (giohang == null)
            {
                giohang = new List<ChiTietDonHang>();
            }
            decimal? thanhTien = 0;
            foreach (var item in giohang)
            {
                thanhTien += item.ThanhTien;
            }
            string s = String.Format("{0:0,0 VNĐ}", thanhTien.ToString());
            ViewBag.ThanhTien = s;
            ViewBag.GioHang = giohang;
            ViewBag.Added = 0;
            
            return View();
        }

        private int isExist(string id)
        {
            List<ChiTietDonHang> gh = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");

            for (int i = 0; i < gh.Count; i++)
            {
                if (gh[i].MaSp == id)
                    return i;
            }
            return -1;
        }


        public IActionResult AddToCartSession(IFormCollection fc)
        {
            ChiTietDonHang ctdh1 = new ChiTietDonHang()
            {
                MaSp = fc["SanPham"],
                MaCtdh = "001",
                SoLuong = Int32.Parse(fc["SoLuong"]),
                ThanhTien = DataAccess.GetSanPham(fc["SanPham"]).GiaGoc

            };

            if (SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang") == null)
            {
                List<ChiTietDonHang> gh = new List<ChiTietDonHang>();
                gh.Add(ctdh1);

                ViewBag.Added = 1;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "GioHang", gh);
                DataAccess.soCtdh = gh.Count();
                return RedirectToAction("SanPham", "SanPham", new { Id = ctdh1.MaSp });
            }
            else
            {
                List<ChiTietDonHang> gh = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");

                int index = isExist(ctdh1.MaSp);
                if (index != -1)
                {
                    gh[index].SoLuong += int.Parse(fc["SoLuong"]);
                    gh[index].ThanhTien = DataAccess.GetSanPham(ctdh1.MaSp).GiaGoc * gh[index].SoLuong;
                }
                else
                {
                    gh.Add(ctdh1);
                    DataAccess.soCtdh = gh.Count();
                }
                ViewBag.Added = 1;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "GioHang", gh);
                return RedirectToAction("SanPham", "SanPham", new { Id = ctdh1.MaSp });
            }
        }

        public IActionResult Remove(int id)
        {
            List<ChiTietDonHang> gh = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");
            gh.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "GioHang", gh);
            DataAccess.soCtdh--;
            return RedirectToAction("XemGioHang", "GioHang");
        }

        [HttpPost]
        public IActionResult CheckOut(IFormCollection fc)
        {
            DonHang dh = new DonHang();
            dh.MaDh = (DataAccess.context.DonHang.ToList().Count + 1).ToString();
            dh.MaKh = fc["Id"];
            SessionHelper.SetObjectAsJson(HttpContext.Session, "MaKh", fc["Id"]);
            dh.NgayDatMua = DateTime.Now;
            dh.PhiVanChuyen = 1000000;
            dh.TinhTrangDh = 0;
            dh.Tongtien = Double.Parse(fc["ThanhTien"]);
            dh.Ghichu = fc["GhiChu"];
            dh.Diachi = fc["DiaChi"];
            DataAccess.context.DonHang.Add(dh);
            DataAccess.context.SaveChanges();
            List<ChiTietDonHang> gh = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");
            foreach (var item in gh)
            {
               item.MaCtdh = (DataAccess.context.ChiTietDonHang.ToList().Count + 1).ToString();
               item.MaDh = dh.MaDh;
                DataAccess.context.ChiTietDonHang.Add(item);
                DataAccess.context.SaveChanges();
            }
            SessionHelper.DeleteAllSession(HttpContext.Session);
            DataAccess.soCtdh = 0;
            return RedirectToAction("ChiTietDonHang", "GioHang", new { id = dh.MaDh }).WithSuccess("Đặt hàng thành công","");
          
        }
        [Authorize]
        public IActionResult DanhSachDonHang(string id)
        {

<<<<<<< Updated upstream
            return View(DataAccess.context.DonHang.Where(x => x.MaKh == id).ToList());
=======
            return View(DataAccess.context.DonHang.ToList());
        }

        [Authorize]
        public async Task<IActionResult> DanhSachDonHang(int? pageNumber ,string id)
        {
            var donhangs = from d in DataAccess.context.DonHang where d.MaKh == id select d;
            int pageSize =5 ;
            return View(await PaginatedList<DonHang>.CreateAsync(donhangs.AsNoTracking(), pageNumber??1, pageSize));
>>>>>>> Stashed changes
        }

        [Authorize]
        public IActionResult ChiTietDonHang(string id)
        {
            if (id != null)
                return View(DataAccess.context.ChiTietDonHang.Where(x => x.MaDh == id).ToList());
            else return RedirectToAction("Index", "Home");
        }
    }
}