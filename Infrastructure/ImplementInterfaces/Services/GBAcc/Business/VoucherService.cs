using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.CBMRFPs.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.Vouchers.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using AutoMapper;
using Domain.Constants;
using Domain.Entities.GBAcc;
using Domain.Entities.GBAcc.Business;
using Domain.Enums;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IMapper mapper;
        private readonly ICurrentUserService _currentUserService;
        private readonly IAPM_Invoice_MainRepository aPM_Invoice_MainRepository;
        private readonly ICBM_RFPRepository cBM_RFPRepository;
        private readonly ICBMChequeBookRepository _cbmChequeBookRepository;
        private readonly ICBMAdvancePaymentRepository _cbmAdvancePaymentRepository;
        private readonly ICBMAdvancePaymentRFP_RelateRepository _cbmAdvancePaymentRFP_RelateRepository;
        private readonly ICBMChequeRepository cBMChequeRepository;

        public VoucherService(IVoucherRepository voucherRepository, IMapper _mapper, ICurrentUserService currentUserService,
            IAPM_Invoice_MainRepository _aPM_Invoice_MainRepository, ICBM_RFPRepository _cBM_RFPRepository
            , ICBMChequeBookRepository cbmChequeBookRepository, ICBMAdvancePaymentRepository cbmAdvancePaymentRepository
            , ICBMAdvancePaymentRFP_RelateRepository cbmAdvancePaymentRFP_RelateRepository, ICBMChequeRepository _cBMChequeRepository)
        {
            _voucherRepository = voucherRepository;
            mapper = _mapper;
            _currentUserService = currentUserService;
            aPM_Invoice_MainRepository = _aPM_Invoice_MainRepository;
            cBM_RFPRepository = _cBM_RFPRepository;
            _cbmChequeBookRepository = cbmChequeBookRepository;
            _cbmAdvancePaymentRepository = cbmAdvancePaymentRepository;
            _cbmAdvancePaymentRFP_RelateRepository = cbmAdvancePaymentRFP_RelateRepository;
            this.cBMChequeRepository = _cBMChequeRepository;
        }

        public async Task<RResult> SaveSupplierInvoiceVoucher(VoucherDTM model)
        {
            var result = new RResult();
            var locationID = model.LocationID;
            var businessID = _currentUserService.BusinessID;
            var companyID = _currentUserService.CompanyID;
            var dbVoucher = await GetDBVoucherData(model);
            var voucher = await _voucherRepository.SaveSupplierInvoiceVoucher(dbVoucher);
            var voucherID = voucher.LongID;
            var dbInvoiceModel = await GetDBInvoiceData(voucherID, companyID);
            var rtnInvioceObj = await aPM_Invoice_MainRepository.SaveAPMInvoice(dbInvoiceModel);
            var invoiceID = rtnInvioceObj.LongID;
            var rFPDate = dbInvoiceModel.InvoiceDate;
            var dbModel = await GetDBCBM_RFPData(invoiceID, companyID, locationID, businessID, rFPDate);
            await cBM_RFPRepository.InsertAsync(dbModel, true);
            result.result = 1;
            result.message = ReturnMessage.SaveMessage;
            return result;
        }


        public async Task<Voucher> GetDBVoucherData(VoucherDTM model)
        {
            var locationID = model.LocationID;
            var businessID = _currentUserService.BusinessID;
            var companyID = _currentUserService.CompanyID;
            var voucherNumber = await _voucherRepository.GenerateVoucherNumber(locationID, (int)Enum_VoucherType.SIV, companyID, businessID, model.VoucherDate);
            var dbVoucher = mapper.Map<VoucherDTM, Voucher>(model);
            dbVoucher.VoucherNumber = voucherNumber.Item1;
            dbVoucher.CompanyID = companyID;
            dbVoucher.BusinessID = businessID;
            dbVoucher.VoucherType = (int)Enum_VoucherType.SIV;
            dbVoucher.PreparedBy = _currentUserService.UserID;
            dbVoucher.PrepareDate = DateTime.Now;
            dbVoucher.FiscalYear = voucherNumber.Item3;
            dbVoucher.IndividualVoucherID = voucherNumber.Item2;
            dbVoucher.RDate = DateTime.Now;
            dbVoucher.SubVoucherType = 1;
            dbVoucher.SystemVoucher = 0;
            return dbVoucher;
        }
        private async Task<APM_Invoice_Main> GetDBInvoiceData(long voucherID, int companyID)
        {
            var invoiceData = await _voucherRepository.GetInvoiceRelatedDataByVoucherID(voucherID);
            invoiceData.InvoiceNumber = await aPM_Invoice_MainRepository.GetInvoiceNumber(companyID, voucherID);
            invoiceData.InvoiceSystemID = await aPM_Invoice_MainRepository.GetInvoiceSystemID(companyID);
            var dbInvoiceMain = mapper.Map<InvoiceRelatedDataResponseModel, APM_Invoice_Main>(invoiceData);
            dbInvoiceMain.APM_Invoice_Detail = new List<APM_Invoice_Detail>() { new APM_Invoice_Detail() { VoucherID = voucherID, InvoiceEffect = 1 } };
            return dbInvoiceMain;
        }
        private async Task<CBM_RFP> GetDBCBM_RFPData(long invoiceID, int companyID, int locationID, int businessID, DateTime rfpDate)
        {
            var cbmRFPObj = await aPM_Invoice_MainRepository.GetCBM_RFPRelatedDataByInvoiceID(invoiceID);
            var dbModel = mapper.Map<CBM_RFPRelatedDataResponseModel, CBM_RFP>(cbmRFPObj);
            dbModel.RFPNum = await cBM_RFPRepository.GetRFPNumber(locationID, businessID, companyID, rfpDate);
            dbModel.RFPDate = rfpDate;
            dbModel.BusinessID = businessID;
            dbModel.LocationID = locationID;
            dbModel.RFPAddedStatus = 5;
            dbModel.PaymentMode = "Cash";
            dbModel.CBM_RFP_Detail = new List<CBM_RFP_Detail>() { new CBM_RFP_Detail() { InvoiceID = invoiceID } };
            return dbModel;
        }

        public async Task<RResult> SaveBankPaymentVoucher(BankVouchersDTM vwmodel, CancellationToken cancellationToken)
        {
            int hasAnyError = 0;
            RResult result = new RResult();
            ChequeInActiveInfoResponseModel chequeInfo = new ChequeInActiveInfoResponseModel();
            List<Voucher> insertVoucherList = new List<Voucher>();
            List<CBMCheque> updateChequeList = new List<CBMCheque>();
            StringBuilder sbMessage = new StringBuilder();
            /// Check have voucher details and amount is same
            try
            {
                using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, TransactionScopeAsyncFlowOption.Enabled))
                {
                    foreach (var model in vwmodel.Vouchers)
                    {
                        if (model.VoucherDetail == null
                           || model.VoucherDetail.Any(b => b.Amount == 0)
                           || (model.VoucherDetail.Sum(b => b.Amount) != 0)
                           || model.VoucherGeneralInfo == null)
                        {
                            hasAnyError += 1;
                            result.result = 0;
                            result.message = "Voucher Amount mismatch.";
                            return result;
                        }
                        var creditDetails = model.VoucherDetail.Where(b => b.TransactionType == "Cr").First();

                        if (vwmodel.Instrument.InstrumentTypeID == 1 || vwmodel.Instrument.InstrumentTypeID == 2)
                        {
                            int numberOfCheck = await _cbmChequeBookRepository.AvailableCheque(creditDetails.AccountID, cancellationToken);
                            if (numberOfCheck == 0)
                            {
                                hasAnyError += 1;
                                result.result = 0;
                                result.message = "No Cheque found.";
                                return result;
                            }
                            chequeInfo = await _cbmChequeBookRepository.GetInactiveChequeInfo(creditDetails.AccountID, cancellationToken);
                        }

                        var _voucherNumberInfo = await _voucherRepository.GenerateVoucherNumber(model.LocationID, model.VoucherType, _currentUserService.CompanyID
                                   , _currentUserService.BusinessID, model.VoucherDate);

                        sbMessage.AppendLine($"Voucher Number : {_voucherNumberInfo.Item1},");
                        Voucher dbVoucher = mapper.Map<VoucherDTM, Voucher>(model);
                        dbVoucher.VoucherNumber = _voucherNumberInfo.Item1;
                        dbVoucher.IndividualVoucherID = _voucherNumberInfo.Item2;
                        dbVoucher.FiscalYear = _voucherNumberInfo.Item3;
                        dbVoucher.PrepareDate = DateTime.Now.Date;
                        dbVoucher.RDate = DateTime.Now;
                        dbVoucher.CompanyID = _currentUserService.CompanyID;
                        dbVoucher.BusinessID = _currentUserService.BusinessID;
                        dbVoucher.PrepareDate = DateTime.Now;
                        dbVoucher.PreparedBy = _currentUserService.UserID;
                        dbVoucher.SystemVoucher = 0;

                        BankVoucherInfo dbBankVoucherInfo = new BankVoucherInfo()
                        {
                            AccountID = creditDetails.AccountID,
                            InstrumentTypeID = vwmodel.Instrument.InstrumentTypeID,
                            InstrumentID = chequeInfo != null ? chequeInfo.ChequeID : 0,
                            InstrumentNo = vwmodel.Instrument.InstrumentNo==null?chequeInfo.ChequeNumber: vwmodel.Instrument.InstrumentNo,
                            VoucherDate = vwmodel.Instrument.ChequeDate,
                            VIndex = creditDetails.VIndex
                        };

                        dbVoucher.BankVoucherInfo = dbBankVoucherInfo;

                        if (model.PaymentTypeID == 1)
                        {
                            if (model.POAdvancePayment.Count > 0)
                            {
                                var advPay = model.POAdvancePayment.Select(s => new POAdvancePayment
                                {
                                    POID = s.POID,
                                    Deduction = s.Deduction,
                                    SupplierID = s.SupplierID,
                                    PoNumber = s.PoNumber,
                                    StoreID = s.StoreID
                                }).ToList();

                                dbVoucher.POAdvancePayment.AddRange(advPay);
                            }
                        }

                        if (model.PaymentTypeID == 2)
                        {
                            #region RFP
                            var RFPList = model.VoucherGeneralInfo.Where(b => b.TransactionType == "Cr" && b.RFPID != null && (b.RFPID != null && b.RFPID > 0)).ToList();
                            if (RFPList.Count > 0)
                            {
                                var nlist = RFPList.Select(b => new CBM_Relate_ECF_RFP_CHQ_Voucher()
                                {
                                    ChequeID = chequeInfo.ChequeID,
                                    RFPID = b.RFPID,

                                });
                                dbVoucher.CBM_Relate_ECF_RFP_CHQ_Voucher.AddRange(nlist);
                            }
                            #endregion RFP

                            #region Bill To Bill Entry
                            #region Alog Code
                            /*
                            var invoiceBillList = model.VoucherPayment.Select(b => new { InvoiceID = b.InvoiceID }).ToList()
                                                  .Union(model.AdjustmentVoucher.Select(b => new { InvoiceID = b.InvoiceID }).ToList()).ToList();

                            var _cbmBillToBillPaymentQuery = from inv in invoiceBillList
                                                             //join adj in model.AdjustmentVoucher on inv.InvoiceID equals adj.InvoiceID into invAdjInto
                                                             //from invAdj in invAdjInto.DefaultIfEmpty()

                                                             join pay in model.VoucherPayment on inv.InvoiceID equals pay.InvoiceID into payInvInto
                                                             from payInv in payInvInto.DefaultIfEmpty()
                                                             select new CBM_BillToBillPayment
                                                             {
                                                                 AdjustmentVoucherID = invAdj.VoucherID,
                                                                 InvoiceID = inv.InvoiceID,
                                                                 AdjustedAmount = invAdj == null ? 0 : invAdj.Deduction,
                                                                 PaidAmount = payInv == null ? 0 : payInv.Deduction
                                                             };
                            */
                            #endregion Alog Code

                            var _cbmBillToBillPaymentQuery = from pay in model.VoucherPayment
                                                             select new CBM_BillToBillPayment
                                                             {
                                                                 InvoiceID = pay.InvoiceID,
                                                                 PaidAmount = pay.Deduction
                                                             };
                            dbVoucher.CBM_BillToBillPayment.AddRange(_cbmBillToBillPaymentQuery.ToList());
                            #endregion
                        }

                        var voucherSave = await _voucherRepository.SaveBankPaymentVoucher(dbVoucher, cancellationToken);

                        #region After Voucher Save
                        if (vwmodel.Instrument.InstrumentTypeID == 1 || vwmodel.Instrument.InstrumentTypeID == 2)
                        {
                            CBMCheque cbmCheque = new CBMCheque();
                            cbmCheque.ChequeID = chequeInfo != null ? chequeInfo.ChequeID : 0;
                            cbmCheque.VoucherID = voucherSave.LongID;
                            cbmCheque.AccountID = creditDetails.AccountID;
                            cbmCheque.ChequeStatusID = 6;
                            cbmCheque.ChequeAmount = Math.Abs(creditDetails.Amount);
                            cbmCheque.ChequeDate = vwmodel.Instrument.ChequeDate;
                            if (model.VoucherCategory == "Party")
                            {
                                cbmCheque.ChequeDescription = vwmodel.Instrument.Narration;
                            }
                            else
                            {
                                cbmCheque.ChequeDescription = "Bangladesh Bank";
                            }
                            cbmCheque.ChequeSignatoryID = vwmodel.Instrument.SignatoryID;

                            await cBMChequeRepository.UpdateCBMCheque(cbmCheque);

                        }
                        if (model.PaymentTypeID == 3)
                        {
                            List<CBMAdvancePayment> cbmAdvance = new List<CBMAdvancePayment>();
                            /// Should be change voucherID=11
                            cbmAdvance = await _voucherRepository.GetVoucherDetailsForAdvancePayment(voucherSave.LongID, cancellationToken);
                            var advanceResult = await _cbmAdvancePaymentRepository.SaveAdvancePayment(cbmAdvance);
                        }
                        if (model.AdjustmentVoucher.Count > 0)
                        {
                            var adjustVoucherList = model.AdjustmentVoucher.Select(b => b.VoucherID)
                                                         .Distinct()
                                                         .ToList();
                            var adjustInvoiceList = model.AdjustmentVoucher
                                                         .Select(b => b.InvoiceID)
                                                         .Distinct()
                                                         .ToList();


                            var _rfpRelelatedDataList = await _cbmAdvancePaymentRepository.GetCBMAdvancePaymentRFP_Relate(adjustVoucherList, adjustInvoiceList);

                            List<CBMAdvancePaymentRFP_Relate> advRFP_RelatedDate = new List<CBMAdvancePaymentRFP_Relate>();
                            advRFP_RelatedDate = (from adv in model.AdjustmentVoucher
                                                  join vv in _rfpRelelatedDataList on new { f1 = adv.VoucherID, f2 = adv.InvoiceID } equals new { f1 = vv.VoucherID, f2 = vv.InvoiceID }
                                                  select new CBMAdvancePaymentRFP_Relate
                                                  {
                                                      AdvancePaymentID = vv.AdvancePaymentID,
                                                      InvoiceID = vv.InvoiceID,
                                                      RFPID = vv.RFPID,
                                                      AmountDeducted = adv.Deduction
                                                  }).ToList();
                            var adv_rfp_Related = await _cbmAdvancePaymentRFP_RelateRepository.SaveList(advRFP_RelatedDate);

                        }
                        #endregion After Voucher Save


                    }
                    transactionScope.Complete();
                }
                result.result = 1;
                sbMessage.AppendLine("Successfully Created");
                result.message = sbMessage.ToString();
            }
            catch (Exception e)
            {
                result.result = 0;
                result.message = e.Message;
            }
            return result;
        }

        public async Task<List<SelectListItem>> GetDateWiseVoucherNumber(int companyID, int businessID, DateTime dateFrom, DateTime dateTo, int voucherType = 0)
        {
            return await _voucherRepository.GetDateWiseVoucherNumber(companyID, businessID, dateFrom, dateTo, voucherType);
        }

        public async Task<List<CBM_ReportListResponseModel>> GetVoucherListForReport(long voucherID, int voucherType, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken)
        {
            return await _voucherRepository.GetVoucherListForReport(voucherID, voucherType, dateFrom, dateTo, cancellationToken);
        }
    }
}
