using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.Customers.Create
{
   public class CustomerVM
    {
        public int CustomerID { get; set; }
        [Display(Name ="Customer")]
        [Required]
        public string CustomerName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Telephone")]
        public string TelephoneNumber { get; set; }
        [Display(Name = "Mobile")]
        public string MobileNumber { get; set; }
        [Display(Name = "Fax")]
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        [Display(Name = "Sales Tax")]
        public string SalesTaxNumber { get; set; }
        [Display(Name = "National Tax")]
        public string NationalTaxNumber { get; set; }
        public List<CustomerDetailVM> CustomerDetail { get; set; }
        public List<CustomerBankInfoVM> CustomerBankInfo { get; set; }
    }
}
