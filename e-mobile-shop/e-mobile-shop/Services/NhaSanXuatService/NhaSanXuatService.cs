using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class NhaSanXuatService : INhaSanXuatService
    {
        private readonly INhaSanXuatRepository _nhaSanXuatRepository;
        private readonly IMapper _mapper;

        public NhaSanXuatService(INhaSanXuatRepository nhaSanXuatRepository, IMapper mapper)
        {
            _nhaSanXuatRepository = nhaSanXuatRepository;
            _mapper = mapper;
        }
    }
}
