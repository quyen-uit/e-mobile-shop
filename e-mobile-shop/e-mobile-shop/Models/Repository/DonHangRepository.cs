using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models.Repository
{
    public class DonHangRepository : IDonHangRepository
    {
        private readonly IHubContext<SignalServer> _context;
        string connectionString = "";
        string newID = "";
        static bool a = true;
        static int flag = 0;
        public DonHangRepository(IConfiguration configuration,
                                    IHubContext<SignalServer> context)
        {
            connectionString = "Data Source=UAENA;Initial Catalog=eShopDb;Integrated Security=True";
            _context = context;
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
                flag = 0;
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
            if (flag == 1)
                return;
            var DonHangs = new List<DonHang>();
            int num1,num2;
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
                _context.Clients.All.SendAsync("updateDonHangs", num1.ToString(),num2.ToString());
            }
            else
            {
                if (e.Type == SqlNotificationType.Change && e.Info == SqlNotificationInfo.Insert && a)
                {
                    _context.Clients.All.SendAsync("refreshDonHangs", newID, num1.ToString(),num2.ToString());
                    a = false;
                }
                else a = true;
            }
            flag = 1;
        }
    }
}
