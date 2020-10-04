using AutoMapper;
<<<<<<< HEAD
using e_mobile_shop.Core.Repository;
=======
using e_mobile_shop.Core.Models;
using e_mobile_shop.Core.Repository;
using System.Collections.Generic;
>>>>>>> origin/refactor-code-quyen

namespace e_mobile_shop.Services
{
    public class DonHangService : IDonHangService
    {

        private readonly IDonHangRepository _donHangRepository;
        private readonly IMapper _mapper;

        public DonHangService(IDonHangRepository donHangRepository, IMapper mapper)
        {
            _donHangRepository = donHangRepository;
            _mapper = mapper;
        }
<<<<<<< HEAD
=======

        public List<DonHang> GetAllToNotify()
        {
            return _donHangRepository.GetAllToNotify();
        }
>>>>>>> origin/refactor-code-quyen
    }
}
