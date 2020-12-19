using System;
using System.Collections.Generic;

namespace OrderUp.Models
{
    public partial class PicosTipas
    {
        public PicosTipas()
        {
            Pica = new HashSet<Pica>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Pica> Pica { get; set; }
    }
}
