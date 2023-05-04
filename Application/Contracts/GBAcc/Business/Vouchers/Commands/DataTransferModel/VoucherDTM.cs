using Application.Common.Mappings;
using Application.Contracts.GBAcc.Business.CBM_BillToBillPayments.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.JournalVoucherInfos.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.POAdvancePayments.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.VoucherDetails.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.VoucherGeneralInfos.Commands.DataTransferModel;
using AutoMapper;
using Domain.Entities.GBAcc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel
{
   public class VoucherDTM:IMapFrom<Voucher>
    {
        public VoucherDTM()
        {
            AdjustmentVoucher = new List<AdjustmentVoucherDTM>();
            VoucherPayment = new List<VoucherPaymentDTM>();
        }
     
        public long VoucherID { get; set; }
        public string VoucherNumber { get; set; }
        public int VoucherType { get; set; }
        public DateTime VoucherDate { get; set; }
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
       
        public DateTime? ExpiryDate { get; set; }
        public int? ExpiredBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeletionDate { get; set; }
        public int? NoOfDays { get; set; }
        public string PaymentTerm { get; set; }
       
        public DateTime RDate { get; set; }
        public int? StoreID { get; set; }
        public int? CurrencyID { get; set; }
        public decimal? CRate { get; set; }
        public decimal? AmtInDoller { get; set; }
        public string VoucherCategory { get; set; }
        public decimal? BillVatPercent { get; set; }
        public decimal? BillIncomeTaxPercent { get; set; }
        public List<VoucherDetailDTM> VoucherDetail { get; set; }
        public List<VoucherGeneralInfoDTM> VoucherGeneralInfo { get; set; }
        public List<JournalVoucherInfoDTM> JournalVoucherInfo { get; set; }
        public List<POAdvancePaymentDTM> POAdvancePayment { get; set; }
        public List<CBM_BillToBillPaymentDTM> CBM_BillToBillPayment { get; set; }
        public List<AdjustmentVoucherDTM> AdjustmentVoucher { get; set; }
        public List<VoucherPaymentDTM> VoucherPayment { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<VoucherDTM, Voucher>().ReverseMap();
        }
    }
}
