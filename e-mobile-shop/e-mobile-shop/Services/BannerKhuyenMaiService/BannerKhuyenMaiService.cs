using AutoMapper;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{
    public class BannerKhuyenMaiService : IBannerKhuyenMaiService
    {
        private readonly IBannerKhuyenMaiRepository _bannerKhuyenMaiRepository;
        private readonly IMapper _mapper;
        public BannerKhuyenMaiService(IBannerKhuyenMaiRepository bannerKhuyenMaiRepository, IMapper mapper)
        {
            _bannerKhuyenMaiRepository = bannerKhuyenMaiRepository;
            _mapper = mapper;
        }

        public async  Task<List<BannerKhuyenMaiViewModel>> GetBannerKhuyenMais()
        {
            var a = await _bannerKhuyenMaiRepository.GetAll().ToListAsync();
            var result = _mapper.Map(a, new List<BannerKhuyenMaiViewModel>());
            return result ;
        }
    }
}
