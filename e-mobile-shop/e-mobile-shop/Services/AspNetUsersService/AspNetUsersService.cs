using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class AspNetUsersService : IAspNetUsersService
    {
        private readonly IAspNetUsersRepository _aspNetUsersRepository;
        private readonly IMapper _mapper;

        public AspNetUsersService(IAspNetUsersRepository aspNetUsersRepository, IMapper mapper)
        {
            this._aspNetUsersRepository = aspNetUsersRepository;
            _mapper = mapper;
        }
    }
}
