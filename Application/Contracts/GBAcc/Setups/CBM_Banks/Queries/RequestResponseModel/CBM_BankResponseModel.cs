using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_Banks.Queries.RequestResponseModel
{
   public class CBM_BankResponseModel
    {
        public int BankID { get; set; } 
        public string BankName { get; set; }
        public int? CompanyID { get; set; }
        public string Abbreviation { get; set; }
        public string CompanyName { get; set; }
    }
}
