using e_mobile_shop.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Services
{
    public class ServiceAccessor:IServiceAccessor
    {
        protected readonly AnhSanPhamRepository anhSanPhamRepository;
        protected readonly BannerKhuyenMaiRepository bannerKhuyenMaiRepository;
        protected readonly BinhLuanRepository binhLuanRepository;
        protected readonly ChiTietDonHangRepository chiTietDonHangRepository;
        protected readonly CountryRepository countryRepository;
        protected readonly DistrictRepository districtRepository;
        protected readonly DonHangRepository donHangRepository;
        protected readonly LoaiSpRepository loaiSpRepository;
        protected readonly NhaCungCapRepository nhaCungCapRepository;
        protected readonly NhaSanXuatRepository nhaSanXuatRepository;
        protected readonly ParameterRepository parameterRepository;
        protected readonly ProvinceRepository provinceRepository;

        /// <summary>
        ///public for test
        /// </summary>
        public readonly SanPhamRepository sanPhamRepository;
        protected readonly ThongSoKiThuatRepository thongSoKiThuatRepository;
        protected readonly ThongSoRepository thongSoRepository;
        protected readonly TraLoiRepository traLoiRepository;
        protected readonly TrangThaiDonHangRepository trangThaiDonHangRepository;
        protected readonly TrangThaiSanPhamRepository trangThaiSanPhamRepository;
        protected readonly VoucherRepository voucherRepository;
        protected readonly VoucherTypeRepository voucherTypeRepository;
        protected readonly WardRepository wardRepository;

        public ServiceAccessor(AnhSanPhamRepository anhSanPhamRepository, BannerKhuyenMaiRepository bannerKhuyenMaiRepository, BinhLuanRepository binhLuanRepository, ChiTietDonHangRepository chiTietDonHangRepository, CountryRepository countryRepository, DistrictRepository districtRepository, DonHangRepository donHangRepository, LoaiSpRepository loaiSpRepository, NhaCungCapRepository nhaCungCapRepository, NhaSanXuatRepository nhaSanXuatRepository, ParameterRepository parameterRepository, ProvinceRepository provinceRepository, Core.Repository.SanPhamRepository sanPhamRepository, ThongSoKiThuatRepository thongSoKiThuatRepository, ThongSoRepository thongSoRepository, TraLoiRepository traLoiRepository, TrangThaiDonHangRepository trangThaiDonHangRepository, TrangThaiSanPhamRepository trangThaiSanPhamRepository, VoucherRepository voucherRepository, VoucherTypeRepository voucherTypeRepository, WardRepository wardRepository)
        {
            this.anhSanPhamRepository = anhSanPhamRepository;
            this.bannerKhuyenMaiRepository = bannerKhuyenMaiRepository;
            this.binhLuanRepository = binhLuanRepository;
            this.chiTietDonHangRepository = chiTietDonHangRepository;
            this.countryRepository = countryRepository;
            this.districtRepository = districtRepository;
            this.donHangRepository = donHangRepository;
            this.loaiSpRepository = loaiSpRepository;
            this.nhaCungCapRepository = nhaCungCapRepository;
            this.nhaSanXuatRepository = nhaSanXuatRepository;
            this.parameterRepository = parameterRepository;
            this.provinceRepository = provinceRepository;
            this.sanPhamRepository = sanPhamRepository;
            this.thongSoKiThuatRepository = thongSoKiThuatRepository;
            this.thongSoRepository = thongSoRepository;
            this.traLoiRepository = traLoiRepository;
            this.trangThaiDonHangRepository = trangThaiDonHangRepository;
            this.trangThaiSanPhamRepository = trangThaiSanPhamRepository;
            this.voucherRepository = voucherRepository;
            this.voucherTypeRepository = voucherTypeRepository;
            this.wardRepository = wardRepository;
        }
    }
}
