using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.COATransactions.Queries.RequestResponseModel
{
    public class LedgerBalanceResponseModel
    {
        public int AccountID { get; set; }
        public string LedgerName { get; set; }
        public decimal LedgerBalance { get; set; }
 
        public decimal OpeningBalance { get; set; }
        public decimal TotalBalance { get { return LedgerBalance + OpeningBalance; } }
 
    }
}
