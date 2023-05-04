using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class LedgerBalanceIncomeTaxPercent : AuditableEntity
    {
        public int ID { get; set; }
        public decimal BalanceAmountFrom { get; set; }
        public decimal BalanceAmountTo { get; set; }
        public decimal IncomeTaxPer { get; set; }
        public int? CompanyID { get; set; }
    }
}
