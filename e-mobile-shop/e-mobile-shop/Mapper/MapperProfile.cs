using AutoMapper;
using e_mobile_shop.Core.Models;
using e_mobile_shop.ViewModels;

namespace e_mobile_shop.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AnhSanPham, AnhSanPhamViewModel>().ReverseMap();
            CreateMap<AspNetRoleClaims, AspNetRoleClaimsViewModel>().ReverseMap();
            CreateMap<AspNetRoles, AspNetRolesViewModel>().ReverseMap();
            CreateMap<AspNetUserClaims, AspNetUserClaimsViewModel>().ReverseMap();
            CreateMap<AspNetUserLogins, AspNetUserLoginsViewModel>().ReverseMap();
            CreateMap<AspNetUserRoles, AspNetUserRolesViewModel>().ReverseMap();
            CreateMap<AspNetUsers, AspNetUsersViewModel>().ReverseMap();
            CreateMap<AspNetUserTokens, AspNetUserTokensViewModel>().ReverseMap();
            CreateMap<BannerKhuyenMai, BannerKhuyenMaiViewModel>().ReverseMap();
            CreateMap<BinhLuan, BinhLuanViewModel>().ReverseMap();

            CreateMap<ChiTietDonHang, ChiTietDonHangViewModel>().ReverseMap();
            CreateMap<Country, CountryViewModel>().ReverseMap();
            CreateMap<District, DistrictViewModel>().ReverseMap();
            CreateMap<DonHang, DonHangViewModel>().ReverseMap();
            CreateMap<LoaiSp, LoaiSpViewModel>().ReverseMap();
            CreateMap<NhaCungCap, NhaCungCapViewModel>().ReverseMap();
            CreateMap<NhaSanXuat, NhaSanXuatViewModel>().ReverseMap();
            CreateMap<AspNetUserTokens, AspNetUserTokensViewModel>().ReverseMap();
            CreateMap<Parameters, ParametersViewModel>().ReverseMap();
            CreateMap<Province, ProvinceViewModel>().ReverseMap();

            CreateMap<SanPham, SanPhamViewModel>().ReverseMap();
            CreateMap<ThongSoKiThuat, ThongSoKiThuatViewModel>().ReverseMap();
            CreateMap<ThongSo, ThongSoViewModel>().ReverseMap();
            CreateMap<TraLoi, TraLoiViewModel>().ReverseMap();
            CreateMap<TrangThaiDonHang, TrangThaiDonHangViewModel>().ReverseMap();
            CreateMap<NhaCungCap, NhaCungCapViewModel>().ReverseMap();
            CreateMap<TrangThaiSanPham, TrangThaiSanPhamViewModel>().ReverseMap();
            CreateMap<VoucherType, VoucherTypeViewModel>().ReverseMap();
            CreateMap<Voucher, VoucherViewModel>().ReverseMap();
            CreateMap<Ward, WardViewModel>().ReverseMap();

        }
    }
}
