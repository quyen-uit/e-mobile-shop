using System.Collections.Generic;
using System.Linq;

namespace e_mobile_shop.Models.Repository
{
    public interface IDonHangRepository
    {
        List<DonHang> GetAll();
        void NotifyDonHang();

        List<DonHang> GetDonHangs();
        List<ChiTietDonHang> GetChiTiets();
        List<ChiTietDonHang> GetChiTietDonHangsByMaDH(string madh);
        IQueryable<DonHang> GetDonHangsByMaKh(string maKh, string type);
        List<DonHang> GetDonHangsByIdStatus(string id, string status);
        DonHang GetDonHangById(string id);
        TrangThaiDonHang GetTTDH(string id);
        void Update(DonHang dh);
        List<TrangThaiDonHang> GetTrangThaiDonHangs();
        string GetTrangThaiDonHang(string id);
        int SoDonHang();
        void AddDonHang(DonHang donHang);
        void AddChiTietDonHang(ChiTietDonHang chiTietDonHang);
    }
}
