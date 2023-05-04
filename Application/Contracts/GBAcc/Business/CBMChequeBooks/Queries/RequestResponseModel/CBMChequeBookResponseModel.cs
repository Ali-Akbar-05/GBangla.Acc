using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel
{
 public   class CBMChequeBookResponseModel
    {
        public int ID { get; set; }
        public string Prefix { get; set; }
        public string SeriesStart { get; set; }
        public string SeriesEnd { get; set; }
        public int AccountID { get; set; }
        public string SerialStatus { get; set; }
        public int BankID { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
    }
}
