using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_mobile_shop.Core.Repository
{
    public class NhaSanXuatRepository : BaseRepository<NhaSanXuat>, INhaSanXuatRepository
    {
        public NhaSanXuatRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
