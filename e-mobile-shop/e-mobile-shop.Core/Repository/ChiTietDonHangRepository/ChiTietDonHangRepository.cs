using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
<<<<<<< HEAD
using System;
using System.Collections.Generic;
=======
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
>>>>>>> origin/refactor-code-quyen
using System.Text;

namespace e_mobile_shop.Core.Repository
{
    public class ChiTietDonHangRepository : BaseRepository<ChiTietDonHang>, IChiTietDonHangRepository
    {
        public ChiTietDonHangRepository(ApplicationDbContext context):base(context)
        {

        }
<<<<<<< HEAD
=======

        public List<ChiTietDonHang> GetAllByIdDonHang(string id)
        {
            return DbContext.ChiTietDonHang.Where(x => x.MaDh == id).ToList();
        }
>>>>>>> origin/refactor-code-quyen
    }
}
