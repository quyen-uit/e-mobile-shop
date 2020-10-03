using AutoMapper;
using e_mobile_shop.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{
    public class AspNetUserRolesService :IAspNetUserRolesService
    {
        private readonly IAspNetUserRolesRepository aspNetUserRolesRepository;
        private readonly IMapper _mapper;

        public AspNetUserRolesService(IAspNetUserRolesRepository aspNetUserRolesRepository, IMapper mapper)
        {
            this.aspNetUserRolesRepository = aspNetUserRolesRepository;
            _mapper = mapper;
        }
    }
}
