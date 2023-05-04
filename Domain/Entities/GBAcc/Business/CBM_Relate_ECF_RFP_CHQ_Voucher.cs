using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class CBM_Relate_ECF_RFP_CHQ_Voucher : AuditableEntity
    {
        public long ID { get; set; }
        public long VoucherID { get; set; }
        public long? ECFID { get; set; }
        public long? RFPID { get; set; }
        public long? LRPID { get; set; }
        public long? ChequeID { get; set; }
        public DateTime? AdjustmentDate { get; set; }
  
        public Voucher Voucher { get; set; }
    }
}
