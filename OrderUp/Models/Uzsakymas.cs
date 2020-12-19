using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderUp.Models
{
    public partial class Uzsakymas
    {
        public Uzsakymas()
        {
            UzsakymoPreke = new HashSet<UzsakymoPreke>();
        }
            
        [Key]
        public int Id { get; set; }
            
        public string VardasPavarde { get; set; }

        public DateTime? UzsakymoData { get; set; }
        public double? Kaina { get; set; }
        public int? PrekiuKiekis { get; set; }

        [Required]
        public int? PristatymoBudas { get; set; }
        public string FkKlientasid { get; set; }

        [Required]
        public string Adresas { get; set; }

        [Required]
        public int Telefonas { get; set; }

        public virtual Klientas FkKlientas { get; set; }
        public virtual PristatymoBudas PristatymoBudasNavigation { get; set; }
        public virtual ICollection<UzsakymoPreke> UzsakymoPreke { get; set; }
    }
}
