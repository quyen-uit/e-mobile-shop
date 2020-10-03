using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class LoaiSpService : ILoaiSpService
    {

        private readonly ILoaiSpRepository _loaiSpRepository;
        private readonly IMapper _mapper;

        public LoaiSpService(ILoaiSpRepository loaiSpRepository, IMapper mapper)
        {
            _loaiSpRepository = loaiSpRepository;
            _mapper = mapper;
        }
    }
}
