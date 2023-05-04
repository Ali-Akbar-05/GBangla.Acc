using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class APM_Invoice_Main : AuditableEntity
    {
        public APM_Invoice_Main()
        {
            APM_Invoice_Detail = new HashSet<APM_Invoice_Detail>();
        }
        public long InvoiceID { get; set; }
        public string InvoiceSystemID { get; set; }
        public string InvoiceNumber { get; set; }
        public int TransactionTypeID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal GrossAmount { get; set; }
        public decimal NetAmount { get; set; }
        public decimal TaxRate { get; set; }
        public string PONum { get; set; }
        public int SupplierID { get; set; }
        public int CompanyID { get; set; }
        public int PreparedBy { get; set; }
        public DateTime PrepareDate { get; set; }
        public int? StatusID { get; set; }
        public decimal? ExDtyRate { get; set; }
        public int InvoiceType { get; set; }
        public int? CurrencyID { get; set; }
        public decimal? CurrencyRate { get; set; }
        public decimal? AdvAdjusted { get; set; }
        public decimal? AmtInDoller { get; set; }
        public string LcAcceptenceNo { get; set; }
        public decimal? InvoiceAmount { get; set; }
        public virtual ICollection<APM_Invoice_Detail> APM_Invoice_Detail { get; set; }
    }
}
