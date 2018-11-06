using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Koszyk.Concrete;
using Koszyk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Koszyk.Controllers
{
    public class ProduktController : Controller
    {
        private KoszykContext db;

        public ProduktController(KoszykContext context)
        {
            db = context;
        }

        public async Task<IActionResult> dodajProdukt(int? id)
        {
            Produkt produkt;
            if (id.HasValue)
            {
                ViewBag.EditMode = true;
                produkt = await db.produkty.FindAsync(id);
            }
            else
            {
                ViewBag.EditMode = false;
                produkt = new Produkt();
            }
            return View(produkt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> dodajProdukt(Produkt produkt)
        {
            if (produkt.id > 0)
            {
                if (ModelState.IsValid)
                {
                    db.produkty.Update(produkt);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(produkty));
                }
                else
                {
                    return View(produkt);
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.produkty.Add(produkt);
                    await db.SaveChangesAsync();
                    return RedirectToAction(nameof(produkty));
                }
                else
                {
                    return View(produkt);
                }
            }
        }

        public IActionResult zarzadzanie()
        {
            return View();
        }

        public async Task<IActionResult> zarzadzajProduktami()
        {
            return View(await db.produkty.ToListAsync());
        }

        public async Task<IActionResult> produkty()
        {
            return View(await db.produkty.ToListAsync());
        }

        public async Task<IActionResult> szczegoly(int id)
        {
            return View(await db.produkty.FindAsync(id));
        }

        public async Task<IActionResult> usun(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            db.produkty.Remove(await db.produkty.FindAsync(id));
            await db.SaveChangesAsync();
            return RedirectToAction(nameof(zarzadzajProduktami));
        }
    }
}