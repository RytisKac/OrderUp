using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderUp.Models
{
    public class PremadeViewModel
    {
        public List<PicosTipas> picosTipai { get; set; }
        public List<Pica> picos { get; set; }
        public List<ShoppingCart> shoppingCart { get; set; }
    }
}
