using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.Models
{
    public class Attribut
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string TypeAttribut { get; set; }
        public TypeInstrument TypeInstrument { get; set; }
        public string Value { get; set; }
    }
}
