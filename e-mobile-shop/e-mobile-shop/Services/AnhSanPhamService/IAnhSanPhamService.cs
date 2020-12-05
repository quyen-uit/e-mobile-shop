using e_mobile_shop.ViewModels;

namespace e_mobile_shop.Services
{
    public interface IAnhSanPhamService
    {
        public AnhSanPhamViewModel GetByIdSp(string id);
        public void UpdateAnhSP(AnhSanPhamViewModel asp);
        public void Add(AnhSanPhamViewModel asp);
        public void SaveChange();
    }
}
