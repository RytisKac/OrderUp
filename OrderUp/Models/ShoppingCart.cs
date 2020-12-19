using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Models
{
    public partial class ShoppingCart
    {
        [Key]
        public int Id { get; set; }
        public int? Kiekis { get; set; }
        public int FkPicaid { get; set; }
        public string FkKlientasid { get; set; }

        public virtual Klientas FkKlientas { get; set; }
        public virtual Pica FkPica { get; set; }
    }
}
