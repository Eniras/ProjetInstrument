using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.Models
{
    public class Attribut
    {
        public int Id { get; set; }
        public int TypeAttributId { get; set; }
        public TypeAttribut TypeAttribut { get; set; }

        public int ValueInstrumentId { get; set; }
        public Instrument Instrument { get; set; } 

        public int? ValueContratId { get; set; }
        public Contrat ValueContrat { get; set; }

        public int? ValueEmetteurId { get; set; }
        public Emetteur ValueEmetteur { get; set; }

        public string ValueOther { get; set; }
    }
}
