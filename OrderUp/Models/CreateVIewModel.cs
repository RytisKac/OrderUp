using OrderUp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Models
{
    public class CreateViewModel
    {
        public PaginatedList<Ingredientai> ingredientai { get; set; }
        public List<IngredientoTipas> ingredientoTipai { get; set; }
        public List<ShoppingCart> shoppingCart { get; set; }
        public List<Pica> picos { get; set; }
    }
}
