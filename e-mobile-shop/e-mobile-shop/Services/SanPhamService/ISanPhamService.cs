using e_mobile_shop.ViewModels;
<<<<<<< HEAD
=======
using System.Collections.Generic;
>>>>>>> origin/refactor-code-quyen
using System.Linq;

namespace e_mobile_shop.Services.SanPhamService
{
    public interface ISanPhamService
    {
        public IQueryable<SanPhamViewModel> GetPaginatedListSanPham(string Id);
        public SanPhamViewModel GetById(string Id);
<<<<<<< HEAD
=======
        public int GetTotalProductSellPreMonth();
        public int GetTotalProductSellCurrentMonth();
        public List<SanPhamViewModel> ReadSanPham(string id);
        string GetLoaiSp(string id);
        public List<SanPhamViewModel> Search(string id, string searchValue, string status);
        public void Delete(string id);
        public void Update(SanPhamViewModel sp, string id);
        public void Add(SanPhamViewModel sp);
        public void SaveChange();
>>>>>>> origin/refactor-code-quyen
    }
}
