using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koszyk.Models
{
    public class KoszykViewModel
    {
        public List<PozycjaKoszyka> zawartoscKoszyka { get; set; }
        public decimal wartoscCalkowita { get; set; }
    }
}
