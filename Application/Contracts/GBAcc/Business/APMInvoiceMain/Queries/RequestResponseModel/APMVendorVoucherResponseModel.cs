using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel
{
  public  class APMVendorVoucherResponseModel
    {
        public long VoucherID { get; set; }
        public int? IndividualVoucherId { get; set; }
        public int VoucherType { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime VoucherDate { get; set; }
        public string StrVoucherDate
        {
            get { return VoucherDate.ToString("dd-MMM-yyyy");  }
        }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string BillNumber { get; set; }
        public string POReferenceNo { get; set; }
        public DateTime? PODate { get; set; }
        public string StrPODate
        { get
            {
                if (PODate != null)
                {return PODate.Value.ToString("dd-MMM-yyyy");}
                else
                { return "N/A"; }
            } }
        public string SupplierDONumber { get; set; }
        public DateTime? SupplierDODate { get; set; }
        public string StrSupplierDODate
        {
            get
            {
                if (SupplierDODate != null)
                { return SupplierDODate.Value.ToString("dd-MMM-yyyy"); }
                else
                { return "N/A"; }
            }
        }
        public string GRNNo { get; set; }
        public DateTime? GRNDate { get; set; }
        public string StrGRNDate
        {
            get
            {
                if (GRNDate != null)
                { return GRNDate.Value.ToString("dd-MMM-yyyy"); }
                else
                { return "N/A"; }
            }
        }
        public decimal GrossAmount { get; set; }
        public decimal SalesTax { get; set; }
        public decimal ExciseDuty { get; set; }
        public decimal VoucherTotalAmount { get; set; }
        public decimal DiscountAmount { get; set; }
        public int VoucherIncometaxAcc { get; set; }
        public int VoucherIncomeTaxAmnt { get; set; }
        public decimal VoucherNetAmount { get; set; }
        public int? ItemControlAccountID { get; set; }
        public int SalesTaxControlAccountID { get; set; }
        public int ExciseDutyControlAccountID { get; set; }
        public int GLEffect { get; set; }
        public int InvoiceEffect { get; set; }
        public decimal VoucherQuantity { get; set; }
        public long RawNumber { get; set; }
        public decimal CurrencyRate { get; set; }
      
    }
}
