using Application.Common.CommonModels;
using Application.Common.Interfaces;
using Application.Common.Utilities;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.DataTransferModel;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.CBMRFPs.DataTransferModel;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Setups;
using AutoMapper;
using Domain.Constants;
using Domain.Entities.GBAcc;
using Domain.Entities.GBAcc.Business;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class APM_Invoice_MainService : IAPM_Invoice_MainService
    {
        private readonly IAPM_Invoice_MainRepository aPM_Invoice_MainRepository;
        private readonly IMapper mapper;
        private readonly ICBM_RFPRepository cBM_RFPRepository;
        private readonly IVoucherRepository voucherRepository;
        private readonly ICurrentUserService currentUserService;
        private readonly IGeneralConfigurationService generalConfigurationService;
        private readonly IVoucherGeneralInfoRepository voucherGeneralInfoRepository;

        public APM_Invoice_MainService(IAPM_Invoice_MainRepository _aPM_Invoice_MainRepository, IMapper _mapper
            , ICBM_RFPRepository _cBM_RFPRepository, IVoucherRepository _voucherRepository, ICurrentUserService _currentUserService,
            IGeneralConfigurationService _generalConfigurationService, IVoucherGeneralInfoRepository _voucherGeneralInfoRepository)
        {
            aPM_Invoice_MainRepository = _aPM_Invoice_MainRepository;
            mapper = _mapper;
            cBM_RFPRepository = _cBM_RFPRepository;
            voucherRepository = _voucherRepository;
            currentUserService = _currentUserService;
            generalConfigurationService = _generalConfigurationService;
            voucherGeneralInfoRepository = _voucherGeneralInfoRepository;
        }

        public async Task<string> GetInvoiceSystemID(int companyID)
        {
            return await aPM_Invoice_MainRepository.GetInvoiceSystemID(companyID);
        }

        public async Task<List<APMVendorVoucherResponseModel>> GetVendorVoucher(int accountId, DateTime dateFrom, DateTime dateTo, string poNumber)
        {
            return await aPM_Invoice_MainRepository.GetVendorVoucher(accountId, dateFrom, dateTo, poNumber);
        }

        public async Task<RResult> SaveVoucherInvoiceMap(VoucherInvoiceMapDTM model, CancellationToken cancellationToken)
        {
            var result = new RResult();
            string message = "";
            var businessID = currentUserService.BusinessID;
            var companyID = currentUserService.CompanyID;
            var locationID = model.CBM_RFP.LocationID;
            var dbInvoice = mapper.Map<APM_Invoice_MainDTM, APM_Invoice_Main>(model.APM_Invoice_Main);
            dbInvoice.InvoiceSystemID = await aPM_Invoice_MainRepository.GetInvoiceSystemID(companyID);
            dbInvoice.TransactionTypeID = 1;// Payment
            dbInvoice.CompanyID = companyID;
            dbInvoice.PreparedBy = currentUserService.UserID;
            dbInvoice.PrepareDate = DateTime.Now;

            var transactionOptions = new TransactionOptions
            {
                IsolationLevel = IsolationLevel.ReadCommitted,
                Timeout = TransactionManager.DefaultTimeout
            };
            using (var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled))
            {

                #region Generate Discount Voucher 
                if (model.DebitNoteAmount < 0)
                {
                    var activityID = await generalConfigurationService.GetDefaultAccountID(GeneralConfigurationParameter.DefaultActivity, businessID, GeneralConfigurationPageName.InvoiceMap);
                    var costCenterID = await generalConfigurationService.GetDefaultAccountID(GeneralConfigurationParameter.DefaultCostCenter, businessID, GeneralConfigurationPageName.InvoiceMap);
                    var voucherDate = DateTime.Now.Date;
                    var voucherNumber = await voucherRepository.GenerateVoucherNumber(locationID, (int)Enum_VoucherType.DN, companyID, businessID, voucherDate);
                    var dbVoucher = mapper.Map<VoucherDTM, Voucher>(model.Voucher);
                    dbVoucher.VoucherType = (int)Enum_VoucherType.DN;
                    dbVoucher.VoucherDate = voucherDate;
                    dbVoucher.VoucherNumber = voucherNumber.Item1;
                    dbVoucher.CompanyID = companyID;
                    dbVoucher.BusinessID = businessID;
                    dbVoucher.PreparedBy = currentUserService.UserID;
                    dbVoucher.PrepareDate = DateTime.Now;
                    dbVoucher.FiscalYear = voucherNumber.Item3;
                    dbVoucher.IndividualVoucherID = voucherNumber.Item2;
                    dbVoucher.RDate = DateTime.Now;
                    dbVoucher.SubVoucherType = 1;
                    dbVoucher.SystemVoucher = 0;
                    dbVoucher.VoucherDetail.ToList().ForEach(b => { b.Costcenter = costCenterID; b.Activity = activityID; });
                    await voucherRepository.InsertAsync(dbVoucher, true);
                    message = $"Discount Voucher Number : {dbVoucher.VoucherNumber}.\n";
                    dbInvoice.APM_Invoice_Detail.Add(new APM_Invoice_Detail
                    {
                        VoucherID = dbVoucher.VoucherID,
                        InvoiceEffect = 1,
                        CreatedBy = currentUserService.UserID,
                        CreatedDate = DateTime.Now,
                        IsActive = true,
                        IsRemoved = false,

                    });

                }
                #endregion

             var    inv_result = await aPM_Invoice_MainRepository.SaveAPMInvoice(dbInvoice);
                var rtnInvoiceID = inv_result.LongID; 

                //VoucherGeneralInfo Update 
                var voucherIDList = dbInvoice.APM_Invoice_Detail.Select(s => new
                {
                    VoucherID = s.VoucherID
                }).Distinct().ToList();

                foreach (var item in voucherIDList)
                {
                    var voucherGeneralListObj = await voucherGeneralInfoRepository.FindAllAsync(b => b.VoucherID == item.VoucherID, cancellationToken) as List<VoucherGeneralInfo>;
                    if (voucherGeneralListObj.Count() > 0)
                    {
                        voucherGeneralListObj.ToList().ForEach(v => { v.InvoiceEffect = 1; });
                        await voucherGeneralInfoRepository.UpdateVoucherGeneral(voucherGeneralListObj);
                    }
                }

                var dbCbmRFP = mapper.Map<CBM_RFP_DTM, CBM_RFP>(model.CBM_RFP);
                dbCbmRFP.RFPNum = await cBM_RFPRepository.GetRFPNumber(locationID, businessID, companyID, dbCbmRFP.RFPDate);
                dbCbmRFP.BusinessID = businessID;
                dbCbmRFP.CompanyID = companyID;
                var cBMRfDetailList = new List<CBM_RFP_Detail>();
                var CbmRfp = new CBM_RFP_Detail()
                {
                    InvoiceID = rtnInvoiceID,
                };
                cBMRfDetailList.Add(CbmRfp);
                dbCbmRFP.CBM_RFP_Detail = cBMRfDetailList;

                var rtnCbmRfp = await cBM_RFPRepository.InsertAsync(dbCbmRFP, true);
                transactionScope.Complete();
                result.result = 1;
                message +=$"Invoice Number : {dbInvoice.InvoiceSystemID}";
                result.message = message;
               
            } 
            return result;
        }
    }
}
