using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModel.GBAcc.Business.CashReceiptVoucher.Create
{
   public class CashReceiptVoucherCreateViewModel
    {
        [Display(Name = "Location")]
        public int LocationID { get; set; }
        [Display(Name = "Voucher Date")]
        public DateTime VoucherDate { get; set; }
        public string VoucherDateStr { get { return VoucherDate.ToString("dd-MMM-yyyy"); } }
        [Display(Name = "Currency")]
        public int CurrencyID { get; set; }
        [Display(Name = "Currency Rate")]
        public decimal CurrencyRate { get; set; }
        [Display(Name = "Description")]
        public string VoucherDescription { get; set; }
        [Display(Name = "Receipt Type")]
        public int ReceiptTypeID { get; set; }

        public List<SelectListItem> DDLLocation { get; set; }
        public List<SelectListItem> DDLCurrency { get; set; }
        public List<SelectListItem> DDLReceiptType { get; set; }

        [Display(Name = "Cash Account")]
        public int DebitAccID { get; set; }
      //  public int LedgerBalance { get; set; }
      [Display(Name = "Cost Center")]
        public int DebitCostCenterID { get; set; }
        [Display(Name = "Activity")]
        public int DebitActivityID { get; set; }
      //  public decimal AvailableAdvance { get; set; }
      //  public bool IsAdjust { get; set; }
     //   public decimal AdjustAmount { get; set; }

        public List<SelectListItem> DDLDebitAccount { get; set; }
        public List<SelectListItem> DDLDebitCostCenter { get; set; }
        public List<SelectListItem> DDLDebitActivity { get; set; }




        [Display(Name = "Received from")]
        public int CreditAccID { get; set; }
        [Display(Name = "Cost Center")]
        public int CreditCostCenterID { get; set; }
        [Display(Name = "Activity")]
        public int CreditActivityID { get; set; }
        [Display(Name = "")]
        public int DiscountAccID { get; set; }

     //   public int InstrumentTypeID { get; set; }
     //   public string InstrumentNo { get; set; }
     //   public string ChequeNarration { get; set; }
        public string ChequeDate { get { return VoucherDate.ToString("dd-MMM-yyyy"); } }

      //  public int SignatoryID { get; set; }
      //  public string FilterTypeBills { get; set; }
    //    public decimal AmountToPay { get; set; }

        public List<SelectListItem> DDLCreditAcc { get; set; }
        public List<SelectListItem> DDLCreditCostCenter { get; set; }
        public List<SelectListItem> DDLCreditActivity { get; set; }
        public List<SelectListItem> DDLDiscountAcc { get; set; }
        public List<SelectListItem> DDLInstrumentType { get; set; }
        public List<SelectListItem> DDLSignatory { get; set; }

        public List<SelectListItem> DDLFilterTypeBills { get; set; }

        [Display(Name = "V.A.T %")]
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
        public int IncomeTaxPercentAccID { get; set; }


        public List<SelectListItem> DDLVatAcc { get; set; }
        public List<SelectListItem> DDLIncomeTax { get; set; }
    }
}
