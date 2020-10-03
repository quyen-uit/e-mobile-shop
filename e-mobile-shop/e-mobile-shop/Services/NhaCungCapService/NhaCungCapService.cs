using AutoMapper;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using System.Collections.Generic;
using System.Linq;

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

        public List<NhaCungCapViewModel> GetNhaCungCaps()
        {
            return _mapper.Map<List<NhaCungCapViewModel>>(_nhaCungCapRepository.GetAll().ToList());
        }
    }
}
