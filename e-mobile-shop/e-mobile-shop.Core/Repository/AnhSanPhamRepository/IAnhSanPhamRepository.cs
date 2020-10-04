using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_mobile_shop.Core.Repository
{
    public interface IAnhSanPhamRepository : IBaseRepository<AnhSanPham>
    {
<<<<<<< HEAD
=======
        void SaveAnhSP(AnhSanPham anh);
        void UpdateAnhSP(AnhSanPham anh);
        AnhSanPham GetAnhSanPham(string maSp);
>>>>>>> origin/refactor-code-quyen
    }
}
