using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.POAdvancePayments.Commands.DataTransferModel
{
    public class POAdvancePaymentDTM
    {
        public long ID { get; set; }
        public long POID { get; set; }
        public string PoNumber { get; set; }
        public decimal? Deduction { get; set; }
        public long VoucherID { get; set; }
        public int SupplierID { get; set; }
        public int? StoreID { get; set; }
    }
}
