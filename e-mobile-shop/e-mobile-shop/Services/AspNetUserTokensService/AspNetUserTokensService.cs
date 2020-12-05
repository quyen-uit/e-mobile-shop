using AutoMapper;
using e_mobile_shop.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{
    public class AspNetUserTokensService:IAspNetUserTokensService
    {
        private readonly IAspNetUserTokensRepository _aspNetUserTokensRepository;
        private readonly IMapper _mapper;

        public AspNetUserTokensService(IAspNetUserTokensRepository aspNetUserTokensRepository, IMapper mapper)
        {
            this._aspNetUserTokensRepository = aspNetUserTokensRepository;
            _mapper = mapper;
        }
    }
}
