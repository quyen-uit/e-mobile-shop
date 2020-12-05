using AutoMapper;
using e_mobile_shop.Core.Models;
using e_mobile_shop.Core.Repository;
using System.Collections.Generic;

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

        public List<DonHang> GetAllToNotify()
        {
            return _donHangRepository.GetAllToNotify();
        }
    }
}
