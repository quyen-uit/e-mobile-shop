using System;
using System.Collections.Generic;
using System.Linq;

namespace e_mobile_shop.Models.Repository.SanPhamRepository
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ClientDbContext context;
        public SanPhamRepository(ClientDbContext _context)
        {
            context = _context;
        }

        public SanPham GetSanPhamById(string id)
        {
            using (var context = new ClientDbContext())
            {
                return context.SanPham.Find(id);
            }
        }


        public List<SanPham> GetSanPhamsByIdStatus(string id, string status)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.SanPham.Where(x => x.LoaiSp == id && x.Status == Int32.Parse(status)).ToList();
                }
                catch
                {
                    return context.SanPham.ToList();
                }
            }
        }

        public void Save(SanPham sp)
        {
            context.SanPham.Add(sp);
            context.SaveChanges();
        }

        public void SaveAnhSP(AnhSanPham anh)
        {
            context.AnhSanPham.Add(anh);
            context.SaveChanges();
        }
        public void UpdateAnhSP(AnhSanPham anh)
        {
            context.AnhSanPham.Update(anh);
            context.SaveChanges();
        }
        public void SaveTSKT(ThongSoKiThuat tskt)
        {
            context.ThongSoKiThuat.AddAsync(tskt);
            context.SaveChanges();
        }
        public void UpdateTSKT(ThongSoKiThuat tskt)
        {
            context.Update(tskt);
            context.SaveChanges();
        }
        public void Delete(string id)
        {
            context.SanPham.Find(id).Status = 0;
            context.SaveChanges();
        }
        public void Update(SanPham sp, string masp)
        {
            SanPham a = context.SanPham.Find(masp);
            context.Entry(a).CurrentValues.SetValues(sp);
            context.SaveChanges();
        }

        public List<ThongSo> GetThongSo(string Id)
        {
            return context.ThongSo.Where(x => x.MaLoai == Id).ToList();
        }

        public string GetLoaiSp(string id)
        {
            return context.LoaiSp.Find(id).TenLoai;
        }

        public int CountSanPham(string loaiSp)
        {
            return context.SanPham.Where(x => x.LoaiSp == loaiSp).ToList().Count;
        }

        public void UpdateSoLuong(string maSp, int? soLuong)
        {
            context.SanPham.Find(maSp).SoLuong = context.SanPham.Find(maSp).SoLuong - soLuong;
            context.SaveChanges();
        }

        public AnhSanPham GetAnhSanPham(string maSp)
        {
            return context.AnhSanPham.Where(x => x.MaSp == maSp).FirstOrDefault();
        }


    }
}
