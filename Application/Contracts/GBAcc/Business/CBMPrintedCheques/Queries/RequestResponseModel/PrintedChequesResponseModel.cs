using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries.RequestResponseModel
{
  public  class PrintedChequesResponseModel 
    {
        public long ChqID { get; set; }
        public string ChequeDescription { get; set; }
        public string ChqNumber { get; set; }
        public string ChqDate { get; set; }
        public decimal ChequeAmount { get; set; }
        public string StatusName { get; set; }
        public string StatusDate { get; set; }
        public string ReceivingPerson { get; set; }
        public string Identification { get; set; }
    }
}
