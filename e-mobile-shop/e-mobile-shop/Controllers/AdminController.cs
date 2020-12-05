using BotDetect;
using e_mobile_shop.Core.Models;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.Models.Helpers;
using e_mobile_shop.Services;
using e_mobile_shop.Services.SanPhamService;
using e_mobile_shop.Services.ThongSoKiThuatService;
using e_mobile_shop.ViewModels;
//using e_mobile_shop.Models.Repository;
//using e_mobile_shop.Models.Repository.MobileShopRepository;
//using e_mobile_shop.Models.Repository.SanPhamRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace e_mobile_shop.Controllers
{
    public class AdminController : Controller
    {

        //private readonly IDonHangRepository _repository;
        //private readonly IMobileShopRepository _shopRepo;
        //private readonly ISanPhamRepository _spRepository;

        //public AdminController( IDonHangRepository repository, IMobileShopRepository shopRepo, ISanPhamRepository spRepo)
        //{

        //    _repository = repository;
        //    _shopRepo = shopRepo;
        //    _spRepository = spRepo;
        //}
        // public AdminController(IWebHostEnvironment hostEnvironment, ClientDbContext _context)
        // {
        //     webHostEnvironment = hostEnvironment;
        //     context = _context;
        //     dataAccess = new DataAccess();
        // }
        private readonly ISanPhamService _spService;
        private readonly IDonHangService _dhService;
        private readonly INhaCungCapService _nccService;
        private readonly INhaSanXuatService _nsxService;
        private readonly IThongSoService _tsService;
        private readonly IAnhSanPhamService _aspService;
        private readonly IThongSoKiThuatService _tsktService;
        public AdminController(ISanPhamService sanPhamService, IDonHangService donHangService, INhaCungCapService nhaCungCapService, INhaSanXuatService nhaSanXuatService, IThongSoService thongSoService, IAnhSanPhamService anh, IThongSoKiThuatService thongSoKiThuatService)
        {
            _spService = sanPhamService;
            _dhService = donHangService;
            _nccService = nhaCungCapService;
            _nsxService = nhaSanXuatService;
            _tsService = thongSoService;
            _aspService = anh;
            _tsktService = thongSoKiThuatService;
        }
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(_dhService.GetAllToNotify());
        }
        // [Authorize(Roles = "Quản trị viên")]
        public IActionResult Index()
        {

            // tính tổng sản phẩm đã bán tháng trước và tháng hiện tại
            int sumPre = 0;
            int sum = 0;
            //int preMonth = DateTime.Now.AddMonths(-1).Month;
            //List<DonHang> dhs = _repository.GetDonHangs();
            //foreach (var item in dhs)
            //{

            //    if (item.NgayDatMua.Value.Month == preMonth)
            //    {
            //        foreach (var i in _repository.GetChiTietDonHangsByMaDH(item.MaDh) /*context.ChiTietDonHang.Where(x=>x.MaDh == item.MaDh)*/)
            //        {
            //            sumPre = sumPre + i.SoLuong.Value;
            //        }
            //    }
            //    else if (item.NgayDatMua.Value.Month == DateTime.Now.Month)
            //    {
            //        foreach (var i in _repository.GetChiTietDonHangsByMaDH(item.MaDh))
            //        {
            //            sum = sum + i.SoLuong.Value;
            //        }
            //    }
            //}
            ViewData["sumPreMonth"] = _spService.GetTotalProductSellPreMonth();

            ViewData["sumCurMonth"] = _spService.GetTotalProductSellCurrentMonth();

            //ViewData["sumPreMonth"] = _sanPhamService.GetTotalProductSellPreMonth();

            //ViewData["sumCurMonth"] = _sanPhamService.GetTotalProductSellCurrentMonth();
            return View();
        }
        public IActionResult QuanLyUser(string searchValue)
        {
            ////List<AspNetUsers> list = context.AspNetUsers.ToList();
            //List<AspNetUsers> list = _shopRepo.GetUsers();
            //List<AspNetUsers> rs = new List<AspNetUsers>();
            //if (!String.IsNullOrEmpty(searchValue))
            //{

            //    foreach (var item in list)
            //    {
            //        if (item.UserName.ToLower().Contains(searchValue.ToLower().Trim()))
            //            rs.Add(item);
            //        else if (!string.IsNullOrEmpty(item.HoTen) && item.HoTen.ToLower().Contains(searchValue.ToLower().Trim()))
            //        {
            //            rs.Add(item);
            //        }
            //    }
            //    return View(rs).WithSuccess("Tìm kiếm", searchValue);
            //}
            //return View(list);
            return View();
        }

        public IActionResult QuanLyDonHang(string searchValue, string status)
        {
            //// List<DonHang> list = context.DonHang.ToList();
            //List<DonHang> list = _repository.GetDonHangs();
            //if (!String.IsNullOrEmpty(status))
            //{
            //    list = list.Where(x => x.TinhTrangDh.Value.ToString() == status).ToList();
            //}


            //// List<DonHang> rs = new List<DonHang>();
            //List<DonHang> rs = _repository.GetDonHangs();
            //foreach (var i in list)
            //{
            //    i.Ghichu = i.NgayDatMua.Value.ToString("HH:mm, dd/MM/yyyy");
            //}
            //if (!String.IsNullOrEmpty(searchValue))
            //{

            //    foreach (var item in list)
            //    {
            //        if (item.MaDh.ToLower().Contains(searchValue.ToLower().Trim()))
            //            rs.Add(item);
            //        else if (!string.IsNullOrEmpty(item.HoTen) && item.HoTen.ToLower().Contains(searchValue.ToLower().Trim()))
            //        {
            //            rs.Add(item);
            //        }
            //    }
            //    return View(rs).WithSuccess("Tìm kiếm: ", searchValue);
            //}
            //if (!string.IsNullOrEmpty(status))
            //{
            //    return View(list).WithSuccess("Trạng thái đơn hàng: ", _repository.GetTTDH(status).TenTrangThai /*context.TrangThaiDonHang.Find(Int32.Parse(status)).TenTrangThai*/);
            //}
            //else
            //{
            //    return View(list);
            //}
            return View();
        }
        public IActionResult ChiTietDonHang(string id)
        {

            ////return View(context.DonHang.Where(x=>x.MaDh == id).ToList().FirstOrDefault());
            //return View(_repository.GetDonHangById(id));
            return View();
        }
        public IActionResult ChinhSuaDonHang(string id)
        {
            //return View(_repository.GetDonHangById(id));
            ////return View(context.DonHang.Where(x => x.MaDh == id).ToList().FirstOrDefault());
            return View();
        }

        [HttpPost]
        public IActionResult ChinhSuaDonHang(DonHang model, IFormCollection fc)
        {
            //DonHang dh = _shopRepo.GetDonHang(fc["MaDh"]);
            //dh.TinhTrangDh = model.TinhTrangDh;
            ////context.DonHang.Update(dh);
            ////context.SaveChanges();
            //_repository.Update(dh);
            //return RedirectToAction("QuanLyDonHang", "Admin").WithSuccess("Thành công", "Đơn hàng đã được sửa. ID: " + model.MaDh);
            return View();
        }
        public IActionResult QuanLy(string id, string searchValue, string status)
        {
            ViewData["LoaiSP"] = id;
            //var a = _shopRepo.ReadSanPham(id);
            //var a = _spService.ReadSanPham(id);
            //ViewBag.LoaiSp = _spService.GetLoaiSp(id);
            //List<SanPham> rs = new List<SanPham>();
            //if(!string.IsNullOrEmpty(status) || !string.IsNullOrEmpty(searchValue))
            //{

            //}    
            //if (!string.IsNullOrEmpty(status))
            //{
            //    // a = context.SanPham.Where(x=>x.LoaiSp == id && x.Status == Int32.Parse(status)).ToList();
            //    a = _spRepository.GetSanPhamsByIdStatus(id, status);
            //}
            var rs = _spService.Search(id, searchValue, status);
            foreach (var item in rs)
                item.Nsx = _nsxService.GetTen(item.Nsx);
            if (!String.IsNullOrEmpty(searchValue))
            {
                return View(rs).WithSuccess("Tìm kiếm: ", searchValue);
            }

            if (!string.IsNullOrEmpty(status))
                return View(rs).WithSuccess("Trạng thái sản phẩm: ", status == "1" ? "Kinh doanh" : "Ngừng kinh doanh");
            else
                return View(rs);
        }
        //public IActionResult QuanLy(string maloai, string search)
        //{
        //    return View(context.SanPham.Where(x => x.MaSp.ToLower().Contains(search.ToLower()) || x.TenSp.ToLower().Contains(search.ToLower())));
        //}
        //public IActionResult QuanLyDienThoai()
        //{
        //    return View(_shopRepo.ReadSanPham("LSP0002"));
        //}
        public IActionResult Them(string Id)
        {
            ViewBag.NhaSanXuat = _nsxService.GetNhaSanXuats();
            ViewBag.NhaCungCap = _nccService.GetNhaCungCaps();
            ViewBag.ThongSo = _tsService.GetThongSo(Id);
            ViewData["MaLoai"] = Id;
            //ViewData["TenLoai"] = context.LoaiSp.Find(Id).TenLoai;
            ViewData["TenLoai"] = _spService.GetLoaiSp(Id);
            return View();
        }

        public IActionResult XoaSanPham(string Id)
        {
            //context.SanPham.Find(Id).Status = 0;
            //context.SaveChanges();
            _spService.Delete(Id);
            return RedirectToAction("QuanLy", "Admin", new { id = _spService.GetById(Id).LoaiSp /* context.SanPham.Find(Id).LoaiSp*/ }).WithSuccess("Thành công", "Bạn đã xóa sản phẩm khỏi danh sách.");
        }

        public IActionResult ChinhSua(string Id)
        {
            //SanPham sp = context.SanPham.Find(Id);
            ViewBag.NhaSanXuat = _nsxService.GetNhaSanXuats();
            ViewBag.NhaCungCap = _nccService.GetNhaCungCaps();
            //ViewBag.ThongSo = _spRepository.GetThongSo(id);
            var listTS = _tsService.GetThongSo(Id);
            foreach (var item in listTS)
            {
                item.MaLoai = _tsktService.GetTen(_spService.GetById(Id).MaSp, item.MaThongSo);
            }
            ViewBag.ThongSo = listTS;
            ViewBag.AnhSP = _aspService.GetByIdSp(Id);

            SanPhamViewModel sp = _spService.GetById(Id);
            return View(sp);
        }

        [HttpPost]
        public IActionResult ChinhSua(
            SanPhamViewModel model, IFormFile AnhDaiDien,
            IFormCollection fc,
            IFormFile productImages1,
            IFormFile productImages2,
            IFormFile productImages3)
        {

            model.MaSp = fc["MaSp"];
            SanPhamViewModel a = _spService.GetById(fc["MaSp"]);
            if (AnhDaiDien == null)
            {
                model.AnhDaiDien = a.AnhDaiDien;
            }
            else
            {
                model.AnhDaiDien = FileHelper.UploadedFile(AnhDaiDien, "ProductAvatar");
            }
            if (ModelState.IsValid)
            {
                model.Ishot = Convert.ToBoolean(fc["isHot"].ToString().Split(',')[0]);
                model.Isnew = Convert.ToBoolean(fc["isNew"].ToString().Split(',')[0]);
                model.Status = fc["status"].ToString().Contains("on") ? 1 : 0;
                _spService.Update(model, fc["MaSp"]);
                AnhSanPhamViewModel pic = _aspService.GetByIdSp(model.MaSp);
                if (productImages1 != null)
                    pic.Anh1 = FileHelper.UploadedFile(productImages1, "ProductImages");
                if (productImages2 != null)
                    pic.Anh2 = FileHelper.UploadedFile(productImages2, "ProductImages");
                if (productImages3 != null)
                    pic.Anh3 = FileHelper.UploadedFile(productImages3, "ProductImages");

                _aspService.UpdateAnhSP(pic);

                foreach (var tskt in _tsktService.GetThongSoKiThuat(model.MaSp))
                {
                    tskt.GiaTri = fc[tskt.ThongSo];
                    _tsktService.UpdateTSKT(tskt);

                }
                _spService.SaveChange();
                return RedirectToAction("QuanLy", "Admin", new { id = model.LoaiSp }).WithSuccess("Thành công", "Sản phẩm đã được sửa. ID: " + model.MaSp);
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost]
        public IActionResult Them(SanPhamViewModel model,
            IFormFile AnhDaiDien,
            IFormCollection fc,
            IFormFile productImages1,
            IFormFile productImages2,
            IFormFile productImages3
            )
        {
            if (ModelState.IsValid)
            {
               model.AnhDaiDien = FileHelper.UploadedFile(AnhDaiDien, "ProductAvatar");
                model.SoLuotXemSp = 0;
                model.Ishot = Convert.ToBoolean(fc["isHot"].ToString().Split(',')[0]);
                model.Isnew = Convert.ToBoolean(fc["isNew"].ToString().Split(',')[0]);
             
                _spService.Add(model);
                AnhSanPhamViewModel pic = new AnhSanPhamViewModel()
                {

                    MaSp = model.MaSp,
                  
                    Anh1 = productImages1 != null ? FileHelper.UploadedFile(productImages1, "ProductImages") : null,
                    Anh2 = productImages2 != null ? FileHelper.UploadedFile(productImages2, "ProductImages") : null,
                    Anh3 = productImages3 != null ? FileHelper.UploadedFile(productImages3, "ProductImages") : null,
                };
                _aspService.Add(pic);
                ThongSoKiThuatViewModel tskt;
                List<ThongSoViewModel> listTS = _tsService.GetThongSo(model.LoaiSp).ToList();
                for (int i = 0; i < listTS.Count(); i++)
                {

                    tskt = new ThongSoKiThuatViewModel()
                    {
                        MaSp = model.MaSp,
                        ThongSo = listTS[i].MaThongSo,
                        GiaTri = fc[listTS[i].MaThongSo],

                    };

                    //context.ThongSoKiThuat.AddAsync(tskt);
                    //context.SaveChanges();
                    _tsktService.AddTSKT(tskt);
                    tskt = null;

                }
                _spService.SaveChange();
                return RedirectToAction("QuanLy", "Admin", new { id = model.LoaiSp }).WithSuccess("Thành công", "Sản phẩm đã được thêm. ID:" + model.MaSp);
            }
            else
            {
                ModelState.AddModelError("", "aaa");
                ViewData["MaLoai"] = model.LoaiSp;
                return View(model);
            }
        }


        [HttpGet]
        public IActionResult RegisterWithRoles()
        {
            return View();
        }
        public IActionResult QuanLyKhuyenMai(string searchValue, string status)
        {
            ////List<Voucher> list = context.Voucher.ToList();
            //List<Voucher> list = _shopRepo.GetVouchers();
            //List<Voucher> rs = new List<Voucher>();
            //if (!string.IsNullOrEmpty(status))
            //{
            //    //list = context.Voucher.Where(x => x.Status == Int32.Parse(status)).ToList();
            //    list = _shopRepo.GetVouchersByStatus(status);
            //}
            //if (!String.IsNullOrEmpty(searchValue))
            //{

            //    foreach (var item in list)
            //    {
            //        if (item.VoucherId.ToLower().Contains(searchValue.ToLower().Trim()))
            //            rs.Add(item);
            //        else if (!string.IsNullOrEmpty(item.VoucherCode) && item.VoucherCode.ToLower().Contains(searchValue.ToLower().Trim()))
            //        {
            //            rs.Add(item);
            //        }
            //    }
            //    return View(rs).WithSuccess("Tìm kiếm", searchValue);
            //}
            //if (!string.IsNullOrEmpty(status))
            //    return View(list).WithSuccess("Trạng thái khuyến mãi: ", status == "1" ? "Hoạt động" : "Hết hạn");
            //else
            //    return View(list);
            return View();
        }
        public IActionResult XoaKhuyenMai(string Id)
        {
            //_shopRepo.DeleteVoucher(Id);
            //return RedirectToAction("QuanLyKhuyenMai", "Admin").WithSuccess("Thành công", "Bạn đã xóa khuyến mãi khỏi danh sách.");
            return View();
        }
        public IActionResult ThemKhuyenMai()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThemKhuyenMai(Voucher model)
        {
            //if (ModelState.IsValid)
            //{
            //    _shopRepo.SaveVoucher(model);
            //    return RedirectToAction("QuanLyKhuyenMai", "Admin").WithSuccess("Thành công", "Đã thêm khuyến mãi mới. ID: " + model.VoucherId);
            //}
            //return View(model);
            return View();
        }

        public IActionResult ChiTiet(string id)
        {

            //ViewBag.NhaSanXuat = _shopRepo.GetNSX();
            ViewBag.NhaSanXuat = _nsxService.GetNhaSanXuats();
            //ViewBag.NhaCungCap = _shopRepo.GetNhaCungCap();
            ViewBag.NhaCungCap = _nccService.GetNhaCungCaps();
            //ViewBag.ThongSo = _spRepository.GetThongSo(id);
            var listTS = _tsService.GetThongSo(id);
            foreach (var item in listTS)
            {
                item.MaLoai = _tsktService.GetTen(_spService.GetById(id).MaSp, item.MaThongSo);
            }
            ViewBag.ThongSo = listTS ;
            ViewBag.AnhSP = _aspService.GetByIdSp(id);
            return View(_spService.GetById(id));
            //return View();
        }

    }
}