using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrderUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Helpers
{
    public static class ShoppingCartCount
    {
        public static int? CartCount(this IHtmlHelper htmlHelper, List<ShoppingCart> cart)
        {
            int? count = 0;
            foreach(ShoppingCart item in cart)
            {
                count = count + item.Kiekis;
            }
            return count;
        }

        public static double? CartPrice(this IHtmlHelper htmlHelper, List<ShoppingCart> cart)
        {
            double? price = 0;
            foreach(ShoppingCart item in cart)
            {
                price = price + (item.FkPica.Kaina * item.Kiekis);
            }
            double pricee = price.Value;
            return Math.Round(pricee, 2);
        }
    }
}
