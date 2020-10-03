using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace e_mobile_shop.Core.Repository
{
    public interface ISanPhamRepository:IBaseRepository<SanPham>
    {
        IQueryable<SanPham> FilterSanPhamWithParam(IQueryable<SanPham> sanphams, string params_list, string loaiSp,ApplicationDbContext  context);
        IQueryable<SanPham> FilterTabletBySim(IQueryable<SanPham> sanphams, string _simString, ApplicationDbContext context);
        IQueryable<SanPham> FilterTabletByRam(IQueryable<SanPham> sanphams, string _ramString, ApplicationDbContext context);
        IQueryable<SanPham> FilterTabletByScreenSize(IQueryable<SanPham> sanphams, string _screenString, ApplicationDbContext context);
        IQueryable<SanPham> FilterPhoneBySpecialFeature(IQueryable<SanPham> sanphams, string _featureString, ApplicationDbContext context);
        IQueryable<SanPham> FilterPhoneByScreenSize(IQueryable<SanPham> sanphams, string _screenString, ApplicationDbContext context);
        IQueryable<SanPham> FilterPhoneByBattery(IQueryable<SanPham> sanphams, string _batteryString, ApplicationDbContext context);
        IQueryable<SanPham> FilterPhoneByOs(IQueryable<SanPham> sanphams, string _osString, ApplicationDbContext context);
        IQueryable<SanPham> FilterLaptopByRequire(IQueryable<SanPham> sanphams, string _requireString, ApplicationDbContext context);
        IQueryable<SanPham> FilterSanphamBySpecialFeature(IQueryable<SanPham> sanphams, string _featureString, ApplicationDbContext context);
        IQueryable<SanPham> FilterLaptopByCpu(IQueryable<SanPham> sanphams, string _cpuString, ApplicationDbContext context);
        IQueryable<SanPham> FilterLaptopByRam(IQueryable<SanPham> sanphams, string _ramString, ApplicationDbContext context);

        SanPham GetSanPhamById(string id);
        List<SanPham> GetSanPhamsByIdStatus(string id, string status);
        void Save(SanPham sp);
        //void SaveAnhSP(AnhSanPham anh);
        //void UpdateAnhSP(AnhSanPham anh);
        //AnhSanPham GetAnhSanPham(string maSp);
        //void SaveTSKT(ThongSoKiThuat tskt);
        //void UpdateTSKT(ThongSoKiThuat tskt);
        void Delete(string id);
        void Update(SanPham sp, string masp);
        void UpdateSoLuong(string maSp, int? soLuong);
       // List<ThongSo> GetThongSo(string Id);
        string GetLoaiSp(string id);
        int CountSanPham(string loaiSp);
        List<SanPham> ReadSanPham(string loaiSp);

    }
}
