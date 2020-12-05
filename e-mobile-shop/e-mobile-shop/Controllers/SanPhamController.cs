using e_mobile_shop.Models;
using e_mobile_shop.Models.Helpers;
using e_mobile_shop.Models.Repository.MobileShopRepository;
using e_mobile_shop.Services.SanPhamService;
using e_mobile_shop.Services.ThongSoKiThuatService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly IMobileShopRepository _shopRepo;
        private readonly ISanPhamService _sanPhamService;
        private readonly IThongSoKiThuatService _thongSoKiThuatService;

        public SanPhamController(IMobileShopRepository shopRepo, ISanPhamService sanPhamService, IThongSoKiThuatService thongSoKiThuatService)
        {
            _shopRepo = shopRepo;
            _sanPhamService = sanPhamService;
            _thongSoKiThuatService = thongSoKiThuatService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("chi-tiet/{id}")]
        public IActionResult SanPham(string Id)
        {
            ViewBag.ListThongSoKiThuat = _thongSoKiThuatService.GetThongSoKiThuat(Id);
            var data = _sanPhamService.GetById(Id);
            return View(data);
        }

        [Route("danh-sach/{id}")]
        public async Task<IActionResult> DanhSach(int? pageNumber, string Id)
        {

            ViewBag.LoaiSp = _shopRepo.GetLoaiSp(_shopRepo.GetPaginatedListSanPham(Id).ToList().ElementAt(0).LoaiSp);
            ViewBag.NhaSanXuat = _shopRepo.GetNSX();
            var sanphams = _shopRepo.GetPaginatedListSanPham(Id);
            int pageSize = 16;

            return View(await PaginatedList<SanPham>.CreateAsync(sanphams.AsNoTracking(), pageNumber ?? 1, pageSize));
        }
    }
}