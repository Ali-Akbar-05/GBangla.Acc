using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMCheques.Queries.RequestResponseModel
{
  public  class CBMChequeResponseModel
    {
        public long ChequeID { get; set; }
        public string ChequeNum { get; set; }
        public int? AccountID { get; set; }
        public int? ChequeStatusID { get; set; }
        public string StrChequeStatus { get; set; }
        public int? SignStatus { get; set; }
        public int ChequeBookID { get; set; }
        public decimal? ChequeAmount { get; set; }
        public string StrChequeAmount { get; set; }
        public DateTime? ChequeDate { get; set; }
        public string StrChequeDate { get; set; }
        public string ChequeDescription { get; set; }
       
    }
}
