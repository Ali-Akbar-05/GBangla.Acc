using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class CBM_AcountType : AuditableEntity
    {
        public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }
        public string AccountTypeComments { get; set; }

    }
}
