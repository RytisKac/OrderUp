using System;
using System.Collections.Generic;

namespace OrderUp.Models
{
    public partial class Pica
    {
        public Pica()
        {
            PicosIngredientai = new HashSet<PicosIngredientai>();
            UzsakymoPreke = new HashSet<UzsakymoPreke>();
        }

        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public double? Kaina { get; set; }
        public string Aprasymas { get; set; }
        public int? Padas { get; set; }
        public int? Tipas { get; set; }
        public string Nuotrauka { get; set; }
        public string Klientas { get; set; }
        public virtual Padas PadasNavigation { get; set; }
        public virtual PicosTipas TipasNavigation { get; set; }
        public virtual Klientas KlientasNavigation { get; set; }
        public virtual ICollection<PicosIngredientai> PicosIngredientai { get; set; }
        public virtual ICollection<UzsakymoPreke> UzsakymoPreke { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
    }
}
