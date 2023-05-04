using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
  public  class Payment_Type:AuditableEntity
    {
      public int     ID           {get;set;}
      public string     PaymentType  {get;set;}
      public string PaymentMode { get; set; }
    

    }
}
