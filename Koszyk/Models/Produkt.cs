using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koszyk.Models
{
    public class Produkt
    {
        private const double vat = 0.23;
        public string nazwa { get; set; }
        public double cenaNetto { get; set; }
        public double cenaBrutto()
        { 
            return cenaNetto * (1 + vat); 
        }
        public string nazwaProducenta { get; set; }
        public string adresProducenta { get; set; }
    }
}
