using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.ViewModels
{
    public class CreateAttributViewModel
    {
        public int AttributeTypeId { get; set; }

        public string AttributeTypeName { get; set; }

        public string AttributeTypeValueType { get; set; }

        [Display(Name = "Instrument")]
        public int? ValueInstrumentId { get; set; }

        [Display(Name = "Contrat")]
        public int? ValueContractId { get; set; }

        [Display(Name = "Emetteur")]
        public int? ValueEmetteurId { get; set; }

        [Display(Name = "Valeur")]
        public string Value { get; set; }
    }
}
