using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
   public class CBM_RFP_Detail:AuditableEntity
    {
     public long  ID                   {get;set;} 
     public long  RFPID                {get;set;}
     public long  InvoiceID            {get;set;}
     public virtual CBM_RFP CBM_RFP { get; set; }
    }
}
