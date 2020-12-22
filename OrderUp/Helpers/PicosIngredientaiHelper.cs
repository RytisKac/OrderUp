using Microsoft.AspNetCore.Mvc.Rendering;
using OrderUp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Helpers
{
    public static class PicosIngredientaiHelper
    {
        public static int? IngredientuKiekis(this IHtmlHelper htmlHelper, List<PicosIngredientai> ingredient)
        {
            int? count = 0;
            foreach (PicosIngredientai item in ingredient)
            {
                count = count + item.Kiekis;
            }
            return count;
        }

        public static double? PizzaPrice(this IHtmlHelper htmlHelper, List<PicosIngredientai> ingredient)
        {
            double? price = 0;
            foreach (PicosIngredientai item in ingredient)
            {
                price = price + (item.FkIngredientai.Kaina * item.Kiekis);
            }
            double pricee = price.Value;
            return Math.Round(pricee, 2);
        }
    }
}
