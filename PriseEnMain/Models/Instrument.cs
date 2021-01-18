using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.Models
{
    public class Instrument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TypeInstrument typeInstrument { get; set; }
        public Emetteur emetteur { get; set; }
        public Contrat contrat { get; set; }
        public Attribut attribut { get; set; }
        

    }
}
