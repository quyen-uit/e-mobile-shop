﻿using System.Collections.Generic;

namespace e_mobile_shop.Models.Repository.SanPhamRepository
{
    public interface ISanPhamRepository
    {
        SanPham GetSanPhamById(string id);
        List<SanPham> GetSanPhamsByIdStatus(string id, string status);
        void Save(SanPham sp);
        void SaveAnhSP(AnhSanPham anh);
        void UpdateAnhSP(AnhSanPham anh);
        void SaveTSKT(ThongSoKiThuat tskt);
        void UpdateTSKT(ThongSoKiThuat tskt);
        void Delete(string id);
        void Update(SanPham sp, string masp);
        void UpdateSoLuong(string maSp, int? soLuong);
        List<ThongSo> GetThongSo(string Id);
        string GetLoaiSp(string id);
        int CountSanPham(string loaiSp);
        AnhSanPham GetAnhSanPham(string maSp);

    }
}
