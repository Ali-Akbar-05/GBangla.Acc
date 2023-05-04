using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class SupplierDetail : AuditableEntity
    {
        public int ID { get; set; }
        [ForeignKey("Supplier")]
        public int SupplierID { get; set; }
        public string ContactPerson { get; set; }
        public string Designation { get; set; }
        public string Division { get; set; }
        public string CellNumber { get; set; }
        public string ContactEmail { get; set; }
        public virtual Supplier Supplier { get; set; }


    }
}
