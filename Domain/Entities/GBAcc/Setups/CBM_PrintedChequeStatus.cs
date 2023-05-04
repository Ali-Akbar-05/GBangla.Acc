﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
   public class CBM_PrintedChequeStatus:AuditableEntity
    {
     public int  StatusID               {get;set;}
     public string  StatusName          {get;set;}
     public string StatusDescription { get; set; }
    }
}
