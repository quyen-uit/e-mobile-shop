using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class ParameterService : IParameterService
    {

        private readonly IParameterRepository _parameterRepository;
        private readonly IMapper _mapper;

        public ParameterService(IParameterRepository parameterRepository, IMapper mapper)
        {
            _parameterRepository = parameterRepository;
            _mapper = mapper;
        }
    }
}
