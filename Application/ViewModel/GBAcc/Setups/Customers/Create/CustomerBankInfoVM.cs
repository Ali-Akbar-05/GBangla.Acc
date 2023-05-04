using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.Customers.Create
{
   public class CustomerBankInfoVM
    {
        public string ID { get; set; }
        public string CustomerID { get; set; }
        public string BankName { get; set; }
        public string BranchName { get; set; }
        public string AccountNumber { get; set; }
        public string RoutingNo { get; set; }
        public string SwiftNo { get; set; }
    }
}
