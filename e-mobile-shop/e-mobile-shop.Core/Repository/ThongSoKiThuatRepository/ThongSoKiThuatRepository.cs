using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Core.Repository
{
    public class ThongSoKiThuatRepository : BaseRepository<ThongSoKiThuat>, IThongSoKiThuatRepository
    {
        public ThongSoKiThuatRepository(ApplicationDbContext context ): base(context)
        {

        }
<<<<<<< HEAD
=======
        public void AddTSKT(ThongSoKiThuat tskt)
        {
            DbContext.ThongSoKiThuat.Add(tskt);
        }

        public ThongSoKiThuat GetTSKT(string masp, string mats)
        {
            return DbContext.ThongSoKiThuat.FirstOrDefault(x => x.MaSp == masp && x.ThongSo == mats);
        }

        public void UpdateTSKT(ThongSoKiThuat tskt)
        {
            DbContext.Update(tskt);

        }
>>>>>>> origin/refactor-code-quyen
    }
}
