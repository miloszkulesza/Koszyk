using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Koszyk.Models
{
    public class Produkt
    {
        private const decimal vat = 0.23M;
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Podaj nazwe produktu")]
        public string nazwa { get; set; }
        [Required(ErrorMessage = "Podaj cenę produktu")]
        [Range(0, 99999.99, ErrorMessage = "Cena musi mieścić sie w zakresie 0 - 99999.99")]
        [MinLength(1, ErrorMessage = "Podana wartość jest nieprawidłowa")]
        public decimal cenaNetto { get; set; }
        public decimal cenaBrutto()
        { 
            return cenaNetto * (1 + vat); 
        }
        [Required(ErrorMessage = "Podaj nazwę producenta produktu")]
        public string nazwaProducenta { get; set; }
        [Required(ErrorMessage = "Podaj adres producenta produktu")]
        public string adresProducenta { get; set; }
        [Required(ErrorMessage = "Podaj ilość sztuk")]
        [RegularExpression(@"^\d$", ErrorMessage = "Podaj właściwą ilość sztuk")]
        public int ilosc { get; set; }
    }
}
