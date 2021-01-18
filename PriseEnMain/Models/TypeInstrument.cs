using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.Models
{
    public class TypeInstrument
    {
        public int Id { get; set; }
        public string Name { get; set; }

        List<InstrumentSous_jacent> intrumentSousjacent = new List<InstrumentSous_jacent>();
    }
}
