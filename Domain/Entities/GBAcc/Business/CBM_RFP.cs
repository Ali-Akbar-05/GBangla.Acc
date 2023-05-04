using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
  public  class CBM_RFP:AuditableEntity
    {
     public long RFPID               {get;set;}
     public string RFPNum              {get;set;}
     public DateTime RFPDate             {get;set;}
     public int LocationID          {get;set;}
     public string RFPDescription      {get;set;}
     public string PaymentMode         {get;set;}
     public decimal? NetAmount           {get;set;}
     public int SupplierID          {get;set;}
     public int CompanyID           {get;set;}
     public int BusinessID          {get;set;}
     public int? CreationBy          {get;set;}
     public DateTime? CreationDate        {get;set;}
     public int? VerificationBy      {get;set;}
     public DateTime? VerificationDate    {get;set;}
     public int? CheckBy             {get;set;}
     public DateTime? CheckDate           {get;set;}
     public bool IsAdvanceAdjusted   {get;set;}
     public int? RFPAddedStatus      {get;set;}
     public int? RelatedOldRFPID     {get;set;}
    public virtual ICollection<CBM_RFP_Detail> CBM_RFP_Detail { get; set; }

    }
}
