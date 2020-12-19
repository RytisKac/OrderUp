using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderUp.Models
{
    public partial class UzsakymoPreke
    {
        public int? Kiekis { get; set; }
        [Key]
        public int Id { get; set; }
        public int FkPicaid { get; set; }
        public int FkUzsakymasid { get; set; }

        public virtual Pica FkPica { get; set; }
        public virtual Uzsakymas FkUzsakymas { get; set; }
    }
}
