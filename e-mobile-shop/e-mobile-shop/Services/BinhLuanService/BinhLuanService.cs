using AutoMapper;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{
    public class BinhLuanService : IBinhLuanService
    {

        private readonly IBinhLuanRepository _binhLuanRepository;
        private readonly IMapper _mapper;

        public BinhLuanService(IBinhLuanRepository binhLuanRepository, IMapper mapper)
        {
            _binhLuanRepository = binhLuanRepository;
            _mapper = mapper;
        }

        public async Task<List<BinhLuanViewModel>> GetBinhLuans(string Id)
        {
            var a = await _binhLuanRepository.GetAll().Where(x => x.MaSp == Id && x.Status != 0).ToListAsync();
            var result = _mapper.Map(a, new List<BinhLuanViewModel>());
            return result;
        }
    }
}
