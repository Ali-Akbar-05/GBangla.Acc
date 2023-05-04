using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Views.Business
{
  public  class vw_Invoice
    {
        public int SupplierID { get; set; }
        public long InvoiceID { get; set; }
        public string PONum { get; set; }
        public string InvoiceSystemID { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal GRVGross { get; set; }
        public decimal GRVSalesTax { get; set; }
        public decimal GRVExciseDuty { get; set; }
        public decimal NetAmount { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal NEDNGross { get; set; }
        public decimal NEDNSalesTax { get; set; }
        public decimal NEDNExciseDuty { get; set; }
        public decimal NEDN { get; set; }
        public decimal EDNGross { get; set; }
        public decimal EDNSalesTax { get; set; }
        public decimal EDNExciseDuty { get; set; }
        public decimal EDN { get; set; }
        public decimal SalesTax { get; set; }
        public decimal ExciseDuty { get; set; }
        public int NoOfDays { get; set; }
        public DateTime PrepareDate { get; set; }
        public int CompanyID { get; set; }
        public int InvoiceType { get; set; }
        public int? StatusID { get; set; }
        public decimal? AmtInDoller { get; set; }
        public decimal? CurrencyRate { get; set; }
    }
}
