using e_mobile_shop.Core.Models;
using e_mobile_shop.Core.Repository;
using e_mobile_shop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_mobile_shop.ConsoleTest
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var serviceProvider = new ServiceCollection().AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer("Server=tcp:e-shop.database.windows.net,1433;Initial Catalog=eShopDb;Persist Security Info=False;User ID=admin2;Password=VACha2JKhnsMhDr;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"), ServiceLifetime.Transient)
                .AddScoped<ISanPhamRepository, SanPhamRepository>().BuildServiceProvider();

            var a = serviceProvider.GetService<ISanPhamRepository>();
            foreach (var item in a.GetAll())
            {
                Console.WriteLine(item.TenSp);
            }
        }
    }
}
