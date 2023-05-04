using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.COATransactions.Queries.RequestResponseModel
{
    public class APM_InvoiceForPaymentDRM
    {
        public long InvoiceID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceSystemID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int InvoiceAge { get; set; }
        public string PONum { get; set; }
        public string PaymentMode { get; set; }
        public int RFPID { get; set; }
        public decimal InvoiceAmount { get; set; }
        public decimal Deduction { get; set; }
        public decimal Balance { get; set; }

        public long RowNum { get; set; }

        public decimal AmtInDoller { get; set; }
        public decimal CurrencyRate { get; set; }

        public string InvoiceDateST { get { return InvoiceDate.ToString("dd-MMM-yyyy"); } }

    }
}
