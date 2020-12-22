using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace OrderUp.Models
{
    public partial class Klientas : IdentityUser
    {
        public Klientas()
        {
            Uzsakymas = new HashSet<Uzsakymas>();
        }

        public string Adresas { get; set; }

        public virtual ICollection<Uzsakymas> Uzsakymas { get; set; }
        public virtual ICollection<ShoppingCart> ShoppingCart { get; set; }
        public virtual ICollection<Pica> Pica { get; set; }
    }
}
