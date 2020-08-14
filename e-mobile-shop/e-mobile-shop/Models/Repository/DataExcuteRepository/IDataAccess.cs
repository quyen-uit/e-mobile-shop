using System;
using System.Linq;

namespace e_mobile_shop.Models.Repository.DataExcuteRepository
{
    public interface IDataAccess
    {
        string GetRoleName(string id);
        bool ExistUser(string id);
        IQueryable<SanPham> FilterSanPhamWithParam(IQueryable<SanPham> sanphams, string params_list,string loaiSp, ClientDbContext context);
        IQueryable<SanPham> FilterTabletBySim(IQueryable<SanPham> sanphams, string _simString, ClientDbContext context);
        IQueryable<SanPham> FilterTabletByRam(IQueryable<SanPham> sanphams, string _ramString, ClientDbContext context);
        IQueryable<SanPham> FilterTabletByScreenSize(IQueryable<SanPham> sanphams, string _screenString,ClientDbContext context);
        IQueryable<SanPham> FilterPhoneBySpecialFeature(IQueryable<SanPham> sanphams,string _featureString, ClientDbContext context);
        IQueryable<SanPham> FilterPhoneByScreenSize(IQueryable<SanPham> sanphams, string _screenString, ClientDbContext context);
        IQueryable<SanPham> FilterPhoneByBattery(IQueryable<SanPham> sanphams, string _batteryString, ClientDbContext context);
        IQueryable<SanPham> FilterPhoneByOs(IQueryable<SanPham> sanphams, string _osString, ClientDbContext context);
        IQueryable<SanPham> FilterLaptopByRequire(IQueryable<SanPham> sanphams, string _requireString, ClientDbContext context);
        IQueryable<SanPham> FilterSanphamBySpecialFeature(IQueryable<SanPham> sanphams,string _featureString, ClientDbContext context);
        IQueryable<SanPham> FilterLaptopByCpu(IQueryable<SanPham> sanphams, string _cpuString,ClientDbContext context);
        IQueryable<SanPham> FilterLaptopByRam(IQueryable<SanPham> sanphams, string _ramString,ClientDbContext context);
        string getSoCtdh();
        void AddCtdh(int value);
    }
}
