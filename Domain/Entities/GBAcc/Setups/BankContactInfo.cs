using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class BankContactInfo : AuditableEntity
    {
        public int AccountID { get; set; }
        public string ContactName { get; set; }
        public string Designation { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }

    }
}
