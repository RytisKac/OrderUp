using System;
using System.Collections.Generic;

namespace OrderUp.Models
{
    public partial class IngredientoTipas
    {
        public IngredientoTipas()
        {
            Ingredientai = new HashSet<Ingredientai>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ingredientai> Ingredientai { get; set; }
    }
}
