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
    public class Supplier : AuditableEntity
    {
        public Supplier()
        {
            SupplierDetail = new HashSet<SupplierDetail>();
            SupplierBankInfo = new HashSet<SupplierBankInfo>();

        }
        [ForeignKey("BasicCOA")]
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string SupplierCode { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxRegNumber { get; set; }
        public string NTNNumber { get; set; }
        public string Comments { get; set; }
        public string SupplierType { get; set; }
        public virtual ICollection<SupplierDetail> SupplierDetail { get; set; }
        public virtual ICollection<SupplierBankInfo> SupplierBankInfo { get; set; }

        public virtual BasicCOA BasicCOA { get; set; }
    }
}
