using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class CustomerBankInfo : AuditableEntity
    {
        public int ID { get; set; }
       // [ForeignKey("Customer")]
        public int CustomerID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNo { get; set; }
        public string SwiftNo { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
