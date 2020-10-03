using AutoMapper;

namespace e_mobile_shop.Services
{
    public class AspNetUserClaimsService : IAspNetUserClaimsService
    {
        private readonly IAspNetUserClaimsService _aspNetUserClaimsService;
        private readonly IMapper _mapper;

        public AspNetUserClaimsService(IAspNetUserClaimsService aspNetUserClaimsService, IMapper mapper)
        {
            this._aspNetUserClaimsService = aspNetUserClaimsService;
            _mapper = mapper;
        }
    }
}
