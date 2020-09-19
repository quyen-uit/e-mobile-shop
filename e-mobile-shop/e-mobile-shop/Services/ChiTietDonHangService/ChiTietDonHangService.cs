using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class ChiTietDonHangService : IChiTietDonHangService
    {

        private readonly IChiTietDonHangRepository _chiTietDonHangRepository;
        private readonly IMapper _mapper;
        public ChiTietDonHangService(IChiTietDonHangRepository chiTietDonHangRepository, IMapper mapper)
        {
            _chiTietDonHangRepository = chiTietDonHangRepository;
            _mapper = mapper;
        }
    }
}
