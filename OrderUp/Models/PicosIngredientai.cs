using System;
using System.Collections.Generic;

namespace OrderUp.Models
{
    public partial class PicosIngredientai
    {

        public int? Kiekis { get; set; }
        public int Id { get; set; }
        public int FkIngredientaiid { get; set; }
        public int FkPicaid { get; set; }

        public virtual Ingredientai FkIngredientai { get; set; }
        public virtual Pica Fkpica { get; set; }
    }
}
