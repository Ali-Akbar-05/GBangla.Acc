using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.AccReports.CBMReports
{
  public  class CBMReportsVM
    {
        [Display(Name ="Voucher Type")]
        public int VoucherType { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Voucher Number")]
        public string VoucherID { get; set; }
        public List<SelectListItem> DDLVoucherNumber { get; set; }
        public List<SelectListItem> DDLVoucherType { get; set; }
    }
}
