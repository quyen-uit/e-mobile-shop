using AutoMapper;
using e_mobile_shop.Core.Repository;
<<<<<<< HEAD
=======
using e_mobile_shop.ViewModels;
using System.Collections.Generic;
>>>>>>> origin/refactor-code-quyen

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
<<<<<<< HEAD
=======

        public List<NhaSanXuatViewModel> GetNhaSanXuats()
        {
            return _mapper.Map<List<NhaSanXuatViewModel>>(_nhaSanXuatRepository.GetAll());
        }

        public string GetTen(string id)
        {
            return _nhaSanXuatRepository.GetById(id).TenNsx;
        }
>>>>>>> origin/refactor-code-quyen
    }
}
