using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class CBM_Bank : AuditableEntity
    {
        [Key]
      public int BankID { get;set;}
      public string BankName { get;set;}
      public string Abbreviation { get;set;}
      public int CompanyID { get; set; }
    }
}
