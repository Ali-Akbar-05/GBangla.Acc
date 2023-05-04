using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.Suppliers.Create
{
  public  class SupplierBankInfoVM
    {
        public int ID { get; set; }
        public int SupplierID { get; set; }
        [Display(Name = "Bank")]
        public string BankName { get; set; }
        [Display(Name = "Branch")]
        public string BranchName { get; set; }
        [Display(Name = "Account Number")]
        public string AccountNumber { get; set; }
        [Display(Name = "Routing No")]
        public string RoutingNo { get; set; }
        [Display(Name = "Swift No")]
        public string SwiftNo { get; set; }
    }
}
