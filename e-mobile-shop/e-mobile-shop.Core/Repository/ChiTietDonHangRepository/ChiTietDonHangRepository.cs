﻿using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e_mobile_shop.Core.Repository
{
    public class ChiTietDonHangRepository : BaseRepository<ChiTietDonHang>, IChiTietDonHangRepository
    {
        public ChiTietDonHangRepository(ApplicationDbContext context):base(context)
        {

        }

        public List<ChiTietDonHang> GetAllByIdDonHang(string id)
        {
            return DbContext.ChiTietDonHang.Where(x => x.MaDh == id).ToList();
        }
    }
}
