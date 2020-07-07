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
        public IActionResult XemGioHang(IFormCollection fc)
        {
            var giohang = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");
            if (giohang == null) giohang = new List<ChiTietDonHang>();
          
            double? thanhTien = 0;
            double? giaTriDonHang = 0;


            foreach (var item in giohang)
            {
                item.ThanhTien = (double?)(context.SanPham.Find(item.MaSp).GiaGoc * item.SoLuong);
                thanhTien = thanhTien + item.ThanhTien;
                giaTriDonHang = giaTriDonHang + item.ThanhTien;
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
            thanhTien = 0;
            giaTriDonHang = 0;
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
        public IActionResult AddToCartSession(IFormCollection fc, string maSp)
        {
            var _giohang = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");
            if ((_giohang != null) && (_giohang.Count != 0))
            {
                var _sp = _giohang.SingleOrDefault(x => x.MaSp == maSp);
                var _soLuong = 0;
                if (_sp != null)
                {
                    _soLuong = (int)_sp.SoLuong;
                }

                if ((int.Parse(fc["SoLuong"]) + _soLuong) <= context.SanPham.Find(maSp).SoLuong)
                {
                    var ctdh1 = new ChiTietDonHang
                    {
                        MaSp = maSp,
                        MaCtdh = "001",
                        SoLuong = int.Parse(fc["SoLuong"]),

                    };

                    if (HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang") == null)
                    {
                        var gh = new List<ChiTietDonHang>();
                        gh.Add(ctdh1);

                        ViewBag.Added = 1;

                        HttpContext.Session.SetObjectAsJson("GioHang", gh);

                        HttpContext.Session.SetString("GioHangCount", gh.Count.ToString());


                        return RedirectToAction("SanPham", "SanPham", new { Id = ctdh1.MaSp }).WithSuccess("", "Đã thêm vào giỏ");

                    }
                    else
                    {
                        var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");

                        var index = isExist(ctdh1.MaSp);
                        if (index != -1)
                        {
                            gh[index].SoLuong += int.Parse(fc["SoLuong"]);

                        }
                        else
                        {
                            gh.Add(ctdh1);

                        }
                        ViewBag.Added = 1;
                        HttpContext.Session.SetObjectAsJson("GioHang", gh);
                        HttpContext.Session.SetString("GioHangCount", gh.Count.ToString());
                        return RedirectToAction("SanPham", "SanPham", new { Id = ctdh1.MaSp }).WithSuccess("", "Đã thêm vào giỏ");
                    }
                }
                else return RedirectToAction("SanPham", "SanPham", new { Id = maSp }).WithInfo("Đã hết hàng", "Sản phẩm đã hết hàng");

            }
            else
            {
                if (int.Parse(fc["SoLuong"]) <= context.SanPham.Find(maSp).SoLuong)
                {
                    var ctdh1 = new ChiTietDonHang
                    {
                        MaSp = maSp,
                        MaCtdh = "001",
                        SoLuong = int.Parse(fc["SoLuong"]),

                    };

                    if (HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang") == null)
                    {
                        var gh = new List<ChiTietDonHang>();
                        gh.Add(ctdh1);

                        ViewBag.Added = 1;

                        HttpContext.Session.SetObjectAsJson("GioHang", gh);

                        HttpContext.Session.SetString("GioHangCount", gh.Count.ToString());


                        return RedirectToAction("SanPham", "SanPham", new { Id = ctdh1.MaSp }).WithSuccess("", "Đã thêm vào giỏ");

                    }
                    else
                    {
                        var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");

                        var index = isExist(ctdh1.MaSp);
                        if (index != -1)
                        {
                            gh[index].SoLuong += int.Parse(fc["SoLuong"]);

                        }
                        else
                        {
                            gh.Add(ctdh1);

                        }
                        ViewBag.Added = 1;
                        HttpContext.Session.SetObjectAsJson("GioHang", gh);
                        HttpContext.Session.SetString("GioHangCount", gh.Count.ToString());
                        return RedirectToAction("SanPham", "SanPham", new { Id = ctdh1.MaSp }).WithSuccess("", "Đã thêm vào giỏ");
                    }
                }
                else return RedirectToAction("SanPham", "SanPham", new { Id = maSp }).WithInfo("Đã hết hàng", "Sản phẩm đã hết hàng");
            }

        }


        [Route("xoa-khoi-gio-hang/{id}")]
        public IActionResult Remove(int id)
        {
            var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");
            gh.RemoveAt(id);
            HttpContext.Session.SetString("GioHangCount", gh.Count.ToString());
            HttpContext.Session.SetObjectAsJson("GioHang", gh);
            return RedirectToAction("XemGioHang", "GioHang").WithSuccess("", "Xóa thành công");
        }

        [HttpPost]
        public IActionResult Update(IFormCollection fc, int id)
        {
            var gh = HttpContext.Session.GetObjectFromJson<List<ChiTietDonHang>>("GioHang");

            gh[id].SoLuong = int.Parse(fc["SoLuong-" + id]);
            if(gh[id].SoLuong==0)
            {
                return RedirectToAction("Remove", "GioHang", new { id = id });
            }


            
            HttpContext.Session.SetObjectAsJson("GioHang", gh);
            HttpContext.Session.SetString("GioHangCount", gh.Count.ToString());
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

            HttpContext.Session.DeleteAllSession();

            return RedirectToAction("ChiTietDonHang", "GioHang", new {id = dh.MaDh})
                .WithSuccess("Đặt hàng thành công", "");
        }

        [Authorize]
        [Route("danh-sach-don-hang/{id}")]
        public async Task<IActionResult> DanhSachDonHang(int? pageNumber, string id, string type )
        {
            var donhangs = from d in context.DonHang where d.MaKh == id select d;
            if(!String.IsNullOrEmpty(type))
            {
                donhangs = donhangs.Where(x => x.TinhTrangDh == int.Parse(type));
                ViewData["Type"] = context.TrangThaiDonHang.Find(int.Parse(type)).TenTrangThai;
            }
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

 
        public IActionResult HuyDonHang(string id )
        {
            DonHang dh = dataAccess.GetDonHang(id);
            if(dh.TinhTrangDh!=3)
            {
                dh.TinhTrangDh = 0;
                context.DonHang.Update(dh);

                context.SaveChanges();
                return RedirectToAction("ChiTietDonHang", "GioHang", new { id = id }).WithSuccess("Thành công", "Đơn hàng đã được hủy.");

            }
            else
            {
                return RedirectToAction("ChiTietDonHang", "GioHang", new { id = id }).WithSuccess("Thất bại", "Đơn hàng không thể hủy.");

            }

        }
    }
}