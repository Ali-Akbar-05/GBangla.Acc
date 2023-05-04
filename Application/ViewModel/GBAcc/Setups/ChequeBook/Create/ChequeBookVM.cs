using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Setups.ChequeBook.Create
{
   public class ChequeBookVM
    {
        [Display(Name ="Bank")]
        public int BankID { get; set; }
        [Display(Name = "Branch")]
        public int BranchID { get; set; }
        [Display(Name = "Identification")]
        public int IdentificationID { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyID { get; set; }
        [Display(Name = "Account Type")]
        public int AccountType { get; set; }
        [Display(Name = "Account Number")]
        public int AccountNumberID { get; set; }
        [Display(Name = "Signatory")]
        public int SignatoryID { get; set; }
        public string Status { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLBranch { get; set; }
        public List<SelectListItem> DDLIdentification { get; set; }
        public List<SelectListItem> DDLCurrency { get; set; }
        public List<SelectListItem> DDLAccountNumber { get; set; }
        public List<SelectListItem> DDLSignatory { get; set; }
        public List<SelectListItem> DDLAccountType { get; set; }
        public List<SelectListItem> DDLStatus { get; set; }

    }
}
