using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Setups
{
    public class Customer : AuditableEntity
    {
        public Customer()
        {
            CustomerDetail = new HashSet<CustomerDetail>();
            CustomerBankInfo = new HashSet<CustomerBankInfo>();
        }
     //   [ForeignKey("BasicCOA")]
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string Address { get; set; }
        public string TelephoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string SalesTaxNumber { get; set; }
        public string NationalTaxNumber { get; set; }
        public virtual ICollection<CustomerDetail> CustomerDetail { get; set; }
        public virtual ICollection<CustomerBankInfo> CustomerBankInfo { get; set; }
        public virtual BasicCOA BasicCOA { get; set; }

    }
}
