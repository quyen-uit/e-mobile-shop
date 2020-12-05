using e_mobile_shop.Core.Repository;
using e_mobile_shop.Models.Repository.MobileShopRepository;
using e_mobile_shop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerKhuyenMaiService _bannerKhuyenMaiService;
        public BannerViewComponent( IBannerKhuyenMaiService bannerKhuyenMaiService)
        {
            _bannerKhuyenMaiService = bannerKhuyenMaiService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _bannerKhuyenMaiService.GetBannerKhuyenMais());
        }
    }
}
