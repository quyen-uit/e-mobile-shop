using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class TrangThaiDonHangService : ITrangThaiDonHangService
    {
        private readonly ITrangThaiDonHangRepository _trangThaiDonhangRepository;
        private readonly IMapper _mapper;

        public TrangThaiDonHangService(ITrangThaiDonHangRepository trangThaiDonhangRepository, IMapper mapper)
        {
            _trangThaiDonhangRepository = trangThaiDonhangRepository;
            _mapper = mapper;
        }
    }
}
