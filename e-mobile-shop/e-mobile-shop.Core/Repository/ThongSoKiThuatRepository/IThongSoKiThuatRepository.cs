using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace e_mobile_shop.Core.Repository
{
    public interface IThongSoKiThuatRepository : IBaseRepository<ThongSoKiThuat>
    {
<<<<<<< HEAD
       
=======
        void AddTSKT(ThongSoKiThuat tskt);
        void UpdateTSKT(ThongSoKiThuat tskt);
        ThongSoKiThuat GetTSKT(string masp, string mats);
>>>>>>> origin/refactor-code-quyen
    }
}
