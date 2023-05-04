using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class POAdvancePayment : AuditableEntity
    {
        public long ID { get; set; }
        public long POID { get; set; }
        public string PoNumber { get; set; }
        public decimal? Deduction { get; set; }
        public long VoucherID { get; set; }
        public int SupplierID { get; set; }
        public int? StoreID { get; set; }
        public virtual Voucher Voucher { get; set; }


    }
}
