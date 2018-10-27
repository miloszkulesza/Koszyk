using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koszyk.Concrete;
using Koszyk.Helpers;
using Koszyk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Koszyk.Controllers
{
    public class KoszykController : Controller
    {
        private KoszykContext db;

        public KoszykController(KoszykContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            var koszyk = PobierzKoszyk();
            var cenaCalkowita = WartoscKoszyka();
            KoszykViewModel koszykVM = new KoszykViewModel()
            {
                zawartoscKoszyka = koszyk,
                wartoscCalkowita = cenaCalkowita
            };
            return View(koszykVM);
        }

        public IActionResult DodajDoKoszyka(int id)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.produkt.id == id);

            if (pozycjaKoszyka != null)
            {
                if(pozycjaKoszyka.ilosc == pozycjaKoszyka.produkt.ilosc)
                {
                    return RedirectToAction("bladIlosc");
                }
                pozycjaKoszyka.ilosc++;
                pozycjaKoszyka.wartosc += pozycjaKoszyka.produkt.cenaBrutto();
            }
            else
            {
                var produktDoDodania = db.produkty.Where(k => k.id == id).SingleOrDefault();

                if (produktDoDodania != null)
                {
                    var nowaPozycjaKoszyka = new PozycjaKoszyka()
                    {
                        produkt = produktDoDodania,
                        ilosc = 1,
                        wartosc = produktDoDodania.cenaBrutto()
                    };
                    koszyk.Add(nowaPozycjaKoszyka);
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.KoszykSessionKey, koszyk);
            return RedirectToAction(nameof(Index));
        }

        public List<PozycjaKoszyka> PobierzKoszyk()
        {
            List<PozycjaKoszyka> koszyk;

            if (SessionHelper.GetObjectFromJson<List<PozycjaKoszyka>>(HttpContext.Session, Consts.KoszykSessionKey) == null)
            {
                koszyk = new List<PozycjaKoszyka>();
            }
            else
            {
                koszyk = SessionHelper.GetObjectFromJson<List<PozycjaKoszyka>>(HttpContext.Session, Consts.KoszykSessionKey) as List<PozycjaKoszyka>;
            }

            return koszyk;
        }

        public IActionResult UsunZKoszyka(int id)
        {
            var koszyk = PobierzKoszyk();
            var pozycjaKoszyka = koszyk.Find(k => k.produkt.id == id);
            if (pozycjaKoszyka != null)
            {
                if (pozycjaKoszyka.ilosc > 1)
                {
                    pozycjaKoszyka.ilosc--;
                    pozycjaKoszyka.wartosc -= pozycjaKoszyka.produkt.cenaBrutto();
                }
                else
                {
                    koszyk.Remove(pozycjaKoszyka);
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, Consts.KoszykSessionKey, koszyk);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult bladIlosc()
        {
            return View();
        }

        public decimal WartoscKoszyka()
        {
            var koszyk = PobierzKoszyk();
            return koszyk.Sum(k => k.wartosc);
        }

        public int IloscPozycjiKoszyka()
        {
            var koszyk = PobierzKoszyk();
            int ilosc = 0;
            foreach(var element in koszyk)
            {
                ilosc += element.ilosc;
            }
            return ilosc;
        }
    }
}