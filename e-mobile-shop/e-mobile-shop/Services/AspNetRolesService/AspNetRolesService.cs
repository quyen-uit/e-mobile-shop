using AutoMapper;
using e_mobile_shop.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{
    public class AspNetRolesService:IAspNetRolesService
    {
        private readonly IAspNetRolesRepository _aspNetRolesRepository;
        private readonly IMapper _mapper;

        public AspNetRolesService(IAspNetRolesRepository aspNetRolesRepository, IMapper mapper)
        {
            _aspNetRolesRepository = aspNetRolesRepository;
            _mapper = mapper;
        }
    }
}
