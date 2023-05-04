using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMAdvancePaymentRFP_Relate.Queries.RequestResponseModel
{
    public class CBMAdvancePaymentRFP_RelateDTM
    {
        public long ID { get; set; }
        public long AdvancePaymentID { get; set; }
        public long InvoiceID { get; set; }
        public long VoucherID { get; set; }
        public long RFPID { get; set; }
        public decimal AmountDeducted { get; set; }
    }
}
