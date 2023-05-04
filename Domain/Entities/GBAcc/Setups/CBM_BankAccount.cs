using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
  public  class CBM_BankAccount:AuditableEntity
    {
      public int  BAccountID     {get;set;}
      public string  BAccountName   {get;set;}
      public int  TypeID         {get;set;}
      public int?  CurrencyID     {get;set;}
      public int?  BranchID       {get;set;}
      public decimal?  Limit          {get;set;}
      public string LRemarks { get; set; }
    }
}
