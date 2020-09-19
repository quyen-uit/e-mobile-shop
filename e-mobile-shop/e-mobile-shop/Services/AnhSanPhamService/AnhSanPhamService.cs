

using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class AnhSanPhamService : IAnhSanPhamService
    {
        private readonly IAnhSanPhamRepository _anhSanPhamRepository;
        private readonly IMapper _mapper;

        public AnhSanPhamService(IAnhSanPhamRepository anhSanPhamRepository, IMapper mapper)
        {
            _anhSanPhamRepository = anhSanPhamRepository;
            _mapper = mapper;
        }
    }
}
