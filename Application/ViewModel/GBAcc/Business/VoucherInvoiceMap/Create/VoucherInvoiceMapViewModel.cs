using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Business.VoucherInvoiceMap.Create
{
   public class VoucherInvoiceMapViewModel
    {
        [Display(Name ="Account")]
        public int ChartOfAccount { get; set; }
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        [Display(Name = "Currency")]
        public int CurrencyID { get; set; }
        [Display(Name = "Exchange Rate")]
        public decimal ExchangeRate { get; set; }
        [Display(Name = "Date From")]
        public string DateFrom { get; set; }
        [Display(Name = "Date To")]
        public string DateTo { get; set; }
        [Display(Name = "Payment Mode")]
        public int PaymentModeID { get; set; }
        [Display(Name = "PO Number")]
        public string PONumber { get; set; }
        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLCurrency { get; set; }
        public List<SelectListItem> DDLChartOfAccount { get; set; }
        public List<SelectListItem> DDLPaymentMode { get; set; }
        public List<SelectListItem> DDLPONumber { get; set; }

    }
}
