using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class Currency : AuditableEntity
    {
        [Key]
        public int CurrencyID { get; set; }
        public string CurrencyName { get; set; }
        public string Symbol { get; set; }
        public string ShortName { get; set; }
       
    }
}
