using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.POInfo.Queries.DataResponseModel
{
    public class POForAdvanceDRM
    {
        public long POID { get; set; }
        public string PONo { get; set; }
        public decimal TotalPOAmount { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string CurrentDate { get { return DateTime.Now.ToString("dd-MMM-yyyy"); }}
        public decimal AdvancePercentage { get; set; }
        public decimal PercentageAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public int CurrencyID { get; set; }
        public decimal ConversionRate { get; set; }
        public int StoreID { get; set; }
        public int SupplierID { get; set; }
    }
}
