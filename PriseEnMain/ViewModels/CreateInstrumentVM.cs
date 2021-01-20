using Microsoft.AspNetCore.Mvc.Rendering;
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
        public string TypeInstrumentName { get; set; }
        public int? EmetteurId { get; set; }
        public int? ContratId { get; set; }
        public int? InstrumentSousJacentId { get; set; }

        public SelectList TypesInstruments { get; set; }
        public SelectList Emetteurs { get; set; }
        public SelectList Contrats { get; set; }
        public SelectList InstrumentsSousJacents { get; set; }
    }
}
