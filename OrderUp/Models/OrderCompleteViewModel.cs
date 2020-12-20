using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Models
{
    public class OrderCompleteViewModel
    {
        [Required(ErrorMessage = "Nenurodytas pristatymo būdas")]
        public int? PristatymoBudas { get; set; }
        [Required(ErrorMessage = "Nenurodytas adresas")]
        public string Adresas { get; set; }

        [Required(ErrorMessage = "Nenurodytas telefono numeris")]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Įvesti galima tik skaičius")]
        public int Telefonas { get; set; }

        [Required(ErrorMessage = "Nenurodyta vardas ir parvardė")]
        public string VardasPavarde { get; set; }

        public List<Pica> picos { get; set; }
        public List<ShoppingCart> shoppingCart { get; set; }

        public List<PristatymoBudas> pristatymoBudas { get; set; }
    }
}
