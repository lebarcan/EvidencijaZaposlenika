using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencijaZaposlenika.Models
{
    public class BazaKontekst : DbContext
    {
        public BazaKontekst(DbContextOptions<BazaKontekst> options) : base(options)
        {

        }
        public DbSet<EvidencijaZaposlenika.Models.Zaposlenik> Zaposlenici { get; set; }
    }
}
