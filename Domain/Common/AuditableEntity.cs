using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
  public  class AuditableEntity
    {
        [Column(Order = 95)]
        public bool IsActive { get; set; } = true;

        [Column(Order = 96)]
        public bool IsRemoved { get; set; } = false;

        [Column(Order = 97)]
        public DateTime CreatedDate { get; set; }

        [Column(Order = 98)]
        public int CreatedBy { get; set; }

        [Column(Order = 99)]
        public DateTime? LastModifiedDate { get; set; }

        [Column(Order = 100)]
        public int? LastModifiedBy { get; set; }
    }
}
