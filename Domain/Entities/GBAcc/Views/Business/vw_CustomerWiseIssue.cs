using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Views.Business
{
    public class vw_CustomerWiseIssue
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public long IssueMID { get; set; }
        public string IssueNo { get; set; }
        public long PaymentModeID { get; set; }
        public long PaymentTermsID { get; set; }
        public long CurrencyID { get; set; }
        public DateTime IssueDate { get; set; }
        public int IssueStatus { get; set; }
        public long JobID { get; set; }
    }
}
