using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries.RequestResponseModel
{
   public class AccountTypeResponseModel 
    {
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeComments { get; set; }
        public int ParentID { get; set; }
        public string AccNarroGroup { get; set; }
    }
}
