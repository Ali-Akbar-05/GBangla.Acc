using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries.RequestResponseModel
{
  public  class BankAccountResponseModel 
    {
        public int BAccountID { get; set; }
        public string AccountType { get; set; }
        public string AccountName { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }
    }
}
