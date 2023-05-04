using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class VoucherTypes
    {
        public int ID { get; set; }
        [Required]
        public string VoucherType { get; set; }
        [Required]
        [MaxLength(3,ErrorMessage = "Voucher Type Initials not more than 3")]
        public string Initials { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
