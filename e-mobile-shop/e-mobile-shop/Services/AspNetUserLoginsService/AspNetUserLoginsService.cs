using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class AspNetUserLoginsService : IAspNetUserLoginsService
    {
        private readonly IAspNetUserLoginsRepository _aspNetUserLoginsRepository;
        private readonly IMapper _mapper;

        public AspNetUserLoginsService(IAspNetUserLoginsRepository aspNetUserLoginsRepository, IMapper mapper)
        {
            this._aspNetUserLoginsRepository = aspNetUserLoginsRepository;
            _mapper = mapper;
        }
    }
}
