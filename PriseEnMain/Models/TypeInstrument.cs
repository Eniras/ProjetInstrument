﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PriseEnMain.Models
{
    public class TypeInstrument
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<TypeInstrumentTypeAttribut> TypeInstrumentTypeAttributs { get; private set; } = new HashSet<TypeInstrumentTypeAttribut>();
    }
}
