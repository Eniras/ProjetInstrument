using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.Models
{
    public class TypeInstrumentTypeAttribut
    {
        public int TypeInstrumentId { get; set; }
        public TypeInstrument TypeInstrument { get; set; }

        public int TypeAttributId { get; set; }
        public TypeAttribut TypeAttribut { get; set; }
    }
}
