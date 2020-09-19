using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class ThongSoService : IThongSoService
    {

        private readonly IThongSoRepository _thongSoRepository;
        private readonly IMapper _mapper;

        public ThongSoService(IThongSoRepository thongSoRepository, IMapper mapper)
        {
            _thongSoRepository = thongSoRepository;
            _mapper = mapper;
        }
    }
}
