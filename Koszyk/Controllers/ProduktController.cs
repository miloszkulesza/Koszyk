using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Koszyk.Concrete;
using Koszyk.Models;
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

        public IActionResult zarzadzanie()
        {
            return View();
        }

        public IActionResult zarzadzajProduktami()
        {
            return View();
        }

        public async Task<IActionResult> produkty()
        {
            return View(await db.produkty.ToListAsync());
        }
    }
}