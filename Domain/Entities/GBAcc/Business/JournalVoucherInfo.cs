using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class JournalVoucherInfo : AuditableEntity
    {
        public int ID { get; set; }
        public long VoucherID { get; set; }
        public int ItemID { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Rate { get; set; }
        public int? Vindex { get; set; }

        public virtual Voucher Voucher { get; set; }
    }
}
