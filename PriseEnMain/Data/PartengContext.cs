using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PriseEnMain.Models;

namespace PriseEnMain.Data
{
    public class PartengContext : DbContext
    {
        public PartengContext(DbContextOptions<PartengContext> options)
       : base(options)
        {
        }

        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<TypeInstrument> TypeInstruments { get; set; }
        public DbSet<InstrumentSous_jacent> InstrumentSous_jacents { get; set; }
        public DbSet<Contrat> Contrats { get; set; }
        public DbSet<Emetteur> Emetteurs { get; set; }
        public DbSet<Attribut> Attributs { get; set; }
    }
}
