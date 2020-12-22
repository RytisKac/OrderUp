using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Models
{
    public class CreatePizzaViewModel
    {
        [Required(ErrorMessage = "Picos pavadinimas privalomas")]
        public string Pavadinimas { get; set; }

        public string Aprasymas { get; set; }

        [Required(ErrorMessage = "Nenurodytas picos padas")]
        public int? padas { get; set; }

        public List<Padas> Padas { get; set; }
    }
}
