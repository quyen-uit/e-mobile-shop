using e_mobile_shop.Models.Repository.MobileShopRepository;
using e_mobile_shop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class BinhLuanViewComponent : ViewComponent
    {
        private readonly IBinhLuanService _binhLuanService;
        public BinhLuanViewComponent( IBinhLuanService binhLuanService)
        {
            _binhLuanService = binhLuanService;
        }
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
            return View(await _binhLuanService.GetBinhLuans(Id));
        }
    }
}
