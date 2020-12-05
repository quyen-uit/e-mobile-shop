using AutoMapper;
using e_mobile_shop.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{ 
    public class AspNetRoleClaimsService:IAspNetRoleClaimsService
    {
        private readonly IAspNetRoleClaimsRepository _aspNetRoleClaimsRepository;
        private readonly IMapper _mapper;

        public AspNetRoleClaimsService(IAspNetRoleClaimsRepository aspNetRoleClaimsRepository, IMapper mapper)
        {
            _aspNetRoleClaimsRepository = aspNetRoleClaimsRepository;
            _mapper = mapper;
        }
    }
}
