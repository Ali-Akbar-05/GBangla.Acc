using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class CBMAdvancePaymentRFP_Relate : AuditableEntity
    {
        public int ID { get; set; }
        public long AdvancePaymentID { get; set; }
        public long InvoiceID { get; set; }
        public long RFPID { get; set; }
        public decimal AmountDeducted { get; set; }
    }
}
