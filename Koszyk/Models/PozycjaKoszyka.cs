using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koszyk.Models
{
    public class PozycjaKoszyka
    {
        public Produkt produkt { get; set; }
        public int ilosc { get; set; }
        public decimal wartosc { get; set; }
    }
}
