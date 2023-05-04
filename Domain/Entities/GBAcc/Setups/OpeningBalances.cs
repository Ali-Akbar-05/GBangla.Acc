using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
  public  class OpeningBalances:AuditableEntity
    {
      public int   ID              {get;set;}
      public int   AccountID       {get;set;}
      public decimal   OpeningBalance  {get;set;}
      public int?   CostCenterID    {get;set;}
      public int?   ActivityID      {get;set;}
      public int?  LocationID      {get;set;}
      public int   FiscalYear      {get;set;}
      public DateTime RDate { get; set; }
   

    }
}
