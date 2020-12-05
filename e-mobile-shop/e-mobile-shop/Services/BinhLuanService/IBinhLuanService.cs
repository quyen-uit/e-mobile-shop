using e_mobile_shop.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{
    public interface IBinhLuanService
    { 
        Task<List<BinhLuanViewModel>> GetBinhLuans(string Id);
    }
}
