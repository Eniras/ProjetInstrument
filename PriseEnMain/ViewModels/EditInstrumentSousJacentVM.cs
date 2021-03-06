﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace PriseEnMain.ViewModels
{
    public class EditInstrumentSousJacentVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int TypeInstrumentId { get; set; }
        public int? EmetteurId { get; set; }
        public int? ContratId { get; set; }
        public int? InstrumentSousJacentId { get; set; }

        public SelectList TypesInstruments { get; set; }
        public SelectList Emetteurs { get; set; }
        public SelectList Contrats { get; set; }
        public SelectList InstrumentsSousJacents { get; set; }

    }
}
