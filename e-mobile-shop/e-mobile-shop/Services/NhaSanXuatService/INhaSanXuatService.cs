using e_mobile_shop.ViewModels;
using System.Collections.Generic;

namespace e_mobile_shop.Services
{
    public interface INhaSanXuatService
    {
        List<NhaSanXuatViewModel> GetNhaSanXuats();
        string GetTen(string id);
    }
}
