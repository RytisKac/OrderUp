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
        public int Id { get; set; }

        [Required]
        public int ingId { get; set; }

        [Required(ErrorMessage = "Įveskite norimą kiekį")]
        [Range(1, 10)]
        public int Kiekis { get; set; }

        public List<Ingredientai> ingredientai { get; set; }
        public List<IngredientoTipas> ingredientoTipai { get; set; }
        public List<PicosIngredientai> picosIngredientai { get; set; }
        public List<Pica> picos { get; set; }
    }
}
