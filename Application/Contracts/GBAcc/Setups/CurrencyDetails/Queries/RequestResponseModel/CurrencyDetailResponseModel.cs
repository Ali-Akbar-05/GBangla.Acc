using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries.RequestResponseModel
{
   public class CurrencyDetailResponseModel
    {
        public int ID { get; set; }
        public decimal RateInBDT { get; set; }
        public string Date { get; set; }
        public int CurrencyID { get; set; }
        public string Currency { get; set; }
    }
}
