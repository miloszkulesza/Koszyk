using Koszyk.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Koszyk.Concrete
{
    public class KoszykContext : DbContext
    {
        public KoszykContext(DbContextOptions<KoszykContext> options) : base(options) { }
        public DbSet<Produkt> produkty { get; set; }
    }
}
