using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class CurrencyDetail : AuditableEntity
    {
        public int ID { get; set; }
        public decimal RateInBDT { get; set; }
        public DateTime Date { get; set; }
        public int CurrencyID { get; set; }

    }
}
