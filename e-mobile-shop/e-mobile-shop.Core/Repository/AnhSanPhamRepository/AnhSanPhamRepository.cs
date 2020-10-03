using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e_mobile_shop.Core.Repository
{
    public class AnhSanPhamRepository : BaseRepository<AnhSanPham>, IAnhSanPhamRepository
    {
        public AnhSanPhamRepository(ApplicationDbContext context):base(context)
        {

        }
        public void SaveAnhSP(AnhSanPham anh)
        {
            DbContext.AnhSanPham.Add(anh);
            DbContext.SaveChanges();
        }
        public void UpdateAnhSP(AnhSanPham anh)
        {
            DbContext.AnhSanPham.Update(anh);
            DbContext.SaveChanges();
        }
        public AnhSanPham GetAnhSanPham(string maSp)
        {
            return DbContext.AnhSanPham.Where(x => x.MaSp == maSp).FirstOrDefault();
        }
    }
}
