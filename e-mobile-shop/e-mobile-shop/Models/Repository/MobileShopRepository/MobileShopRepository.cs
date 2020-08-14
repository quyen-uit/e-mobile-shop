using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace e_mobile_shop.Models.Repository.MobileShopRepository
{

    public class MobileShopRepository : IMobileShopRepository
    {
        private readonly ClientDbContext context;
        public MobileShopRepository(ClientDbContext _context)
        {
            context = _context;
        }

        public IQueryable<SanPham> FilterSanPhamWithParam(IQueryable<SanPham> sanphams, string params_list, string loaiSp, ClientDbContext _context)
        {
            throw new NotImplementedException();
        }

        public Task<List<BannerKhuyenMai>> GetBannerKhuyenMais()
        {
            return context.BannerKhuyenMai.ToListAsync();
        }

        public Task<List<BinhLuan>> GetBinhLuans(string Id)
        {
            var result = context.BinhLuan.Where(x => x.MaSp == Id && x.Status != 0).ToListAsync();
            return result;
        }

        public Task<List<AspNetUsers>> GetCheckoutInfo(string Id)
        {
            var result = context.AspNetUsers.Where(x => x.Id.Equals(Id)).ToListAsync();
            return result;
        }

      

        public IQueryable<SanPham> GetPaginatedListSanPham(string Id)
        {
            var sanphams = from s in context.SanPham select s;

            if (Id != "LSP0006")
            {
                sanphams = context.SanPham.Where(x => x.LoaiSp == Id);
            }
            else
            {
                sanphams = context.SanPham.Where(x => x.LoaiSp != "LSP0002" && x.LoaiSp != "LSP0007" && x.LoaiSp != "LSP0008");
            }
            return sanphams;
        }

        public SanPham GetSanPhamById(string Id)
        {
            context.SanPham.Find(Id).SoLuotXemSp++;
            context.SaveChanges();
            return context.SanPham.Find(Id);
        }

        public Task<List<SanPham>> GetSanPhamNoiBat(string Id)
        {
            var result = (from t in context.SanPham
                          where t.LoaiSp == Id && t.SoLuong > 0
                          orderby t.GiaGoc descending
                          select t).Take(4).ToListAsync();
            return result;
        }

        public Task<List<SanPham>> GetSanPhamTheoGia(string giaTien)
        {

            if (!string.IsNullOrEmpty(giaTien))
            {
                var result = (from t in context.SanPham
                              where t.GiaGoc <= int.Parse(giaTien)
                              select t).ToListAsync();
                return result;
            }
            else
            {
                return context.SanPham.ToListAsync();
            }

        }

        public Task<List<TraLoi>> GetTraLoiBinhLuan(string Id)
        {
            var result = context.TraLoi.Where(x => x.MaBinhLuan == Id && x.TrangThai!=0 ).ToListAsync();
            return result;
        }
    
        public List<AspNetUsers> ViewSanPham()
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.AspNetUsers.ToList();
                }
                catch (Exception)
                {
                    return new List<AspNetUsers>();
                }
            }
        }

        public List<LoaiSp> ReadLoaiSp()
        {
            using (var context = new ClientDbContext())
            {
                var result = new List<LoaiSp>();

                foreach (var item in context.LoaiSp.ToList())
                    if (item.TenLoai != "Phụ Kiện")
                        result.Add(item);
                return result;
            }
        }

        public List<SanPham> ReadSanPham(string loaiSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.SanPham.Where(x => x.LoaiSp == loaiSp).ToList();
                }
                catch (Exception)
                {
                    return new List<SanPham>();
                }
            }
        }

        public List<ThongSo> ReadThongSo(string loaiSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.ThongSo.Where(x => x.MaLoai == loaiSp).ToList();
                }
                catch (Exception)
                {
                    return new List<ThongSo>();
                }
            }
        }

        public List<ThongSoKiThuat> ReadThongSoKiThuat(string ma)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.ThongSoKiThuat.Where(x => x.MaSp == ma).ToList();
                }
                catch (Exception)
                {
                    return new List<ThongSoKiThuat>();
                }
            }
        }

        public string GetTenTSKT(string masp, string mats)
        {
            using (var context = new ClientDbContext())
            {
                var temp = context.ThongSoKiThuat.FirstOrDefault(x => x.MaSp == masp && x.ThongSo == mats);
                if (temp != null)
                    return temp.GiaTri;
                return "";
            }
        }

        public string GetLoaiSp(string loaiSP)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.LoaiSp.Find(loaiSP).TenLoai;
                }
                catch (Exception)
                {
                    return "";
                }
            }
        }

        public List<NhaSanXuat> GetNSX()
        {
            using (var context = new ClientDbContext())
            {
                try
                {

                    return context.NhaSanXuat.ToList();
                }
                catch (Exception)
                {
                    return new List<NhaSanXuat>();
                }
            }
        }

        public SanPham GetSanPham(string Id)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.SanPham.Find(Id);

                } catch(Exception)
                {
                    return new SanPham();
                }
            }
        }

        public List<ThongSoKiThuat> GetThongSoKiThuat(string maSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.ThongSoKiThuat.Where(x => x.MaSp == maSp).ToList();
                }
                catch (Exception)
                {
                    return new List<ThongSoKiThuat>();
                }
            }
        }

        public List<string> getGiaTriThongSoKiThuat(List<ThongSoKiThuat> lst)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    var result = new List<string>();
                    foreach (var item in lst) result.Add(item.GiaTri.ToLower());
                    return result;
                }
                catch (Exception)
                {
                    return new List<string>();
                }
            }
        }

        public AnhSanPham GetAnhSanPham(string maSp)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.AnhSanPham.SingleOrDefault(x => x.MaSp == maSp);

                } catch(Exception)
                {
                    return new AnhSanPham();
                }
            }
        }

        public DonHang GetDonHang(string maDh)
        {
            using (var context = new ClientDbContext())
            {
                return context.DonHang.Find(maDh);
            }
        }

        public AspNetUsers GetUser(string userId)
        {
            using (var context = new ClientDbContext())
            {
                try
                {
                    return context.AspNetUsers.Find(userId);
                }
                catch (Exception)
                {
                    return new AspNetUsers();
                }
            }
        }

        public List<ChiTietDonHang> GetChiTietDonHang(string Id)
        {
            if (Id != null)
            {
                return context.ChiTietDonHang.Where(x => x.MaDh == Id).ToList();
            }
            else return new List<ChiTietDonHang>();
        }
    }
}
