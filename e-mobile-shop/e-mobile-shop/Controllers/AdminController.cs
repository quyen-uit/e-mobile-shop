using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using e_mobile_shop.Models;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using e_mobile_shop.Models.Helpers;
using e_mobile_shop.Models.Repository;
using e_mobile_shop.Models.Repository.MobileShopRepository;
using e_mobile_shop.Models.Repository.SanPhamRepository;
namespace e_mobile_shop.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ClientDbContext context;
        private readonly DataAccess dataAccess;
        private readonly IDonHangRepository _repository;
        private readonly IMobileShopRepository _shopRepo;
        private readonly ISanPhamRepository _spRepository;

      
        public AdminController(IWebHostEnvironment hostEnvironment, ClientDbContext _context, IDonHangRepository repository, IMobileShopRepository shopRepo, ISanPhamRepository spRepo)
        {
           webHostEnvironment = hostEnvironment;
           context = _context;
           dataAccess = new DataAccess();
           _repository = repository;
           _shopRepo = shopRepo;
            _spRepository = spRepo;
        }
        // public AdminController(IWebHostEnvironment hostEnvironment, ClientDbContext _context)
        // {
        //     webHostEnvironment = hostEnvironment;
        //     context = _context;
        //     dataAccess = new DataAccess();
        // }
        [HttpGet]
        public IActionResult Test()
        {
            return Ok(_repository.GetAll());
        }
        // [Authorize(Roles = "Quản trị viên")]
        public IActionResult Index()
        {
            int sumPre = 0;
            int sum = 0;
            int preMonth = DateTime.Now.AddMonths(-1).Month;
            List<DonHang> dhs = _repository.GetDonHangs();
            foreach(var item in dhs)
            {
               
              if (item.NgayDatMua.Value.Month == preMonth)
                {
                    foreach(var i in _repository.GetChiTietDonHangsByMaDH(item.MaDh) /*context.ChiTietDonHang.Where(x=>x.MaDh == item.MaDh)*/)
                    {
                        sumPre = sumPre + i.SoLuong.Value;
                    }
                }
              else if (item.NgayDatMua.Value.Month == DateTime.Now.Month)
                {
                    foreach (var i in _repository.GetChiTietDonHangsByMaDH(item.MaDh))
                    {
                        sum = sum + i.SoLuong.Value;
                    }
                }
            }
            ViewData["sumPreMonth"] = sumPre;

            ViewData["sumCurMonth"] = sum;
            return View();
        }
        public IActionResult QuanLyUser(string searchValue)
        {
            //List<AspNetUsers> list = context.AspNetUsers.ToList();
            List<AspNetUsers> list = _shopRepo.GetUsers();
            List<AspNetUsers> rs = new List<AspNetUsers>();
            if (!String.IsNullOrEmpty(searchValue))
            {

                foreach (var item in list)
                {
                    if (item.UserName.ToLower().Contains(searchValue.ToLower().Trim()))
                        rs.Add(item);
                    else if (!string.IsNullOrEmpty(item.HoTen) && item.HoTen.ToLower().Contains(searchValue.ToLower().Trim()))
                    {
                        rs.Add(item);
                    }
                }
                return View(rs).WithSuccess("Tìm kiếm", searchValue);
            }
            return View(list);
        }
       
        public IActionResult QuanLyDonHang(string searchValue, string status)
        {
            // List<DonHang> list = context.DonHang.ToList();
            List<DonHang> list = _repository.GetDonHangs();
            if (!String.IsNullOrEmpty(status))
            {
                list = list.Where(x => x.TinhTrangDh.Value.ToString() == status).ToList();
            }


            // List<DonHang> rs = new List<DonHang>();
            List<DonHang> rs = _repository.GetDonHangs();
            foreach(var i in list)
            {
                i.Ghichu = i.NgayDatMua.Value.ToString("HH:mm, dd/MM/yyyy");
            }
            if (!String.IsNullOrEmpty(searchValue))
            {

                foreach (var item in list)
                {
                    if (item.MaDh.ToLower().Contains(searchValue.ToLower().Trim()))
                        rs.Add(item);
                    else if (!string.IsNullOrEmpty(item.HoTen) && item.HoTen.ToLower().Contains(searchValue.ToLower().Trim()))
                    {
                        rs.Add(item);
                    }
                }
                return View(rs).WithSuccess("Tìm kiếm: ", searchValue);
            }
            if(!string.IsNullOrEmpty(status))
            {
                return View(list).WithSuccess("Trạng thái đơn hàng: ", _repository.GetTTDH(status).TenTrangThai /*context.TrangThaiDonHang.Find(Int32.Parse(status)).TenTrangThai*/);
            }
            else
            {
                return View(list);
            }
        }
        public IActionResult ChiTietDonHang(string id)
        {

            //return View(context.DonHang.Where(x=>x.MaDh == id).ToList().FirstOrDefault());
            return View(_repository.GetDonHangById(id));
        }
        public IActionResult ChinhSuaDonHang(string id)
        {
            return View(_repository.GetDonHangById(id));
            //return View(context.DonHang.Where(x => x.MaDh == id).ToList().FirstOrDefault());
        }

        [HttpPost]
        public IActionResult ChinhSuaDonHang( DonHang model, IFormCollection fc)
        {
            DonHang dh = _shopRepo.GetDonHang(fc["MaDh"]);
            dh.TinhTrangDh = model.TinhTrangDh;
            //context.DonHang.Update(dh);
            //context.SaveChanges();
            _repository.Update(dh);
            return RedirectToAction("QuanLyDonHang", "Admin").WithSuccess("Thành công", "Đơn hàng đã được sửa. ID: " + model.MaDh);
        }
        public IActionResult QuanLy(string id, string searchValue,string status)
        {
            ViewData["LoaiSP"] = id;
            var a =_shopRepo.ReadSanPham(id);
            ViewBag.LoaiSp = _spRepository.GetLoaiSp(id);
            List<SanPham> rs = new List<SanPham>();
            if(!string.IsNullOrEmpty(status))
            {
                // a = context.SanPham.Where(x=>x.LoaiSp == id && x.Status == Int32.Parse(status)).ToList();
                a = _spRepository.GetSanPhamsByIdStatus(id, status);
            }
            if (!String.IsNullOrEmpty(searchValue))
            {

                foreach (var item in a)
                {
                    if (item.TenSp.ToLower().Contains(searchValue.ToLower().Trim()) || item.MaSp.ToLower().Contains(searchValue.ToLower().Trim()))
                        rs.Add(item);
                }
                return View(rs).WithSuccess("Tìm kiếm: ", searchValue);
            }

            if (!string.IsNullOrEmpty(status))
                return View(a).WithSuccess("Trạng thái sản phẩm: ", status=="1"?"Kinh doanh":"Ngừng kinh doanh");
            else 
            return View(a);
        }
        //public IActionResult QuanLy(string maloai, string search)
        //{
        //    return View(context.SanPham.Where(x => x.MaSp.ToLower().Contains(search.ToLower()) || x.TenSp.ToLower().Contains(search.ToLower())));
        //}
        public IActionResult QuanLyDienThoai()
        {
            return View(_shopRepo.ReadSanPham("LSP0002"));
        }
        public IActionResult Them(string Id)
        {
            ViewBag.NhaSanXuat = _shopRepo.GetNSX();
            ViewBag.NhaCungCap =_shopRepo.GetNhaCungCap();
            ViewBag.ThongSo = _spRepository.GetThongSo(Id);
            ViewData["MaLoai"] = Id;

            //ViewData["TenLoai"] = context.LoaiSp.Find(Id).TenLoai;
            ViewData["TenLoai"] = _shopRepo.GetLoaiSp(Id);
            return View();
        }

        public IActionResult XoaSanPham(string Id)
        {
            //context.SanPham.Find(Id).Status = 0;
            //context.SaveChanges();
            _spRepository.Delete(Id);
            return RedirectToAction("QuanLy", "Admin", new { id = _spRepository.GetSanPhamById(Id).LoaiSp /* context.SanPham.Find(Id).LoaiSp*/ }).WithSuccess("Thành công", "Bạn đã xóa sản phẩm khỏi danh sách.");
        }

        public IActionResult ChinhSua(string Id)
        {
            //SanPham sp = context.SanPham.Find(Id);
            SanPham sp = _spRepository.GetSanPhamById(Id);
            return View(sp);
        }

        [HttpPost]
        public IActionResult ChinhSua(
            SanPham model, IFormFile AnhDaiDien,
            IFormCollection fc,
            IFormFile productImages1,
            IFormFile productImages2,
            IFormFile productImages3)
        {
           
            model.MaSp = fc["MaSp"];
            //SanPham a = context.SanPham.Find(fc["MaSp"]);
            SanPham a = _spRepository.GetSanPhamById(fc["MaSp"]);

            if (AnhDaiDien == null)
            {
                model.AnhDaiDien = a.AnhDaiDien;
            }
            else
            {
                model.AnhDaiDien = UploadedFile(AnhDaiDien, "ProductAvatar");
            }
            if (ModelState.IsValid)
            {
                model.Ishot = Convert.ToBoolean(fc["isHot"].ToString().Split(',')[0]);
                model.Isnew = Convert.ToBoolean(fc["isNew"].ToString().Split(',')[0]);
                model.Status = fc["status"].ToString().Contains("on")  ? 1:0;
                //context.Entry(a).CurrentValues.SetValues(model);
                //context.SaveChanges();
                _spRepository.Update(model,fc["MaSp"]);
                //AnhSanPham pic = context.AnhSanPham.Where(x => x.MaSp == model.MaSp).FirstOrDefault();
                AnhSanPham pic = _shopRepo.GetAnhSanPham(model.MaSp);
                if (productImages1 != null)
                    pic.Anh1 = UploadedFile(productImages1, "ProductImages");
                if (productImages2 != null)
                    pic.Anh2 = UploadedFile(productImages2, "ProductImages");
                if (productImages3 != null)
                    pic.Anh3 = UploadedFile(productImages3, "ProductImages");

                //context.AnhSanPham.Update(pic);
                //context.SaveChanges();
                _spRepository.UpdateAnhSP(pic);
                // List<ThongSoKiThuat> listTSKT = ReadThongSoKiThuat(model.MaSp);

                foreach (var tskt in _shopRepo.ReadThongSoKiThuat(model.MaSp))
                {
                    tskt.GiaTri = fc[tskt.ThongSo];
                    //context.Update(tskt);
                    //context.SaveChanges();
                    _spRepository.UpdateTSKT(tskt);

                }

                //ThongSoKiThuat temp;
                //foreach (var ts in ReadThongSo(model.LoaiSp))
                //{
                //    temp = new ThongSoKiThuat()
                //    {
                //        MaSp = model.MaSp,
                //        ThongSo = ts.MaThongSo,
                //        GiaTri = fc[ts.MaThongSo],

                //    };

                //    context.ThongSoKiThuat.Add(temp);
                //    context.SaveChanges();
                //    temp = null;

                //}
                return RedirectToAction("QuanLy", "Admin", new { id = model.LoaiSp }).WithSuccess("Thành công", "Sản phẩm đã được sửa. ID: "+ model.MaSp);
            }
            else
            {
                return View(model);
            }
        }


        [HttpPost]
        public IActionResult Them(SanPham model,
            IFormFile AnhDaiDien,
            IFormCollection fc,
            IFormFile productImages1,
            IFormFile productImages2,
            IFormFile productImages3
            )
        {
           // string message = "";

            if (ModelState.IsValid)
            {

                //  model.MaSp = (context.SanPham.ToList().Count() + 1).ToString();

                model.AnhDaiDien = UploadedFile(AnhDaiDien, "ProductAvatar");
                model.SoLuotXemSp = 0;
                model.Ishot =   Convert.ToBoolean(fc["isHot"].ToString().Split(',')[0]);
                model.Isnew = Convert.ToBoolean(fc["isNew"].ToString().Split(',')[0]);
                //context.SanPham.Add(model);
                //context.SaveChanges();
                _spRepository.Save(model);
                AnhSanPham pic = new AnhSanPham()
                {

                    MaSp = model.MaSp,
                    Anh1 = productImages1 != null ?  UploadedFile(productImages1, "ProductImages"): null,
                    Anh2 = productImages2 != null ? UploadedFile(productImages2, "ProductImages") : null,
                    Anh3 = productImages3 != null ? UploadedFile(productImages3, "ProductImages") : null,
                };

                //context.AnhSanPham.Add(pic);
                //context.SaveChanges();
                _spRepository.SaveAnhSP(pic);
                ThongSoKiThuat tskt;
                List<ThongSo> listTS = _shopRepo.ReadThongSo(model.LoaiSp).ToList();
                for (int i = 0; i < listTS.Count(); i++)
                {

                    tskt = new ThongSoKiThuat()
                    {
                        MaSp = model.MaSp,
                        ThongSo = listTS[i].MaThongSo,
                        GiaTri = fc[listTS[i].MaThongSo],

                    };

                    //context.ThongSoKiThuat.AddAsync(tskt);
                    //context.SaveChanges();
                    _spRepository.SaveTSKT(tskt);
                    tskt = null;

                }



                //for (int i = 1; i < 10; i++)
                //{
                //    var param = "attribute_" + i.ToString() + "_name";
                //    var param2 = "attribute_" + i.ToString() + "_value";
                //    if (fc[param].ToString()!="" && fc[param2].ToString() != "")
                //    {
                //        var thongSoKiThuat = new ThongSoKiThuat()
                //        {
                //            MaTskt = (context.ThongSoKiThuat.ToList().Count() + 1).ToString(),
                //            ThuocTinh = fc[param],
                //            GiaTri = fc[param2],
                //            MaSp = model.MaSp
                //        };
                //        context.ThongSoKiThuat.Add(thongSoKiThuat);
                //        context.SaveChanges();
                //    }
                //    else break;

                //}
                return RedirectToAction("QuanLy", "Admin", new { id = model.LoaiSp }).WithSuccess("Thành công", "Sản phẩm đã được thêm. ID:" + model.MaSp);
            }
            else
            {
                ModelState.AddModelError("", "aaa");
                ViewData["MaLoai"] = model.LoaiSp;
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
        public IActionResult QuanLyKhuyenMai(string searchValue, string status)
        {
            //List<Voucher> list = context.Voucher.ToList();
            List<Voucher> list = _shopRepo.GetVouchers();
            List<Voucher> rs = new List<Voucher>();
            if(!string.IsNullOrEmpty(status))
            {
                //list = context.Voucher.Where(x => x.Status == Int32.Parse(status)).ToList();
                list = _shopRepo.GetVouchersByStatus(status);
            }
            if (!String.IsNullOrEmpty(searchValue))
            {

                foreach (var item in list)
                {
                    if (item.VoucherId.ToLower().Contains(searchValue.ToLower().Trim()))
                        rs.Add(item);
                    else if (!string.IsNullOrEmpty(item.VoucherCode) && item.VoucherCode.ToLower().Contains(searchValue.ToLower().Trim()))
                    {
                        rs.Add(item);
                    }
                }
                return View(rs).WithSuccess("Tìm kiếm", searchValue);
            }
            if (!string.IsNullOrEmpty(status))
                return View(list).WithSuccess("Trạng thái khuyến mãi: " , status=="1"?"Hoạt động":"Hết hạn");
            else 
                return View(list);
        }
        public IActionResult XoaKhuyenMai(string Id)
        {
            _shopRepo.DeleteVoucher(Id);
            return RedirectToAction("QuanLyKhuyenMai", "Admin").WithSuccess("Thành công", "Bạn đã xóa khuyến mãi khỏi danh sách.");
        }
        public IActionResult ThemKhuyenMai( )
        {
            return View();
        }
        [HttpPost]
        public IActionResult ThemKhuyenMai(Voucher model)
        {
            if(ModelState.IsValid)
            {
                _shopRepo.SaveVoucher(model);
                return RedirectToAction("QuanLyKhuyenMai", "Admin").WithSuccess("Thành công", "Đã thêm khuyến mãi mới. ID: "+model.VoucherId);
            }
            return View(model);
        }

        public IActionResult ChiTiet(string id)
        {
            ViewBag.NhaSanXuat = _shopRepo.GetNSX();
            ViewBag.NhaCungCap =_shopRepo.GetNhaCungCap();
            ViewBag.ThongSo = _spRepository.GetThongSo(id);

           
            return View(_spRepository.GetSanPhamById(id));
        }

    }
}
