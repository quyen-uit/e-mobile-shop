using AutoMapper;
using e_mobile_shop.Core.Models;
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

        public void AddTSKT(ThongSoKiThuatViewModel tskt)
        {
            _thongSoKiThuatRepository.AddTSKT(_mapper.Map<ThongSoKiThuat>(tskt));
        }

        public string GetTen(string masp, string mats)
        {
            return _thongSoKiThuatRepository.GetTSKT(masp, mats).GiaTri;
        }

        public List<ThongSoKiThuatViewModel> GetThongSoKiThuat(string maSp)
        {
            var a = _thongSoKiThuatRepository.GetAll().Where(x => x.MaSp == maSp).ToList();

            var result = _mapper.Map(a, new List<ThongSoKiThuatViewModel>());
            return result;
        }

        public void SaveChange()
        {
            _thongSoKiThuatRepository.SaveChanges();
        }

        public void UpdateTSKT(ThongSoKiThuatViewModel tskt)
        {
            _thongSoKiThuatRepository.UpdateTSKT(_mapper.Map<ThongSoKiThuat>(tskt));
        }
    }
}
