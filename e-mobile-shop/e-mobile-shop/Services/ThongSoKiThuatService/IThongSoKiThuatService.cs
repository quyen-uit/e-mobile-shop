using e_mobile_shop.ViewModels;
using System.Collections.Generic;

namespace e_mobile_shop.Services.ThongSoKiThuatService
{
    public interface IThongSoKiThuatService
    {
        public List<ThongSoKiThuatViewModel> GetThongSoKiThuat(string maSp);
    }
}
