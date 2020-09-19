using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class DistrictService : IDistrictService
    {

        private readonly IDistrictRepository _districRepository;
        private readonly IMapper _mapper;
        public DistrictService(IDistrictRepository districRepository, IMapper mapper)
        {
            _districRepository = districRepository;
            _mapper = mapper;
        }
    }
}
