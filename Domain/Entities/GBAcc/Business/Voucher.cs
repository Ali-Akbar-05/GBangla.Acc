using Domain.Common;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.GBAcc
{
    public class Voucher : AuditableEntity
    {
        public Voucher()
        {
            VoucherGeneralInfo = new List<VoucherGeneralInfo>();
            VoucherDetail = new List<VoucherDetail>();
            JournalVoucherInfo = new List<JournalVoucherInfo>();
            POAdvancePayment = new List<POAdvancePayment>();
            CBMAdvancePayment = new List<CBMAdvancePayment>();
            CBM_Relate_ECF_RFP_CHQ_Voucher = new List<CBM_Relate_ECF_RFP_CHQ_Voucher>();
            CBM_BillToBillPayment = new List<CBM_BillToBillPayment>();


        }
        public long VoucherID { get; set; }
        public string VoucherNumber { get; set; }
        public int VoucherType { get; set; }
        public DateTime VoucherDate { get; set; }
        //Example= 2020-2021
        public string FiscalYear { get; set; }
        public int? PaymentTypeID { get; set; }
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int LocationID { get; set; }
        public int? PreparedBy { get; set; }
        public int? CheckedBy { get; set; }
        public DateTime? CheckDate { get; set; }
        public int? IndividualVoucherID { get; set; }
        public string VoucherDescription { get; set; }
        public int? AuthorizedBy { get; set; }
        public DateTime? AuthorizeDate { get; set; }
        public DateTime? PrepareDate { get; set; }
        public int? SystemVoucher { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? ExpiredBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public int? NoOfDays { get; set; }
        public string PaymentTerm { get; set; }
        public int SubVoucherType { get; set; }
        public DateTime RDate { get; set; }
        public int? StoreID { get; set; }
        public int? CurrencyID { get; set; }
        public decimal? CRate { get; set; }
        public decimal? AmtInDoller { get; set; }
        public string VoucherCategory { get; set; }
        public decimal? BillVatPercent { get; set; }
        public decimal? BillIncomeTaxPercent { get; set; }
      

        public List<VoucherGeneralInfo> VoucherGeneralInfo { get; set; }
        public List<VoucherDetail> VoucherDetail { get; set; }
        public List<JournalVoucherInfo> JournalVoucherInfo { get; set; }
        public List<POAdvancePayment> POAdvancePayment { get; set; }
        public BankVoucherInfo BankVoucherInfo { get; set; }
        public List<CBMAdvancePayment> CBMAdvancePayment { get; set; }
        public List<CBM_Relate_ECF_RFP_CHQ_Voucher> CBM_Relate_ECF_RFP_CHQ_Voucher { get; set; }
        public List<CBM_BillToBillPayment> CBM_BillToBillPayment { get; set; }
    }
}
