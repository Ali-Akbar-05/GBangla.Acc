using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class CBMAdvancePayment : AuditableEntity
    {
        public long ID { get; set; }
        public long VoucherID { get; set; }
        public long VoucherDetailsID { get; set; }
        public int AccountID { get; set; }
        public int VIndex { get; set; }


    }
}
