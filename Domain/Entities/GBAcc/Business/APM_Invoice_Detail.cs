using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
  public  class APM_Invoice_Detail:AuditableEntity
    {
     public long InvoiceDetailID   {get;set;} 
     public long InvoiceID         {get;set;}
     public long VoucherID         {get;set;}
     public int? InvoiceEffect     {get;set;}
     public virtual APM_Invoice_Main APM_Invoice_Main { get; set; }
    }
}
