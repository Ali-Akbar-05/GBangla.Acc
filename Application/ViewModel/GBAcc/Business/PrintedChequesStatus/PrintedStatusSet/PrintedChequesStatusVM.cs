using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Business.PrintedChequesStatus.PrintedStatusSet
{
   public class PrintedChequesStatusVM
    {
        [Display(Name ="Bank")]
        public int BankID { get; set; }
        [Display(Name = "Account")]
        public int AccountID { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Status")]
        public int StatusID { get; set; }
        [Display(Name = "Paid To")]
        public string PaidTo { get; set; }
        public string ClearingDate { get; set; }
        public List<SelectListItem> DDLBank { get; set; }
        public List<SelectListItem> DDLAccountNumber { get; set; }
        public List<SelectListItem> DDLStatus { get; set; }

    }
}
