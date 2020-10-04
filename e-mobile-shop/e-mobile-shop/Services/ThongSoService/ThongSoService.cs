using AutoMapper;
<<<<<<< HEAD
using e_mobile_shop.Core.Repository;
=======
using e_mobile_shop.Core.Models;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using System.Collections.Generic;
>>>>>>> origin/refactor-code-quyen

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
<<<<<<< HEAD
=======

        public List<ThongSoViewModel> GetThongSo(string Id)
        {
            return _mapper.Map<List<ThongSoViewModel>>(_thongSoRepository.GetThongSo(Id));
        }
>>>>>>> origin/refactor-code-quyen
    }
}
