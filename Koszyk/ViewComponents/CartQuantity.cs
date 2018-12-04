using Koszyk.Controllers;
using Koszyk.Helpers;
using Koszyk.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koszyk.ViewComponents
{
    public class CartQuantity : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var koszyk = SessionHelper.GetObjectFromJson<List<PozycjaKoszyka>>(HttpContext.Session, Consts.KoszykSessionKey);
            int ilosc = 0;
            if(koszyk != null)
            {
                foreach (var element in koszyk)
                {
                    ilosc += element.ilosc;
                }
            }
            var vm = new CartQuantityViewModel()
            {
                quantity = ilosc
            };
            return View(vm);
        }
    }
}
