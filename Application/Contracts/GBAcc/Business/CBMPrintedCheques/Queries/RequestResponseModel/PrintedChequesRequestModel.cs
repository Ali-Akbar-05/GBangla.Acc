using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries.RequestResponseModel
{
  public  class PrintedChequesRequestModel 
    {
        public int AccountID { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string ChequeDescription { get; set; }
        public int Status { get; set; }
    }
}
