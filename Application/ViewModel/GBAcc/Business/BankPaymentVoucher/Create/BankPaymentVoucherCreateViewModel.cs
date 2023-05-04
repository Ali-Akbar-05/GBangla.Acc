using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Business.BankPaymentVoucher.Create
{
    public class BankPaymentVoucherCreateViewModel
    {
        public int LocationID { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherDateStr { get { return VoucherDate.ToString("dd-MMM-yyyy"); } }
        public int CurrencyID { get; set; }
        public decimal CurrencyRate { get; set; }
        public string VoucherDescription { get; set; }
        public int PaymentTypeID { get; set; }

        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLCurrency { get; set; }
        public List<SelectListItem> DDLPaymentType { get; set; }


        public int DebitAccID { get; set; }
        public int LedgerBalance { get; set; }
        public int DebitCostCenterID { get; set; }
        public int DebitActivityID { get; set; }
        public decimal AvailableAdvance { get; set; }
        public bool IsAdjust { get; set; }
        public decimal AdjustAmount { get; set; }

        public List<SelectListItem> DDLDebitAccount { get; set; }
        public List<SelectListItem> DDLDebitCostCenter { get; set; }
        public List<SelectListItem> DDLDebitActivity { get; set; }





        public int CreditAccID { get; set; }
        public int CreditCostCenterID { get; set; }
        public int CreditActivityID { get; set; }

        public int DiscountAccID { get; set; }

        public int InstrumentTypeID { get; set; }
        public string InstrumentNo { get; set; }
        public string ChequeNarration { get; set; }
        public string ChequeDate { get { return VoucherDate.ToString("dd-MMM-yyyy"); } }

        public int SignatoryID { get; set; }
        public string FilterTypeBills { get; set; }
        public decimal AmountToPay { get; set; }

        public List<SelectListItem> DDLCreditAcc { get; set; }
        public List<SelectListItem> DDLCreditCostCenter { get; set; }
        public List<SelectListItem> DDLCreditActivity { get; set; }
        public List<SelectListItem> DDLDiscountAcc { get; set; }
        public List<SelectListItem> DDLInstrumentType { get; set; }
        public List<SelectListItem>  DDLSignatory { get; set; }

        public List<SelectListItem> DDLFilterTypeBills { get; set; }

        [Display(Name ="V.A.T %")]
        public int VatPercent { get; set; }
        [Display(Name = "V.A.T Amount")]
        public decimal VatAmount { get; set; }
        [Display(Name = "V.A.T Account")]
        public int VatAccID { get; set; }
        public bool IsChallanProvideByParty { get; set; }
        [Display(Name = "I.Tax %")]
        public int IncomeTaxPercent { get; set; }
        [Display(Name = "I.Tax Amt.")]
        public decimal IncomeTaxAmount { get; set; }
        [Display(Name = "I.Tax Account")]
        public int IncomeTaxPercentAccID {get;set;}


        public List<SelectListItem> DDLVatAcc { get; set; }
        public List<SelectListItem> DDLIncomeTax { get; set; }

    }
}
 