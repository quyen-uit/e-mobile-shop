using AutoMapper;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace e_mobile_shop.Services.ThongSoKiThuatService
{
    public class ThongSoKiThuatService : IThongSoKiThuatService
    {
        private readonly IThongSoKiThuatRepository _thongSoKiThuatRepository;
        private readonly IMapper _mapper;

        public ThongSoKiThuatService(IThongSoKiThuatRepository thongSoKiThuatRepository, IMapper mapper)
        {
            _thongSoKiThuatRepository = thongSoKiThuatRepository;
            _mapper = mapper;
        }

        public List<ThongSoKiThuatViewModel> GetThongSoKiThuat(string maSp)
        {
            var a = _thongSoKiThuatRepository.GetAll().Where(x => x.MaSp == maSp).ToList();

            var result = _mapper.Map(a, new List<ThongSoKiThuatViewModel>());
            return result;
        }
    }
}
