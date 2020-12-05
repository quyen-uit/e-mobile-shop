using e_mobile_shop.Areas.Identity.Data;
using e_mobile_shop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(e_mobile_shop.Areas.Identity.IdentityHostingStartup))]
namespace e_mobile_shop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) =>
            {
                services.AddDbContext<eShopDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("eShopDbContextConnection")));

                services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<eShopDbContext>();
            });
        }
    }
}