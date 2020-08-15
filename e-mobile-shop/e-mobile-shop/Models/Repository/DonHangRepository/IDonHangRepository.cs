using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models.Repository
{
    public interface IDonHangRepository
    {
        List<DonHang> GetAll();
        void NotifyDonHang();

        List<DonHang> GetDonHangs();
        List<ChiTietDonHang> GetChiTietDonHangsByMaDH(string madh);
        List<DonHang> GetDonHangsByIdStatus(string id, string status);
        DonHang GetDonHangById(string id);
        TrangThaiDonHang GetTTDH(string id);
        void Update(DonHang dh);
    }
}
