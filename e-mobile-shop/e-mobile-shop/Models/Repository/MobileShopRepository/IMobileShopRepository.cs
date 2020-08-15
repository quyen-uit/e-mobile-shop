using e_mobile_shop.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models.Repository.MobileShopRepository
{
    public interface IMobileShopRepository
    {
        IQueryable<SanPham> GetPaginatedListSanPham(string Id);
        Task<List<SanPham>> GetSanPhamNoiBat(string Id);
        SanPham GetSanPhamById(string Id);
        Task<List<BannerKhuyenMai>> GetBannerKhuyenMais();
        Task<List<BinhLuan>> GetBinhLuans(string Id);
        Task<List<AspNetUsers>> GetCheckoutInfo(string Id);
        Task<List<SanPham>> GetSanPhamTheoGia(string giaTien);
        Task<List<TraLoi>> GetTraLoiBinhLuan(string Id);

        AspNetUsers GetUser(string userId);
        DonHang GetDonHang(string maDh);
        AnhSanPham GetAnhSanPham(string maSp);
        List<string> getGiaTriThongSoKiThuat(List<ThongSoKiThuat> lst);
        List<ThongSoKiThuat> GetThongSoKiThuat(string maSp);
        SanPham GetSanPham(string Id);
        List<NhaSanXuat> GetNSX();
        string GetLoaiSp(string loaiSP);
        string GetTenTSKT(string masp, string mats);
        List<ThongSoKiThuat> ReadThongSoKiThuat(string ma);
        List<ThongSo> ReadThongSo(string loaiSp);
        List<SanPham> ReadSanPham(string loaiSp);
        List<LoaiSp> ReadLoaiSp();
        List<AspNetUsers> ViewSanPham();
        List<ChiTietDonHang> GetChiTietDonHang(string Id);
        //new
        List<AspNetUsers> GetUsers();
        List<Voucher> GetVouchers();
        List<Voucher> GetVouchersByStatus(string status);
        void DeleteVoucher(string id);
        void SaveVoucher(Voucher vc);
    }
}
