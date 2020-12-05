

using AutoMapper;
using e_mobile_shop.Core.Models;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;

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

        public void Add(AnhSanPhamViewModel asp)
        {
            _anhSanPhamRepository.Add(_mapper.Map<AnhSanPham>(asp));
        }

        public AnhSanPhamViewModel GetByIdSp(string id)
        {
            return _mapper.Map<AnhSanPhamViewModel>(_anhSanPhamRepository.GetAnhSanPham(id));
        }

        public void SaveChange()
        {
            _anhSanPhamRepository.SaveChanges();
        }

        public void UpdateAnhSP(AnhSanPhamViewModel asp)
        {
            _anhSanPhamRepository.UpdateAnhSP(_mapper.Map<AnhSanPham>(asp));
        }
    }
}
