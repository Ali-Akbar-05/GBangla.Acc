using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class BasicCOA : AuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int AccID { get; set; }
        public string AccName { get; set; }
        public string AccCode { get; set; }
        public int? ParentID { get; set; }
        public int LevelID { get; set; }
        public int? NaturalAccountID { get; set; }
        public int? CompanyID { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
