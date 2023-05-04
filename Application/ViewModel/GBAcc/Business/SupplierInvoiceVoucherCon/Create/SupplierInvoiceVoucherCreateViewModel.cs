using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Business.SupplierInvoiceVoucherCon.Create
{
    public class SupplierInvoiceVoucherCreateViewModel
    {
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        [Display(Name = "Date")]
        [Required]
        public string VoucherDate { get; set; }
        [Display(Name = "Currency")]
        [Required]
        public int CurrencyID { get; set; }
        [Display(Name="Ex.Rate")]
        public decimal ExchangeRate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Supplier")]
        [Required]
        public int  SupplierID { get; set; }
        [Display(Name = "Bill No")]
        public string BillNo { get; set; }

        [Display(Name = "Bill Date")]
        public string BillDate { get; set; }

        [Display(Name = "Cost Center")]
        public int CostCenter { get; set; }

        [Display(Name = "Activity")]
        [Required]
        public string Activity { get; set; }



        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLCurrency { get; set; }
        public List<SelectListItem> DDLSupplier { get; set; }
        public List<SelectListItem>  DDLCreditCostCenter { get; set; }
        public List<SelectListItem>  DDLCreditActivity { get; set; }
        public List<SelectListItem> DDLDebitAccount { get; set; }



    }
}
