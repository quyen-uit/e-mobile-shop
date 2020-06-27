using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using e_mobile_shop.Models;
using e_mobile_shop.Models.Helpers;
using e_mobile_shop.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_mobile_shop.Controllers
{
    public class GioHangController : Controller
    {

        private readonly ClientDbContext context;
        private DataAccess dataAccess;

        public GioHangController(ClientDbContext _context)
        {
            context = _context;
            dataAccess = new DataAccess();

        }
        [Route("xem-gio-hang")]
        [HttpPost]
        public IActionResult XemGioHang(IFormCollection fc)
        {
            var giohang = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");
            if (giohang == null) giohang = new List<ChiTietDonHang>();

            double? thanhTien = 0;
            double? giaTriDonHang = 0;


            foreach (var item in giohang)
            {
                thanhTien += item.ThanhTien * item.SoLuong;
                giaTriDonHang += item.ThanhTien * item.SoLuong;
            }

            ViewBag.GiaTriDonHang = giaTriDonHang - thanhTien;

            var listVoucher = HttpContext.Session.GetObjectFromJson<List<Voucher>>("Vouchers");

            if (listVoucher == null)
                listVoucher = new List<Voucher>();
            else
                ViewBag.Vouchers = listVoucher;

            var _voucher = context.Voucher.SingleOrDefault(x => x.VoucherCode == fc["voucher"].ToString());

            if (_voucher != null)
            {
                if (!listVoucher.Exists(x => x.VoucherCode == _voucher.VoucherCode))
                {
                    listVoucher.Add(_voucher);
                }
                else
                {
                    ViewBag.Vouchers = listVoucher;
                    ViewBag.ThanhTien = thanhTien;
                    ViewBag.GiamGia = giaTriDonHang - thanhTien;
                    ViewBag.GiaTriDonHang = giaTriDonHang;
                    ViewBag.GioHang = giohang;
                    ViewBag.Added = 0;
                    return View().WithWarning("", "Voucher đã sử dụng");
                }

                HttpContext.Session.SetObjectAsJson("Vouchers", listVoucher);
                ViewBag.Vouchers = listVoucher;
            }


            foreach (var item in listVoucher)
                if (item.VoucherType.Contains("VCT003"))
                    thanhTien = thanhTien - item.VoucherDiscount;
                else if (item.VoucherType.Contains("VCT002"))
                    if (item.VoucherDiscount != null)
                        thanhTien = thanhTien - thanhTien * ((double) item.VoucherDiscount / 100);


            // string s = String.Format("{0:N0}", thanhTien.ToString());
            ViewBag.ThanhTien = thanhTien;
            ViewBag.GiamGia = giaTriDonHang - thanhTien;
            ViewBag.GiaTriDonHang = giaTriDonHang;
            ViewBag.GioHang = giohang;
            ViewBag.Added = 0;
            return View();
        }

        [Route("xem-gio-hang")]
        [HttpGet]
        public IActionResult XemGioHang()
        {
            var giohang = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang") ?? new List<ChiTietDonHang>();

            double? thanhTien = 0;
            double? giaTriDonHang = 0;

            foreach (var item in giohang)
            {
                thanhTien += item.ThanhTien * item.SoLuong;
                giaTriDonHang += item.ThanhTien * item.SoLuong;
            }

            var listVoucher = HttpContext.Session.GetObjectFromJson<List<Voucher>>("Vouchers");

            if (listVoucher == null)
                listVoucher = new List<Voucher>();
            else
                ViewBag.Vouchers = listVoucher;


            foreach (var item in listVoucher)
                if (item.VoucherType.Contains("VCT003"))
                    thanhTien = thanhTien - item.VoucherDiscount;
                else if (item.VoucherType.Contains("VCT002"))
                    thanhTien = thanhTien - thanhTien * ((double) item.VoucherDiscount / 100);


            // string s = String.Format("{0:N0}", thanhTien.ToString());
            ViewBag.ThanhTien = thanhTien;
            ViewBag.GiamGia = giaTriDonHang - thanhTien;
            ViewBag.GiaTriDonHang = giaTriDonHang;
            ViewBag.GioHang = giohang;
            ViewBag.Added = 0;
            return View();
        }

        public IActionResult RemoveVoucher(string voucherCode)
        {
            var listVoucher = HttpContext.Session.GetObjectFromJson<List<Voucher>>("Vouchers");
            var _lst = new List<Voucher>();
            if (listVoucher != null)
                foreach (var item in listVoucher)
                    if (item.VoucherCode != voucherCode)
                        _lst.Add(item);
            HttpContext.Session.SetObjectAsJson("Vouchers", _lst);
            return RedirectToAction("XemGioHang");
        }

        private int isExist(string id)
        {
            var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");

            for (var i = 0; i < gh.Count; i++)
                if (gh[i].MaSp == id)
                    return i;
            return -1;
        }


        [Route("them-vao-gio")]
        public IActionResult AddToCartSession(IFormCollection fc)
        {
            var ctdh1 = new ChiTietDonHang
            {
                MaSp = fc["SanPham"],
                MaCtdh = "001",
                SoLuong = int.Parse(fc["SoLuong"]),
                ThanhTien = (double?) dataAccess.GetSanPham(fc["SanPham"]).GiaGoc
            };

            if (HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang") == null)
            {
                var gh = new List<ChiTietDonHang>();
                gh.Add(ctdh1);

                dataAccess.soCtdh = gh.Count();
               ViewBag.Added = 1;
                HttpContext.Session.SetObjectAsJson("GioHang", gh);
                return RedirectToAction("SanPham", "SanPham", new {Id = ctdh1.MaSp}).WithSuccess("", "Đã thêm vào giỏ");
                
            }
            else
            {
                var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");

                var index = isExist(ctdh1.MaSp);
                if (index != -1)
                {
                    gh[index].SoLuong += int.Parse(fc["SoLuong"]);
                    gh[index].ThanhTien = (double?) (dataAccess.GetSanPham(ctdh1.MaSp).GiaGoc * int.Parse(fc["SoLuong"]));
                }
                else
                {
                    gh.Add(ctdh1);

                }
                dataAccess.soCtdh = gh.Count();
                ViewBag.Added = 1;
                HttpContext.Session.SetObjectAsJson("GioHang", gh);
                return RedirectToAction("SanPham", "SanPham", new {Id = ctdh1.MaSp}).WithSuccess("", "Đã thêm vào giỏ");
            }
           
        }


        [Route("xoa-khoi-gio-hang/{id}")]
        public IActionResult Remove(int id)
        {
            var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");
            gh.RemoveAt(id);
            HttpContext.Session.SetObjectAsJson("GioHang", gh);
            return RedirectToAction("XemGioHang", "GioHang").WithSuccess("", "Xóa thành công");
        }

        [HttpPost]
        public IActionResult Update(IFormCollection fc, int id)
        {
            var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");

            gh[id].SoLuong = int.Parse(fc["SoLuong-" + id]);
            dataAccess.soCtdh = gh.Count();
            HttpContext.Session.SetObjectAsJson("GioHang", gh);
            return RedirectToAction("XemGioHang", "GioHang").WithSuccess("", "Chỉnh sửa thành công");
        }


        [HttpPost]
        [Route("thanh-toan")]
        public IActionResult CheckOut(IFormCollection fc)
        {
            var dh = new DonHang();

            if (!string.IsNullOrEmpty(fc["Id"].ToString()))
            {
                if (context.AspNetUsers.Find(fc["Id"]) != null)
                {
                    dh.MaKh = fc["Id"];
                    var a = dataAccess.GetUser(dh.MaKh);
                    dh.HoTen = a.HoTen;
                    dh.Dienthoai = a.PhoneNumber;
                    dh.Ghichu = fc["GhiChu"];
                    dh.Email = a.Email;
                    dh.Diachi = a.DiaChi;
                    HttpContext.Session.SetObjectAsJson("MaKh", fc["Id"]);
                }
                else
                {
                    dh.MaKh = "null" + (context.DonHang.Count() + 1);
                    dh.HoTen = fc["HoTen"];
                    dh.Diachi = fc["DiaChi"];
                    dh.Ghichu = fc["GhiChu"];
                    dh.Email = fc["Email"];
                    dh.Dienthoai = fc["DienThoai"];
                }
            }
            else
            {
                dh.MaKh = "null" + (context.DonHang.Count() + 1);
                dh.HoTen = fc["HoTen"];
                dh.Diachi = fc["DiaChi"];
                dh.Ghichu = fc["GhiChu"];
                dh.Email = fc["Email"];
                dh.Dienthoai = fc["DienThoai"];
            }

            dh.NgayDatMua = DateTime.Now;
            dh.PhiVanChuyen = 1000000;
            dh.TinhTrangDh = 0;
            dh.Tongtien = double.Parse(fc["GiaTriDonHang"]);
            dh.GiamGia = double.Parse(fc["GiamGia"]);
           
            dh.Ghichu = fc["GhiChu"];
            dh.TinhTrangDh = 1;
            //dh.Diachi = fc["DiaChi"];
            context.DonHang.Add(dh);
            context.SaveChanges();


            var content = System.IO.File.ReadAllText("GioHang.html");
            content = content.Replace("{{Hoten}}", dh.HoTen);

            var strCtdh = "";
            var index = 0;
            var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");
            foreach (var item in gh)
            {
                item.MaCtdh = (context.ChiTietDonHang.ToList().Count + 1).ToString();
                item.MaDh = dh.MaDh;
                context.SanPham.Find(item.MaSp).SoLuong =
                    context.SanPham.Find(item.MaSp).SoLuong - item.SoLuong;
                context.ChiTietDonHang.Add(item);
                context.SaveChanges();
                strCtdh = strCtdh + "<tr>";
                strCtdh = strCtdh + "<td style='text-align:center'>" + ++index + "</td><td>" +
                          context.SanPham.Find(item.MaSp).TenSp + "</td><td  style='text-align:center'>"
                          + item.SoLuong + "</td><td  style='text-align:center'>"
                          + ((context.SanPham.Find(item.MaSp).GiaGoc * item.SoLuong).HasValue
                              ? (context.SanPham.Find(item.MaSp).GiaGoc * item.SoLuong)?.ToString("N0")
                              : "NULL") + "</td><tr>";
            }

            content = content.Replace("{{thongtindonhang}}", HtmlEncoder.Default.Encode(strCtdh));
            content = content.Replace("{{madh}}", dh.MaDh.ToUpper());
            content = content.Replace("{{diachi}}", dh.Diachi);
            content = content.Replace("{{thanhtien}}",
                dh.Tongtien.Value.ToString("N0"));
            content = content.Replace("{{sdt}}", dh.Dienthoai);
            content = content.Replace("{{giamgia}}", dh.GiamGia.Value.ToString("N0"));
            content = content.Replace("{{thanhtoan}}", (- dh.GiamGia.Value + dh.Tongtien.Value).ToString("N0"));
            var Option = new AuthMessageSenderOptions
            {
                SendGridKey = context.Parameters.Find("2").Value,
                SendGridUser = context.Parameters.Find("1").Value
            };

            var mailSender = new EmailSender(Option);


            mailSender.SendEmailAsync(dh.Email, "Chi tiết đơn hàng ", $"{WebUtility.HtmlDecode(content)}");

            dataAccess.soCtdh = 0;
            HttpContext.Session.DeleteAllSession();

            return RedirectToAction("ChiTietDonHang", "GioHang", new {id = dh.MaDh})
                .WithSuccess("Đặt hàng thành công", "");
        }

        [Authorize]
        [Route("danh-sach-don-hang/{id}")]
        public async Task<IActionResult> DanhSachDonHang(int? pageNumber, string id)
        {
            var donhangs = from d in context.DonHang where d.MaKh == id select d;
            var pageSize = 5;
            return View(await PaginatedList<DonHang>.CreateAsync(donhangs.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [Route("chi-tiet-don-hang/{id}")]
        public IActionResult ChiTietDonHang(string id)
        {
            if (id != null)
                return View(context.ChiTietDonHang.Where(x => x.MaDh == id).ToList());
            return RedirectToAction("Index", "Home");
        }
    }
}