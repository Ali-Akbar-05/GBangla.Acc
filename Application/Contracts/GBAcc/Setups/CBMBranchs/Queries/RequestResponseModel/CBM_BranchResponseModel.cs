using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMBranchs.Queries.RequestResponseModel
{
   public class CBM_BranchResponseModel
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string BranchAddress { get; set; }
        public int BankID { get; set; }
        public string BankName { get; set; }
    }
}
