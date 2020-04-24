using e_mobile_shop.Models;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string inp;
            inp = Console.ReadLine();
            foreach (var item in DataAccess.ReadSanPham(inp))
            {
                Console.WriteLine(item.AnhDaiDien);
            }
        }
    }
}
