using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class GeneralConfiguration : AuditableEntity
    {
        public int ID { get; set; }
        public string Parameter { get; set; }
        public string PageName { get; set; }
        public int AccountID { get; set; }
        public int? BusinessID { get; set; }

        public string Description { get; set; }
        public int? CompanyID { get; set; }
    }
}
