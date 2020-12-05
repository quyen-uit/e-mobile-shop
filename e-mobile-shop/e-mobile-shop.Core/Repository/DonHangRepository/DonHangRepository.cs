using e_mobile_shop.Core.BaseRepository;
using e_mobile_shop.Core.Models;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace e_mobile_shop.Core.Repository
{
    public class DonHangRepository :BaseRepository<DonHang>, IDonHangRepository
    {
        private readonly IHubContext<SignalServer> _context;
        string connectionString = "";
        string newID = "";
        static bool a = true;
        public DonHangRepository(IConfiguration configuration,
                                    IHubContext<SignalServer> context, ApplicationDbContext dbContext):base(dbContext)
        {
            connectionString = "";
            _context = context;
            
        }
        public List<DonHang> GetAllToNotify()
        {
            //var DonHangs = new List<DonHang>();
            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();

            //    SqlDependency.Start(connectionString);

            //    string commandText = "select MaDH, TinhTrangDH from dbo.DonHang";

            //    SqlCommand cmd = new SqlCommand(commandText, conn);

            //    SqlDependency dependency = new SqlDependency(cmd);
            //    a = true;
            //    dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

            //    var reader = cmd.ExecuteReader();

            //    while (reader.Read())
            //    {
            //        var DonHang = new DonHang
            //        {
            //            MaDh = reader["MaDH"].ToString(),

            //        };

            //        DonHangs.Add(DonHang);
            //    }

            //}

            //return DonHangs;
            return new List<DonHang>();
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
                return DbContext.DonHang.ToList();
        }

        public List<DonHang> GetDonHangsByIdStatus(string id, string status)
        {
            throw new NotImplementedException();
        }

        public DonHang GetDonHangById(string id)
        {    
               return DbContext.DonHang.Where(x => x.MaDh == id).ToList().FirstOrDefault();
        }

        public List<ChiTietDonHang> GetChiTietDonHangsByMaDH(string madh)
        {
                return DbContext.ChiTietDonHang.Where(x => x.MaDh == madh).ToList();
        }

        public TrangThaiDonHang GetTTDH(string id)
        {
                return DbContext.TrangThaiDonHang.Find(Int32.Parse(id));
        }

        //public void Update(DonHang dh)
        //{
        //    using (var context = new ClientDbContext())
        //    {
        //        context.DonHang.Update(dh);
        //        context.SaveChanges();
        //    }
        //}

        public List<TrangThaiDonHang> GetTrangThaiDonHangs()
        {
                return DbContext.TrangThaiDonHang.ToList();
        }

        public IQueryable<DonHang> GetDonHangsByMaKh(string maKh, string type)
        {

            if (!String.IsNullOrEmpty(type))
            {
                var result = from s in DbContext.DonHang where s.MaKh == maKh && s.TinhTrangDh == int.Parse(type) select s;

                return result;
            }
            else
            {
                var result = from s in DbContext.DonHang where s.MaKh == maKh select s;
                return result;
            }
        }

        public int SoDonHang()
        {

                return DbContext.DonHang.Count();
            
        }

        public void AddDonHang(DonHang donHang)
        {
            DbContext.DonHang.Add(donHang);
        }

        public string GetTrangThaiDonHang(string id)
        {

                return DbContext.TrangThaiDonHang.Find(int.Parse(id)).TenTrangThai;

        }

        public void AddChiTietDonHang(ChiTietDonHang chiTietDonHang)
        {
                DbContext.ChiTietDonHang.Add(chiTietDonHang);
             
        }

        public List<ChiTietDonHang> GetChiTiets()
        {
                return DbContext.ChiTietDonHang.ToList();
        }
    }
}
