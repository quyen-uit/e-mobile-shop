using Microsoft.AspNetCore.SignalR;
using Microsoft.Data.SqlClient;
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
        public DonHangRepository(IConfiguration configuration,
                                    IHubContext<SignalServer> context)
        {
            connectionString = "Data Source=DESKTOP-R3PM237;Initial Catalog=eShopDb;Integrated Security=True";
            _context = context;
        }
        public List<DonHang> GetAll()
        {
            var DonHangs = new List<DonHang>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                string commandText = "select MaDH from dbo.DonHang";

                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDependency dependency = new SqlDependency(cmd);

                dependency.OnChange += new OnChangeEventHandler(dbChangeNotification);

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var DonHang = new DonHang
                    {
                        MaDh = reader["MaDH"].ToString()
                        
                    };

                    DonHangs.Add(DonHang);
                }
                newID = DonHangs.LastOrDefault().MaDh;
            }
            
            return DonHangs;
        }

        private void dbChangeNotification(object sender, SqlNotificationEventArgs e)
        {
            var DonHangs = new List<DonHang>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlDependency.Start(connectionString);

                string commandText = "select MaDH from dbo.DonHang";

                SqlCommand cmd = new SqlCommand(commandText, conn);

                SqlDependency dependency = new SqlDependency(cmd);

             

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var DonHang = new DonHang
                    {
                        MaDh = reader["MaDH"].ToString()

                    };

                    DonHangs.Add(DonHang);
                }
                newID = DonHangs.LastOrDefault().MaDh;
            }
            _context.Clients.All.SendAsync("refreshDonHangs",newID);
        }
    }
}
