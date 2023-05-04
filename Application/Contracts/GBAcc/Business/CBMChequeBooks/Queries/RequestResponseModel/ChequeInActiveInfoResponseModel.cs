using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel
{
   public class ChequeInActiveInfoResponseModel
    {
        public long ChequeID { get; set; }
        public string ChequePrefix { get; set; }
        public string ChequeNumber { get; set; }
        public int COABankAccountID { get; set; }
        public string COAAccountName { get; set; }
        public int? ChequeStatusID { get; set; }

    }
}
