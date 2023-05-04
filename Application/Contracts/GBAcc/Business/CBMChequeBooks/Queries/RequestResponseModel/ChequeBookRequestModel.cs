using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel
{
   public class ChequeBookRequestModel
    {
        public int BankID { get; set; } 
        public int BranchID { get; set; }
        public int IdentificationID { get; set; }
        public int CurrencyID { get; set; }
        public int AccountNumberID { get; set; }
        public string Status { get; set; }
    }
}
