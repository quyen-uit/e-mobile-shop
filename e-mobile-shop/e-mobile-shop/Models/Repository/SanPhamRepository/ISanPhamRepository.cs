using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models.Repository.SanPhamRepository
{
    public interface ISanPhamRepository
    {
        SanPham GetSanPhamById(string id);
        List<SanPham> GetSanPhamsByIdStatus(string id, string status);
        void Save(SanPham sp);
        void SaveAnhSP(AnhSanPham anh);
        void UpdateAnhSP(AnhSanPham anh);
        void SaveTSKT(ThongSoKiThuat tskt);
        void UpdateTSKT(ThongSoKiThuat tskt);
        void Delete(string id);
        void Update(SanPham sp, string masp);
    }
}
