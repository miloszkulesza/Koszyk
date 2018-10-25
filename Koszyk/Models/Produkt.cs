using Microsoft.AspNetCore.Http;
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
        public decimal cenaNetto { get; set; }
        public decimal cenaBrutto()
        {
            decimal temp = cenaNetto * (1 + vat);
            return Decimal.Round(temp, 2);
        }
        [Required(ErrorMessage = "Podaj nazwę producenta produktu")]
        public string nazwaProducenta { get; set; }
        [Required(ErrorMessage = "Podaj adres producenta produktu")]
        public string adresProducenta { get; set; }
        [Required(ErrorMessage = "Podaj ilość sztuk")]
        [RegularExpression(@"^\d$", ErrorMessage = "Podaj właściwą ilość sztuk")]
        public int ilosc { get; set; }
        [Required]
        public string urlZdjecia { get; set; }
    }
}
