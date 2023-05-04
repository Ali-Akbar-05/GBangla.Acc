using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBM_BillToBillPayments.Commands.DataTransferModel
{
    public class CBM_BillToBillPaymentDTM
    {
        public long ID { get; set; }
        public long? VoucherID { get; set; }
        public long? AdjustmentVoucherID { get; set; }
        public long? InvoiceID { get; set; }
        public decimal AdjustedAmount { get; set; }
        public decimal PaidAmount { get; set; }
    }
}
