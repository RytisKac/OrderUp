using System;
using System.Collections.Generic;

namespace OrderUp.Models
{
    public partial class PristatymoBudas
    {
        public PristatymoBudas()
        {
            Uzsakymas = new HashSet<Uzsakymas>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Uzsakymas> Uzsakymas { get; set; }
    }
}
