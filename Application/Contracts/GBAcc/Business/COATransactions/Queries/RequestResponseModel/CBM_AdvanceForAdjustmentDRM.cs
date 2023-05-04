using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.COATransactions.Queries.RequestResponseModel
{
    public class CBM_AdvanceForAdjustmentTotalDRM
    {
        public CBM_AdvanceForAdjustmentTotalDRM()
        {
            CBM_AdvanceForAdjustment = new List<CBM_AdvanceForAdjustmentDRM>();

        }
        public decimal TotalBalance { get { return CBM_AdvanceForAdjustment.Count>0?CBM_AdvanceForAdjustment.Sum(b => b.Balance):0; } }
        public List<CBM_AdvanceForAdjustmentDRM> CBM_AdvanceForAdjustment { get; set; }
    }
   public  class CBM_AdvanceForAdjustmentDRM
    {
        public long VoucherID { get; set; }
        public string VoucherNumber { get; set; }
        public DateTime VoucherDate { get; set; }
        public string VoucherDescription { get; set; }
        public decimal VoucherAmount { get; set; }

        public decimal Deduction { get; set; }
        public decimal Balance { get; set; }


    }
}
