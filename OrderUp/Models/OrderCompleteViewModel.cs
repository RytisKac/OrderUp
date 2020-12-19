using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Models
{
    public class OrderCompleteViewModel
    {
        [Required]
        public int? PristatymoBudas { get; set; }
        [Required]
        public string Adresas { get; set; }

        [Required]
        public int Telefonas { get; set; }

        [Required]
        public string VardasPavarde { get; set; }

        public List<Pica> picos { get; set; }
        public List<ShoppingCart> shoppingCart { get; set; }

        public List<PristatymoBudas> pristatymoBudas { get; set; }
    }
}
