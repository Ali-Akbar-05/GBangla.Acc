using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.Vouchers.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Constants;
using Domain.Entities.GBAcc;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class VoucherRepository : GenericRepository<Voucher>, IVoucherRepository
    {
        private readonly GBAccDbContext accDbContext;
      
        public VoucherRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
          
        }

        public async Task<(string, int,string)> GenerateVoucherNumber(int LocationID,int VoucherTypeID, int CompanyID, int BusinessID, DateTime VoucherDate)
        {
            string rtnVoucherNumber = "";
            int rtnIndividualVoucherNumber = 0;
 
            var fiscalYearInfo = await accDbContext.FiscalYear.FirstAsync();
            var locationInfo = await accDbContext.Location.Where(b => b.SrNum == LocationID && b.IsRemoved==false && b.IsActive==true).FirstAsync();
            var voucherTypeinfo = await accDbContext.VoucherTypes.Where(b => b.ID == VoucherTypeID && b.IsRemoved == false && b.IsActive == true).FirstAsync();
            DateTime VoucherNumberDate = VoucherDate;
            string strVoucherNumberDate = "";

            string FiscalYear = "";
            int VMonth = VoucherDate.Month;
            int VYear = VoucherDate.Year;
            
            #region Finincial Year Duration
            if (VoucherDate.Month < fiscalYearInfo.StartMonth)
            {
                FiscalYear = $"{VoucherDate.AddYears(-1).Year}-{VoucherDate.Year}";
            }
            else
            {
                FiscalYear = $"{VoucherDate.Year}-{VoucherDate.AddYears(1).Year}";
            }
            #endregion Finincial Year Duration

            if (VMonth < fiscalYearInfo.StartMonth)
            {
               VoucherNumberDate = VoucherNumberDate.AddYears(-1);
                strVoucherNumberDate = VoucherNumberDate.Year.ToString().Substring(2);
            }
            else
            {
                strVoucherNumberDate = VoucherNumberDate.Year.ToString().Substring(2);

            }

            var existVoucherQuery =await accDbContext.Voucher.Where(b => b.CompanyID == CompanyID
               && b.VoucherType==VoucherTypeID
               && b.BusinessID == BusinessID
               && b.FiscalYear==FiscalYear)
               .MaxAsync(b=>b.IndividualVoucherID);
            
            if(existVoucherQuery==null || existVoucherQuery == 0)
            {
                rtnIndividualVoucherNumber = 1;
            }
            else
            {
                rtnIndividualVoucherNumber = existVoucherQuery.Value+1;
            }

            rtnVoucherNumber = $"{voucherTypeinfo.Initials}\\{locationInfo.LocationInitials}\\{strVoucherNumberDate}\\{rtnIndividualVoucherNumber.ToString("000000")}";
            return (rtnVoucherNumber,rtnIndividualVoucherNumber,FiscalYear);
        }

        public async Task<RResult> SaveSupplierInvoiceVoucher(Voucher model)
        {
            var result = new RResult();
            try
            {
                
                await accDbContext.Voucher.AddAsync(model);
                await accDbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

            result.result = 1;
            result.LongID = model.VoucherID;
            result.message = ReturnMessage.SaveMessage;
            return result;
        }

       public async Task<InvoiceRelatedDataResponseModel>GetInvoiceRelatedDataByVoucherID(long voucherID)
        {
            var rtnObj = await (from vMD in accDbContext.vw_VoucherMD
                                join vgi in accDbContext.VoucherGeneralInfo on new { VoucherID = vMD.VoucherID, AccountID = vMD.AccountID, Vindex = vMD.Vindex }
                                equals new { VoucherID = vgi.VoucherID, AccountID = vgi.AccountID, Vindex = vgi.VIndex }
                                where vgi.IsActive==true && vgi.IsRemoved==false &&  vMD.VoucherID == voucherID && vMD.Amount < 0
                                select new InvoiceRelatedDataResponseModel()
                                {
                                 InvoiceDate=vMD.VoucherDate,
                                 GrossAmount=vgi.GrossAmount.Value,
                                 NetAmount=vgi.NetAmount.Value,
                                 TaxRate=vgi.InTaxPercent==null?0: vgi.InTaxPercent.Value,
                                 PONum=vgi.ReferenceNo,
                                 SupplierID=vMD.AccountID,
                                 CompanyID=vMD.CompanyID,
                                 PreparedBy=vMD.PreparedBy.Value,
                                 PrepareDate=DateTime.Now,
                                 ExDtyRate=vgi.ExciseDuty,
                                 CurrencyRate=vgi.ConversionRate==null?1:vgi.ConversionRate,
                                 CurrencyID=vMD.CurrencyID,
                                 //AmtInDoller=
                                }).FirstAsync();
            return rtnObj;
                              
        }

        public async Task<RResult> SaveBankPaymentVoucher(Voucher model, CancellationToken cancellationToken)
        {
            RResult result = new RResult();
            accDbContext.Add(model);
            await accDbContext.SaveChangesAsync();
            result.result = 1;
            result.LongID = model.VoucherID;
            return result;
        }

        public async Task<List<CBMAdvancePayment>> GetVoucherDetailsForAdvancePayment(long VoucherID, CancellationToken cancellationToken)
        {
            var data =await accDbContext.VoucherDetail
                  .Where(b => b.VoucherID == VoucherID && b.EntryType == 1)
                  .Select(s => new CBMAdvancePayment()
                  {
                      AccountID = s.AccountID,
                      VoucherID = VoucherID,
                      VIndex = s.VIndex == null ? 0 : s.VIndex.Value,
                      VoucherDetailsID = s.VDetailsID
                  }).ToListAsync(cancellationToken);
            return data;
        }

        public async Task<List<SelectListItem>>GetDateWiseVoucherNumber(int companyID, int businessID, DateTime dateFrom,DateTime dateTo, int voucherType=0)
        {
            var listOfvoucherNumber = await (from v in accDbContext.Voucher
                                             join vd in accDbContext.VoucherDetail on v.VoucherID equals vd.VoucherID
                                             where v.IsActive == true && v.IsRemoved == false
                                             && vd.Status!=95
                                             && (v.VoucherDate >= dateFrom && v.VoucherDate <= dateTo)
                                             && v.BusinessID == businessID
                                             && v.CompanyID == companyID
                                             && (voucherType == 0 || v.VoucherType == voucherType)
                                             group new { v, vd } by new { v.VoucherNumber, v.VoucherID } into grpVoucher
                                             select new SelectListItem()
                                             {
                                                 Text = grpVoucher.Key.VoucherNumber,
                                                 Value = grpVoucher.Key.VoucherID.ToString()
                                             }).ToListAsync();
            return listOfvoucherNumber;
           
        }

        public async Task<List<CBM_ReportListResponseModel>>GetVoucherListForReport(long voucherID,int voucherType,DateTime dateFrom,DateTime dateTo, CancellationToken cancellationToken)
        {
            var voucherList = await( from v in accDbContext.Voucher
                             join vd in accDbContext.VoucherDetail on v.VoucherID equals vd.VoucherID
                             where vd.Status != 95
                             && (voucherType == 0 || v.VoucherType == voucherType)
                             && (voucherID == 0 || v.VoucherID == voucherID)
                             && (v.VoucherDate >= dateFrom && v.VoucherDate <= dateTo)
                             && v.IsActive==true && v.IsRemoved==false
                             group new {v,vd} by new {v.VoucherID,v.VoucherNumber,v.VoucherDate,v.VoucherType} into grpVoucher
                             select new CBM_ReportListResponseModel()
                             {
                                 VoucherID=grpVoucher.Key.VoucherID,
                                 VoucherNumber=grpVoucher.Key.VoucherNumber,
                                 VoucherDate=grpVoucher.Key.VoucherDate.ToString("dd-MMM-yyyy"),
                                VoucherType=grpVoucher.Key.VoucherType
                             }).ToListAsync(cancellationToken);
            return voucherList;



        }
    }
}