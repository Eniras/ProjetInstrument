﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.ViewModels
{
    public class CreateInstrumentVM
    {
        [Required]
        public string Name { get; set; }

        public int TypeInstrumentId { get; set; }
        public string InstrumentName { get; set; }
        public int? EmetteurId { get; set; }
        public int? ContratId { get; set; }
        public int? InstrumentSousJacentId { get; set; }

        public SelectList TypesInstruments { get; set; }
        public IEnumerable<EmetteurVM> Emetteurs { get; set; }
        public IEnumerable<ContratsVM> Contrats { get; set; }
        public IEnumerable<InstrumentsSousJacentsVM> InstrumentsSousJacents { get; set; }
    }

    public class EmetteurVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class InstrumentsSousJacentsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ContratsVM
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}