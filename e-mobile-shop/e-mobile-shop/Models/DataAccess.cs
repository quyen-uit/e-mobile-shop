using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models
{
    public class DataAccess
    {
        public static ClientDbContext context = new ClientDbContext();
        public static List<AspNetUsers> ViewSanPham()
        {
            return context.AspNetUsers.ToList();
          
        }
        public static List<LoaiSp> ReadLoaiSp()
        {
            return context.LoaiSp.ToList();
        }

        public static List<SanPham> ReadSanPham(string loaiSp)
        {
            if (loaiSp != "00000")
            {
                return context.SanPham.Where(x => x.LoaiSp == loaiSp).ToList();
            }

            else
            {
                return context.SanPham.Where(x => x.LoaiSp != "15674" && x.LoaiSp != "87356" && x.LoaiSp != "89742").ToList();
            }
        }

        public static string GetLoaiSp(string loaiSP)
        {
            return context.LoaiSp.Find(loaiSP).TenLoai;
        }

        public static SanPham GetSanPham(string Id)
        {
                return context.SanPham.Find(Id);
        }

        public static List<ThongSoKiThuat> GetThongSoKiThuat(string maSp)
        {
            return context.ThongSoKiThuat.Where(x => x.MaSp == maSp).ToList();
        }
        public static AnhSanPham GetAnhSanPham(string maSp)
        {
            return context.AnhSanPham.Where(x => x.MaSp == maSp).SingleOrDefault();
        }

        public static DonHang GetDonHang(string maDh)
        {
            return context.DonHang.Find(maDh);
        }
        public static AspNetUsers GetUser(string userId)
        {
            return context.AspNetUsers.Find(userId);
        }
    }
}
