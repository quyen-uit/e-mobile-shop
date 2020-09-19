using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services.ThongSoKiThuatService
{
    public class TrangThaiSanPhamService : ITrangThaiSanPhamService
    {
        private readonly ITrangThaiSanPhamRepository _trangThaiSanPhamRepository;
        private readonly IMapper _mapper;

        public TrangThaiSanPhamService(ITrangThaiSanPhamRepository trangThaiSanPhamRepository, IMapper mapper)
        {
            _trangThaiSanPhamRepository = trangThaiSanPhamRepository;
            _mapper = mapper;
        }
    }
}
