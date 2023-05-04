using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class VoucherDetail : AuditableEntity
    {
        
      
        public long VDetailsID { get; set; }
        public long VoucherID { get; set; }
        public int AccountID { get; set; }
        public decimal Amount { get; set; }
        public int? LocationID { get; set; }
        public int? Costcenter { get; set; }
        public int? Activity { get; set; }
        public int? VIndex { get; set; }
        public int Status { get; set; }
        public int? EntryType { get; set; }

        public Voucher Voucher { get; set; }
    }
}
