using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc.Business
{
    public class BankVoucherInfo : AuditableEntity
    {
        public long VoucherID { get; set; }
        public int AccountID { get; set; }
        public long InstrumentID { get; set; }
        public string InstrumentNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public DateTime? DepositDate { get; set; }
        public string TreasuryChallanNo { get; set; }
        public string PropertyAddress { get; set; }
        public string PayeeResident { get; set; }
        public decimal? ProfitonDebt { get; set; }
        public string BorCA { get; set; }
        public decimal? ProfessionalFees { get; set; }
        public int? InstrumentTypeID { get; set; }
        public string ReferenceNo { get; set; }
        public int? VIndex { get; set; }

        public Voucher Voucher { get; set; }
    }
}
