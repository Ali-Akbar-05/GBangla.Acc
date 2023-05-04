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
    public class Location: AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SrNum { get; set; }
        public string LocationCode { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public string Address { get; set; }
        public string PlotNo { get; set; }
        public string Area { get; set; }
        public string City { get; set; }
        public string Tel1 { get; set; }
        public string Tel2 { get; set; }
        public string Fax { get; set; }
        public string LocationInitials { get; set; }
 

    }
}
