using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class NhaCungCapService : INhaCungCapService
    {

        private readonly INhaCungCapRepository _nhaCungCapRepository;
        private readonly IMapper _mapper;

        public NhaCungCapService(INhaCungCapRepository nhaCungCapRepository, IMapper mapper)
        {
            _nhaCungCapRepository = nhaCungCapRepository;
            _mapper = mapper;
        }
    }
}
