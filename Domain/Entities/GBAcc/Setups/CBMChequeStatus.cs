using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class CBMChequeStatus : AuditableEntity
    {
        public int ChequeStatusID { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
    }
}
