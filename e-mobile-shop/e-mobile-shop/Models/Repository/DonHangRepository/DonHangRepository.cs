﻿using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace e_mobile_shop.Models.Repository
{
    public class DonHangRepository : IDonHangRepository
    {
        private readonly IHubContext<SignalServer> _context;
        string connectionString = "";
        string newID = "";
        static bool a = true;
        private readonly ClientDbContext dbContext;
        public DonHangRepository(IConfiguration configuration,
                                    IHubContext<SignalServer> context, ClientDbContext db)
        {
            connectionString = "";
            _context = context;
            dbContext = db;
        }
        public List<DonHang> GetAll()
        {
            var DonHangs = new List<DonHang>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                string commandText = "select MaDH, TinhTrangDH from dbo.DonHang";

                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDependency dependency = new SqlDependency(cmd);
                a = true;
                dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var DonHang = new DonHang
                    {
                        MaDh = reader["MaDH"].ToString(),

                    };

                    DonHangs.Add(DonHang);
                }

            }

            return DonHangs;
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            var DonHangs = new List<DonHang>();
            int num1, num2;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                string commandText = "select MaDH, TinhTrangDH from dbo.DonHang";

                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDependency dependency = new SqlDependency(cmd);



                var reader = cmd.ExecuteReader();
                num1 = num2 = 0;
                while (reader.Read())
                {
                    var DonHang = new DonHang
                    {
                        MaDh = reader["MaDH"].ToString(),


                    };
                    if (reader["TinhTrangDH"].ToString() == "1")
                        num1++;
                    else if (reader["TinhTrangDH"].ToString() == "2")
                        num2++;
                    DonHangs.Add(DonHang);
                }
                newID = DonHangs.LastOrDefault().MaDh;

            };

            if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Update)
            {
                _context.Clients.All.SendAsync("updateDonHangs", num1.ToString(), num2.ToString());
            }
            else
            {
                if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Insert && a)
                {
                    _context.Clients.All.SendAsync("refreshDonHangs", newID, num1.ToString(), num2.ToString());
                    a = false;
                }
                else a = true;
            }
        }
        public void NotifyDonHang()
        {
            var DonHangs = new List<DonHang>();
            int num1, num2;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                string commandText = "select MaDH, TinhTrangDH from dbo.DonHang";

                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDependency dependency = new SqlDependency(cmd);



                var reader = cmd.ExecuteReader();
                num1 = num2 = 0;
                while (reader.Read())
                {
                    var DonHang = new DonHang
                    {
                        MaDh = reader["MaDH"].ToString(),


                    };
                    if (reader["TinhTrangDH"].ToString() == "1")
                        num1++;
                    else if (reader["TinhTrangDH"].ToString() == "2")
                        num2++;
                    DonHangs.Add(DonHang);
                }
                newID = DonHangs.LastOrDefault().MaDh;

            };

            _context.Clients.All.SendAsync("refreshDonHangs", newID, num1.ToString(), num2.ToString());
        }

        public List<DonHang> GetDonHangs()
        {
            using (var context = new ClientDbContext())
            {
                return context.DonHang.ToList();
            }
        }

        public List<DonHang> GetDonHangsByIdStatus(string id, string status)
        {
            throw new NotImplementedException();
        }

        public DonHang GetDonHangById(string id)
        {
            using (var context = new ClientDbContext())
            {
                return context.DonHang.Where(x => x.MaDh == id).ToList().FirstOrDefault();
            }
        }

        public List<ChiTietDonHang> GetChiTietDonHangsByMaDH(string madh)
        {
            using (var context = new ClientDbContext())
            {
                return context.ChiTietDonHang.Where(x => x.MaDh == madh).ToList();
            }
        }

        public TrangThaiDonHang GetTTDH(string id)
        {
            using (var context = new ClientDbContext())
            {
                return context.TrangThaiDonHang.Find(Int32.Parse(id));
            }
        }

        public void Update(DonHang dh)
        {
            using (var context = new ClientDbContext())
            {
                context.DonHang.Update(dh);
                context.SaveChanges();
            }
        }

        public List<TrangThaiDonHang> GetTrangThaiDonHangs()
        {
            using (var context = new ClientDbContext())
            {
                return context.TrangThaiDonHang.ToList();
            }
        }

        public IQueryable<DonHang> GetDonHangsByMaKh(string maKh, string type)
        {

            if (!String.IsNullOrEmpty(type))
            {
                var result = from s in dbContext.DonHang where s.MaKh == maKh && s.TinhTrangDh == int.Parse(type) select s;

                return result;
            }
            else
            {
                var result = from s in dbContext.DonHang where s.MaKh == maKh select s;
                return result;
            }
        }

        public int SoDonHang()
        {
            using (var context = new ClientDbContext())
            {
                return context.DonHang.Count();
            }
        }

        public void AddDonHang(DonHang donHang)
        {
            using (var context = new ClientDbContext())
            {
                context.DonHang.Add(donHang);
                context.SaveChanges();
            }
        }

        public string GetTrangThaiDonHang(string id)
        {
            using (var context = new ClientDbContext())
            {
                return context.TrangThaiDonHang.Find(int.Parse(id)).TenTrangThai;
            }
        }

        public void AddChiTietDonHang(ChiTietDonHang chiTietDonHang)
        {
            using (var context = new ClientDbContext())
            {
                context.ChiTietDonHang.Add(chiTietDonHang);
                context.SaveChanges();
            }
        }

        public List<ChiTietDonHang> GetChiTiets()
        {
            using (var context = new ClientDbContext())
            {
                return context.ChiTietDonHang.ToList();
            }
        }
    }
}
