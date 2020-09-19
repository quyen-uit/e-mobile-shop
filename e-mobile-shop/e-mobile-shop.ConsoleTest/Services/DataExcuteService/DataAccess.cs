using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using e_mobile_shop.Core.Repository;
using Microsoft.AspNetCore.Http;

namespace e_mobile_shop.Services
{
    public class DataAccess: ServiceAccessor,IDataAccess
    {
        private  readonly HttpContextAccessor httpContextAccessor = new HttpContextAccessor();
        static int soCtdh;

        public DataAccess(AnhSanPhamRepository anhSanPhamRepository, BannerKhuyenMaiRepository bannerKhuyenMaiRepository, BinhLuanRepository binhLuanRepository, ChiTietDonHangRepository chiTietDonHangRepository, CountryRepository countryRepository, DistrictRepository districtRepository, DonHangRepository donHangRepository, LoaiSpRepository loaiSpRepository, NhaCungCapRepository nhaCungCapRepository, NhaSanXuatRepository nhaSanXuatRepository, ParameterRepository parameterRepository, ProvinceRepository provinceRepository, Core.Repository.SanPhamRepository sanPhamRepository, ThongSoKiThuatRepository thongSoKiThuatRepository, ThongSoRepository thongSoRepository, TraLoiRepository traLoiRepository, TrangThaiDonHangRepository trangThaiDonHangRepository, TrangThaiSanPhamRepository trangThaiSanPhamRepository, VoucherRepository voucherRepository, VoucherTypeRepository voucherTypeRepository, WardRepository wardRepository) : base(anhSanPhamRepository, bannerKhuyenMaiRepository, binhLuanRepository, chiTietDonHangRepository, countryRepository, districtRepository, donHangRepository, loaiSpRepository, nhaCungCapRepository, nhaSanXuatRepository, parameterRepository, provinceRepository, sanPhamRepository, thongSoKiThuatRepository, thongSoRepository, traLoiRepository, trangThaiDonHangRepository, trangThaiSanPhamRepository, voucherRepository, voucherTypeRepository, wardRepository)
        {
        }

   
    }
}