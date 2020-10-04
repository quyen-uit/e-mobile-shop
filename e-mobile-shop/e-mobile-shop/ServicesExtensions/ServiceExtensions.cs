using e_mobile_shop.Core.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace e_mobile_shop.ServicesExtensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
<<<<<<< HEAD
            services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            
            services.AddTransient<IAnhSanPhamRepository, AnhSanPhamRepository>();

            services.AddTransient<IAspNetRoleClaimsRepository, AspNetRoleClaimsRepository>();
           
            services.AddTransient<IAspNetRolesRepository, AspNetRolesRepository>();
           
            services.AddTransient<IAspNetUserClaimsRepository, AspNetUserClaimsRepository>();
           
            services.AddTransient<IAspNetUserLoginsRepository, AspNetUserLoginsRepository>();
           
            services.AddTransient<IAspNetUserRolesRepository, AspNetUserRolesRepository>();
           
            services.AddTransient<IAspNetUsersRepository, AspNetUsersRepository>();
          
            services.AddTransient<IAspNetUserRolesRepository, AspNetUserRolesRepository>();
          
            services.AddTransient<IAspNetUserTokensRepository, AspNetUserTokensRepository>();

            services.AddTransient<IBannerKhuyenMaiRepository, BannerKhuyenMaiRepository>();

            services.AddTransient<IBinhLuanRepository, BinhLuanRepository>();

            services.AddTransient<IChiTietDonHangRepository, ChiTietDonHangRepository>();

            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddTransient<IDistrictRepository, DistrictRepository>();

            services.AddTransient<IDonHangRepository, DonHangRepository>();

            services.AddTransient<ILoaiSpRepository, LoaiSpRepository>();

            services.AddTransient<INhaCungCapRepository, NhaCungCapRepository>();

            services.AddTransient<INhaSanXuatRepository, NhaSanXuatRepository>();

            services.AddTransient<IParameterRepository, ParameterRepository>();

            services.AddTransient<IProvinceRepository, ProvinceRepository>();

            services.AddTransient<IThongSoKiThuatRepository, ThongSoKiThuatRepository>();

            services.AddTransient<IThongSoRepository, ThongSoRepository>();

            services.AddTransient<ITraLoiRepository, TraLoiRepository>();

            services.AddTransient<ITrangThaiDonHangRepository, TrangThaiDonHangRepository>();

            services.AddTransient<ITrangThaiSanPhamRepository, TrangThaiSanPhamRepository>();

            services.AddTransient<IVoucherRepository, VoucherRepository>();

            services.AddTransient<IVoucherTypeRepository, VoucherTypeRepository>();

            services.AddTransient<IWardRepository, WardRepository>();
=======
        //    services.AddTransient<ISanPhamRepository, SanPhamRepository>();
            
        //    services.AddTransient<IAnhSanPhamRepository, AnhSanPhamRepository>();

        //    services.AddTransient<IAspNetRoleClaimsRepository, AspNetRoleClaimsRepository>();
           
        //    services.AddTransient<IAspNetRolesRepository, AspNetRolesRepository>();
           
        //    services.AddTransient<IAspNetUserClaimsRepository, AspNetUserClaimsRepository>();
           
        //    services.AddTransient<IAspNetUserLoginsRepository, AspNetUserLoginsRepository>();
           
        //    services.AddTransient<IAspNetUserRolesRepository, AspNetUserRolesRepository>();
           
        //    services.AddTransient<IAspNetUsersRepository, AspNetUsersRepository>();
          
        //    services.AddTransient<IAspNetUserRolesRepository, AspNetUserRolesRepository>();
          
        //    services.AddTransient<IAspNetUserTokensRepository, AspNetUserTokensRepository>();

        //    services.AddTransient<IBannerKhuyenMaiRepository, BannerKhuyenMaiRepository>();

        //    services.AddTransient<IBinhLuanRepository, BinhLuanRepository>();

        //    services.AddTransient<IChiTietDonHangRepository, ChiTietDonHangRepository>();

        //    services.AddTransient<ICountryRepository, CountryRepository>();

        //    services.AddTransient<IDistrictRepository, DistrictRepository>();

        //    services.AddTransient<IDonHangRepository, DonHangRepository>();

        //    services.AddTransient<ILoaiSpRepository, LoaiSpRepository>();

        //    services.AddTransient<INhaCungCapRepository, NhaCungCapRepository>();

        //    services.AddTransient<INhaSanXuatRepository, NhaSanXuatRepository>();

        //    services.AddTransient<IParameterRepository, ParameterRepository>();

        //    services.AddTransient<IProvinceRepository, ProvinceRepository>();

        //    services.AddTransient<IThongSoKiThuatRepository, ThongSoKiThuatRepository>();

        //    services.AddTransient<IThongSoRepository, ThongSoRepository>();

        //    services.AddTransient<ITraLoiRepository, TraLoiRepository>();

        //    services.AddTransient<ITrangThaiDonHangRepository, TrangThaiDonHangRepository>();

        //    services.AddTransient<ITrangThaiSanPhamRepository, TrangThaiSanPhamRepository>();

        //    services.AddTransient<IVoucherRepository, VoucherRepository>();

        //    services.AddTransient<IVoucherTypeRepository, VoucherTypeRepository>();

        //    services.AddTransient<IWardRepository, WardRepository>();
>>>>>>> origin/refactor-code-quyen

        }
    }
}
