using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.CBMBankAccount.Create
{
   public class CBMBankAccountVM
    {
        public int ID { get; set; }
        [Display(Name = "Account Type")]
        public int AccTypeID { get; set; }
        [Display(Name = "Bank")]
        public int BankID { get; set; }
        [Display(Name = "Branch")]
        public int BranchID { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyID { get; set; }
        [Display(Name = "Account Number")]
        [Required]
        public string AccountNumber { get; set; }

        public string Name { get; set; }
        public string Designation { get; set; }
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Fax Number")]
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string Comments { get; set; }
        public List<SelectListItem> DDLAccountType { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLBranch { get; set; }
        public List<SelectListItem> DDLCurrency { get; set; }
      

    }
}
