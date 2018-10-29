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

        public IActionResult dodajProdukt()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> dodajProdukt(Produkt produkt)
        {
            if (ModelState.IsValid)
            {
                db.Add(produkt);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(produkty));
            }
            return View(produkt);
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

        public async Task<IActionResult> edytuj(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var produkt = await db.produkty.FindAsync(id);
            if (produkt == null)
            {
                return NotFound();
            }
            return View(produkt);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> edytuj(int id, Produkt produkt)
        {
            if (id != produkt.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(produkt);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProduktExists(produkt.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(zarzadzajProduktami));
            }
            return View(produkt);
        }

        private bool ProduktExists(int id)
        {
            return  db.produkty.Any(e => e.id == id);
        }
    }
}