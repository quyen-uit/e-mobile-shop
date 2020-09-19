using e_mobile_shop.ViewModels;
using System.Linq;

namespace e_mobile_shop.Services.SanPhamService
{
    public interface ISanPhamService
    {
        public IQueryable<SanPhamViewModel> GetPaginatedListSanPham(string Id);
        public SanPhamViewModel GetById(string Id);
    }
}
