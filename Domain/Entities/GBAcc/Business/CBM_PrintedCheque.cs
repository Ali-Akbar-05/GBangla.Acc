using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class CBM_PrintedCheque : AuditableEntity
    {
        public long ChqID { get; set; }
        public string ReceivingPerson { get; set; }
        public string Identification { get; set; }
        public int? Status { get; set; }
        public DateTime? TransactionDate { get; set; }
    }
}
