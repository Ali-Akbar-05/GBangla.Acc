using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class CBMInstrumentType : AuditableEntity
    {
        public int InstrumentTypeID { get; set; }
        public string InstrumentType { get; set; }
        public string InstrumentShort { get; set; }
        public int Serial { get; set; }

    }
}
