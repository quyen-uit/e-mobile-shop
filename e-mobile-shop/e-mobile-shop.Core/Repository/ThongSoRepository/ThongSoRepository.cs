using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Core.Repository
{
    public class ThongSoRepository : BaseRepository<ThongSo>, IThongSoRepository
    {
        public ThongSoRepository(ApplicationDbContext context ): base(context)
        {

        }
        public List<ThongSo> GetThongSo(string Id)
        {
            return DbContext.ThongSo.Where(x => x.MaLoai == Id).ToList();
        }
    }
}
