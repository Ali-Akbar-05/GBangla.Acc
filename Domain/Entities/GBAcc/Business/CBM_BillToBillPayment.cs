using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class CBM_BillToBillPayment : AuditableEntity
    {
        public long ID { get; set; }
        public long? VoucherID { get; set; }
        public long? AdjustmentVoucherID { get; set; }
        public long? InvoiceID { get; set; }
        public decimal AdjustedAmount { get; set; }
        public decimal PaidAmount { get; set; }

        public Voucher Voucher { get; set; }
    }
}
