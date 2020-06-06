﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models
{
    public class DataAccess
    {
        public static int soCtdh =0;
        public static ClientDbContext context = new ClientDbContext();
        public static List<AspNetUsers> ViewSanPham()
        {
            return context.AspNetUsers.ToList();

        }
        public static List<LoaiSp> ReadLoaiSp()
        {
            List<LoaiSp> result = new List<LoaiSp>();
            result.Add(context.LoaiSp.Find("LSP0001"));

            foreach (var item in context.LoaiSp.ToList())
            {
                if(item.TenLoai!="Phụ Kiện")
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<SanPham> ReadSanPham(string loaiSp)
        {
            if (loaiSp != "LSP0001")
            {
                return context.SanPham.Where(x => x.LoaiSp == loaiSp).ToList();
            }

            else
            {
                return context.SanPham.Where(x => x.LoaiSp != "LSP0002" && x.LoaiSp != "LSP0007" && x.LoaiSp != "LSP0008").ToList();
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
        public static List<string> getGiaTriThongSoKiThuat(List<ThongSoKiThuat> lst)
        {
            List<string> result = new List<string>();
            foreach (var item in lst)
            {
                result.Add(item.GiaTri.ToLower());
            }
            return result;
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