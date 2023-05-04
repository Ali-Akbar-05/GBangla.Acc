using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMChequeBooks.Commands.DataTransferModel
{
   public class CBMChequeBookDTM
    {
        public int ID { get; set; }
        public string Prefix { get; set; }
        public string SeriesStart { get; set; }
        public string SeriesEnd { get; set; }
        public int AccountID { get; set; }
        public string SerialStatus { get; set; }
    }
}
