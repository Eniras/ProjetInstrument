using System.Collections.Generic;

namespace PriseEnMain.Models
{
    public class Instrument
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeInstrumentId { get; set; }
        public TypeInstrument TypeInstrument { get; set; }

        public ICollection<Attribut> Attributs { get; set; } = new HashSet<Attribut>();
    }
}
