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
using Microsoft.EntityFrameworkCore;
using System.Text.Encodings.Web;
using e_mobile_shop.Models.Services;
using Microsoft.AspNetCore.Identity.UI.Services;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net.Mail;
using Microsoft.Extensions.Options;

namespace e_mobile_shop.Controllers
{
    public class GioHangController : Controller
    {


        [Route("xem-gio-hang")]
        public IActionResult XemGioHang()
        {
            var giohang = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");
            if (giohang == null)
            {
                giohang = new List<ChiTietDonHang>();
            }
            double? thanhTien = 0 ;
            foreach (var item in giohang)
            {
                thanhTien += (item.ThanhTien*item.SoLuong);
            }
           // string s = String.Format("{0:N0}", thanhTien.ToString());
            ViewBag.ThanhTien = thanhTien;
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



        [Route("them-vao-gio")]
        public IActionResult AddToCartSession(IFormCollection fc)
        {
            ChiTietDonHang ctdh1 = new ChiTietDonHang()
            {
                MaSp = fc["SanPham"],
                MaCtdh = "001",
                SoLuong = Int32.Parse(fc["SoLuong"]),
                ThanhTien = (double?)DataAccess.GetSanPham(fc["SanPham"]).GiaGoc

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
                    gh[index].ThanhTien = (double?)(DataAccess.GetSanPham(ctdh1.MaSp).GiaGoc * gh[index].SoLuong);
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


        [Route("xoa-khoi-gio-hang/{id}")]
        public IActionResult Remove(int id)
        {
            List<ChiTietDonHang> gh = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");
            gh.RemoveAt(id);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "GioHang", gh);
            DataAccess.soCtdh--;
            return RedirectToAction("XemGioHang", "GioHang");
        }

    //    [HttpPost]
    ////    [Route("thanh-toan")]
    //    public IActionResult CheckOut1(IFormCollection fc)
    //    {
    //        DonHang dh = new DonHang();

    //        if (!String.IsNullOrEmpty(fc["Id"].ToString()))
    //        {
    //            dh.MaKh = fc["Id"];
    //            var a = DataAccess.GetUser(dh.MaKh);
    //            dh.HoTen = a.HoTen;
    //            dh.Dienthoai = a.PhoneNumber;
    //            dh.Ghichu = fc["GhiChu"];
    //            dh.Email = a.Email;
    //            SessionHelper.SetObjectAsJson(HttpContext.Session, "MaKh", fc["Id"]);
    //        }
    //        else
    //        {
    //            dh.MaKh = "null" + (DataAccess.context.DonHang.Count() + 1).ToString();
    //            dh.HoTen = fc["HoTen"];
    //            dh.Diachi = fc["DiaChi"];
    //            dh.Ghichu = fc["GhiChu"];
    //            dh.Email = fc["Email"];
    //            dh.Dienthoai = fc["DienThoai"];
    //        }

    //        dh.NgayDatMua = DateTime.Now;
    //        dh.PhiVanChuyen = 1000000;
    //        dh.TinhTrangDh = 0;
    //        dh.Tongtien = Double.Parse(fc["ThanhTien"]);
    //        dh.Ghichu = fc["GhiChu"];
    //        dh.Diachi = fc["DiaChi"];
    //        DataAccess.context.DonHang.Add(dh);
    //        DataAccess.context.SaveChanges();


    //        string content = System.IO.File.ReadAllText("GioHang.html");
    //        content = content.Replace("{{Hoten}}", dh.HoTen);

    //        string strCtdh = "";
    //        int index = 0;
    //        List<ChiTietDonHang> gh = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");
    //        foreach (var item in gh)
    //        {
    //            item.MaCtdh = (DataAccess.context.ChiTietDonHang.ToList().Count + 1).ToString();
    //            item.MaDh = dh.MaDh;
    //            DataAccess.context.SanPham.Find(item.MaSp).SoLuong = DataAccess.context.SanPham.Find(item.MaSp).SoLuong - item.SoLuong;
    //            DataAccess.context.ChiTietDonHang.Add(item);    
    //            DataAccess.context.SaveChanges();
    //            strCtdh = strCtdh + "<tr>";
    //            strCtdh = strCtdh + "<td>" + index + "</td><td>" +
    //                DataAccess.context.SanPham.Find(item.MaSp).TenSp + "</td><td>" + item.SoLuong + "</td><td>" + DataAccess.context.SanPham.Find(item.MaSp).GiaGoc * item.SoLuong + "</td><tr>";
    //        }

    //        content = content.Replace("{{thongtindonhang}}", HtmlEncoder.Default.Encode(strCtdh));

    //         _emailSender.SendEmailAsync(dh.Email, "Chi tiết đơn hàng ", $"{System.Net.WebUtility.HtmlDecode(content)}");


    //        SessionHelper.DeleteAllSession(HttpContext.Session);
    //        DataAccess.soCtdh = 0;

    //        return RedirectToAction("ChiTietDonHang", "GioHang", new { id = dh.MaDh }).WithSuccess("Đặt hàng thành công", "");


    //    }

        [HttpPost]
        [Route("thanh-toan")]
        public IActionResult CheckOut(IFormCollection fc)
        {
            DonHang dh = new DonHang();

            if (!String.IsNullOrEmpty(fc["Id"].ToString()))
            {
                dh.MaKh = fc["Id"];
                var a = DataAccess.GetUser(dh.MaKh);
                dh.HoTen = a.HoTen;
                dh.Dienthoai = a.PhoneNumber;
                dh.Ghichu = fc["GhiChu"];
                dh.Email = a.Email;
                dh.Diachi = a.DiaChi;
                SessionHelper.SetObjectAsJson(HttpContext.Session, "MaKh", fc["Id"]);
            }
            else
            {
                dh.MaKh = "null" + (DataAccess.context.DonHang.Count() + 1).ToString();
                dh.HoTen = fc["HoTen"];
                dh.Diachi = fc["DiaChi"];
                dh.Ghichu = fc["GhiChu"];
                dh.Email = fc["Email"];
                dh.Dienthoai = fc["DienThoai"];
            }

            dh.NgayDatMua = DateTime.Now;
            dh.PhiVanChuyen = 1000000;
            dh.TinhTrangDh = 0;
            dh.Tongtien = Double.Parse(fc["ThanhTien"]);
            dh.Ghichu = fc["GhiChu"];
            //dh.Diachi = fc["DiaChi"];
            DataAccess.context.DonHang.Add(dh);
            DataAccess.context.SaveChanges();


            string content = System.IO.File.ReadAllText("GioHang.html");
            content = content.Replace("{{Hoten}}", dh.HoTen);

            string strCtdh = "";
            int index = 0;
            List<ChiTietDonHang> gh = SessionHelper.GetObjectFromJson<List<ChiTietDonHang>>(HttpContext.Session, "GioHang");
            foreach (var item in gh)
            {
                item.MaCtdh = (DataAccess.context.ChiTietDonHang.ToList().Count + 1).ToString();
                item.MaDh = dh.MaDh;
                DataAccess.context.SanPham.Find(item.MaSp).SoLuong = DataAccess.context.SanPham.Find(item.MaSp).SoLuong - item.SoLuong;
                DataAccess.context.ChiTietDonHang.Add(item);
                DataAccess.context.SaveChanges();
                strCtdh = strCtdh + "<tr>";
                strCtdh = strCtdh + "<td style='text-align:center'>" + ++index + "</td><td>" +
                    DataAccess.context.SanPham.Find(item.MaSp).TenSp + "</td><td  style='text-align:center'>"
                    + item.SoLuong + "</td><td  style='text-align:center'>"
                    + ((DataAccess.context.SanPham.Find(item.MaSp).GiaGoc * item.SoLuong).HasValue? 
                    (DataAccess.context.SanPham.Find(item.MaSp).GiaGoc * item.SoLuong).Value.ToString("N0"):"NULL") + "</td><tr>";
            }

            content = content.Replace("{{thongtindonhang}}", HtmlEncoder.Default.Encode(strCtdh));
            content = content.Replace("{{madh}}", dh.MaDh.ToUpper());
            content = content.Replace("{{diachi}}", dh.Diachi);
            content = content.Replace("{{thanhtien}}", dh.Tongtien.HasValue? dh.Tongtien.Value.ToString("N0"): "NULL");
            content = content.Replace("{{sdt}}", dh.Dienthoai);

            AuthMessageSenderOptions Option = new AuthMessageSenderOptions()
            {
                SendGridKey = DataAccess.context.Parameters.Find("2").Value,
                SendGridUser = DataAccess.context.Parameters.Find("1").Value

            };

            var mailSender = new EmailSender(Option);


           mailSender.SendEmailAsync(dh.Email, "Chi tiết đơn hàng ", $"{System.Net.WebUtility.HtmlDecode(content)}");


            SessionHelper.DeleteAllSession(HttpContext.Session);
            DataAccess.soCtdh = 0;

            return RedirectToAction("ChiTietDonHang", "GioHang", new { id = dh.MaDh }).WithSuccess("Đặt hàng thành công", "");


        }

        [Authorize]
        [Route("danh-sach-don-hang/{id}")]
        public async Task<IActionResult> DanhSachDonHang(int? pageNumber, string id)
        {
            var donhangs = from d in DataAccess.context.DonHang where d.MaKh == id select d;
            int pageSize = 5;
            return View(await PaginatedList<DonHang>.CreateAsync(donhangs.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [Route("chi-tiet-don-hang/{id}")]
        public IActionResult ChiTietDonHang(string id)
        {
            if (id != null)
                return View(DataAccess.context.ChiTietDonHang.Where(x => x.MaDh == id).ToList());
            else return RedirectToAction("Index", "Home");
        }
    }
}