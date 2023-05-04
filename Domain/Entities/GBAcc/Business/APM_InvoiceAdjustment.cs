using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
   public class APM_InvoiceAdjustment : AuditableEntity
    {
    public long ID { get; set; }
    public long? VoucherID { get; set; }
    public long? InvoiceID { get; set; }
    public decimal? AdjustedAmount { get; set; }
    }
}
