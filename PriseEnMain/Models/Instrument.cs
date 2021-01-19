using System.Collections.Generic;

namespace PriseEnMain.Models
{
    public class Instrument
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int TypeInstrumentId { get; set; }
        public TypeInstrument TypeInstrument { get; set; }

        public int? InstrumentSousJacentId { get; set; }
        public Instrument InstrumentSousJacent { get; set; }

        public int? EmetteurId { get; set; }
        public Emetteur Emetteur { get; set; }

        public int? ContratId { get; set; }
        public Contrat Contrat { get; set; }

        public ICollection<Attribut> Attributs { get; set; } = new HashSet<Attribut>();
    }
}
