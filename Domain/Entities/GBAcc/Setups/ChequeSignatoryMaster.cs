using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class ChequeSignatoryMaster: AuditableEntity
    {
        public int ID { get; set; }
        public int ApprovalLimit { get; set; }
        public int CompanyID { get; set; }
        public string Description { get; set; }
    }
}
