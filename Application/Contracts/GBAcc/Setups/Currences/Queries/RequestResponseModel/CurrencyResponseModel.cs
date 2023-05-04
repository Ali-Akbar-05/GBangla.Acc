using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Currences.Queries.RequestResponseModel
{
   public class CurrencyResponseModel
    {
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
    }
}
