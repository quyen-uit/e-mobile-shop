using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class DonHangService : IDonHangService
    {

        private readonly IDonHangRepository _donHangRepository;
        private readonly IMapper _mapper;

        public DonHangService(IDonHangRepository donHangRepository, IMapper mapper)
        {
            _donHangRepository = donHangRepository;
            _mapper = mapper;
        }
    }
}
