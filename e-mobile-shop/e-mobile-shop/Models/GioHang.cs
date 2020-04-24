using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models
{
    public class GioHang
    {
        private List<ChiTietDonHang> ShoppingCart;
        public double phiVanChuyen;

        public GioHang()
        {
            ShoppingCart= new List<ChiTietDonHang>();
        }

        public void AddToCart(ChiTietDonHang ct)
        {
            ShoppingCart.Add(ct);       
        }

        public bool RemoveFromCart(int index)
        {
            try
            {
                ShoppingCart.RemoveAt(index);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public decimal? TongTien()
        {
            decimal? count =0;
            foreach (var item in ShoppingCart)
            {
                decimal? giatri = DataAccess.GetSanPham(item.MaSp).GiaGoc * item.SoLuong;
                count = count + giatri;
            }
            return count;
        }
    }
}
