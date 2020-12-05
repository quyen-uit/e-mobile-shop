using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e_mobile_shop.Core.Repository
{
    public interface IDonHangRepository : IBaseRepository<DonHang>
    {
        List<DonHang> GetAllToNotify();
        void NotifyDonHang();
        List<DonHang> GetDonHangs();
        IQueryable<DonHang> GetDonHangsByMaKh(string maKh, string type);
        List<DonHang> GetDonHangsByIdStatus(string id, string status);
        DonHang GetDonHangById(string id);
        string GetTrangThaiDonHang(string id);
        int SoDonHang();
        void AddDonHang(DonHang donHang);

        //

        TrangThaiDonHang GetTTDH(string id);
        //void Update(DonHang dh);
        List<TrangThaiDonHang> GetTrangThaiDonHangs();
        // chi tiet don hang

        List<ChiTietDonHang> GetChiTiets();
        List<ChiTietDonHang> GetChiTietDonHangsByMaDH(string madh);
        void AddChiTietDonHang(ChiTietDonHang chiTietDonHang);

    }
}
