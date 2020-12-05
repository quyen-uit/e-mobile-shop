using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class VoucherTypeService : IVoucherTypeService
    {
        private readonly IVoucherTypeRepository _voucherTypeRepository;
        private readonly IMapper _mapper;

        public VoucherTypeService(IVoucherTypeRepository voucherTypeRepository, IMapper mapper)
        {
            _voucherTypeRepository = voucherTypeRepository;
            _mapper = mapper;
        }
    }
}
