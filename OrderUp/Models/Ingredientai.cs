using System;
using System.Collections.Generic;

namespace OrderUp.Models
{
    public partial class Ingredientai
    {
        public Ingredientai()
        {
            PicosIngredientai = new HashSet<PicosIngredientai>();
        }

        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public double? Kaina { get; set; }
        public double? Matas { get; set; }
        public int? Tipas { get; set; }

        public string Nuotrauka { get; set; }

        public virtual IngredientoTipas TipasNavigation { get; set; }
        public virtual ICollection<PicosIngredientai> PicosIngredientai { get; set; }
    }
}
