using e_mobile_shop.Models.Repository.MobileShopRepository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace e_mobile_shop.Controllers.Components
{
    public class SanPhamTheoGiaViewComponent : ViewComponent
    {
        private readonly IMobileShopRepository context;
        public SanPhamTheoGiaViewComponent(IMobileShopRepository _context)
        {
            context = _context;
        }
        public async Task<IViewComponentResult> InvokeAsync(string giaTien)
        {
            return View(await context.GetSanPhamTheoGia(giaTien));
        }
    }
}
