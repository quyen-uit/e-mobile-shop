using AutoMapper;
using e_mobile_shop.Core.Repository;

namespace e_mobile_shop.Services
{
    public class TraLoiService : ITraLoiService
    {
        private readonly ITraLoiRepository _traLoiRepository;
        private readonly IMapper _mapper;

        public TraLoiService(ITraLoiRepository traLoiRepository, IMapper mapper)
        {
            _traLoiRepository = traLoiRepository;
            _mapper = mapper;
        }
    }
}
