using e_mobile_shop.Services;
using e_mobile_shop.Services.SanPhamService;
using e_mobile_shop.Services.ThongSoKiThuatService;
using Microsoft.Extensions.DependencyInjection;

namespace e_mobile_shop.ServicesExtensions
{
    public static class ConfigureCustomServices
    {
        public static void CustomServices(this IServiceCollection services)
        {
            services.AddTransient<ISanPhamService, SanPhamService>();

            services.AddTransient<IAnhSanPhamService, AnhSanPhamService>();

            services.AddTransient<IAspNetRoleClaimsService, AspNetRoleClaimsService>();

            services.AddTransient<IAspNetRolesService, AspNetRolesService>();

            services.AddTransient<IAspNetUserClaimsService, AspNetUserClaimsService>();

            services.AddTransient<IAspNetUserLoginsService, AspNetUserLoginsService>();

            services.AddTransient<IAspNetUserRolesService, AspNetUserRolesService>();

            services.AddTransient<IAspNetUsersService, AspNetUsersService>();

            services.AddTransient<IAspNetUserRolesService, AspNetUserRolesService>();

            services.AddTransient<IAspNetUserTokensService, AspNetUserTokensService>();

            services.AddTransient<IBannerKhuyenMaiService, BannerKhuyenMaiService>();

            services.AddTransient<IBinhLuanService, BinhLuanService>();

            services.AddTransient<IChiTietDonHangService, ChiTietDonHangService>();

            services.AddTransient<ICountryService, CountryService>();

            services.AddTransient<IDistrictService, DistrictService>();

            services.AddTransient<IDonHangService, DonHangService>();

            services.AddTransient<ILoaiSpService, LoaiSpService>();

            services.AddTransient<INhaCungCapService, NhaCungCapService>();

            services.AddTransient<INhaSanXuatService, NhaSanXuatService>();

            services.AddTransient<IParameterService, ParameterService>();

            services.AddTransient<IProvinceService, ProvinceService>();

            services.AddTransient<IThongSoKiThuatService, ThongSoKiThuatService>();

            services.AddTransient<IThongSoService, ThongSoService>();

            services.AddTransient<ITraLoiService, TraLoiService>();

            services.AddTransient<ITrangThaiDonHangService, TrangThaiDonHangService>();

            services.AddTransient<ITrangThaiSanPhamService, TrangThaiSanPhamService>();

            services.AddTransient<IVoucherService, VoucherService>();

            services.AddTransient<IVoucherTypeService, VoucherTypeService>();

            services.AddTransient<IWardService, WardService>();

        }
    }
}
