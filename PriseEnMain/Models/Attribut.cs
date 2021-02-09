using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.Models
{
    public class Attribut
    {
<<<<<<< HEAD
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
=======
        public int Id { get; set; } 
        public string Name { get; set; }
        public string TypeAttribut { get; set; }
        public TypeInstrument TypeInstrument { get; set; }
        public string Value { get; set; }
>>>>>>> e3accd7050a85c28ae57251593eeaa2ce74cd1d4
    }
}
