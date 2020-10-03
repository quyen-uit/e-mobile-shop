using AutoMapper;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using System.Collections.Generic;

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

        public List<NhaSanXuatViewModel> GetNhaSanXuats()
        {
            return _mapper.Map<List<NhaSanXuatViewModel>>(_nhaSanXuatRepository.GetAll());
        }

        public string GetTen(string id)
        {
            return _nhaSanXuatRepository.GetById(id).TenNsx;
        }
    }
}
