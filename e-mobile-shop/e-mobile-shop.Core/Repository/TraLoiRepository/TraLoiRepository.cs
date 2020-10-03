using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Core.Repository
{
    public class TraLoiRepository : BaseRepository<TraLoi>, ITraLoiRepository
    {
        public TraLoiRepository(ApplicationDbContext context ): base(context)
        {

        }
    }
}
