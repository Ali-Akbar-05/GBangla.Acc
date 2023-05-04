using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.CBMRFPs.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Constants;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class APM_Invoice_MainRepository : GenericRepository<APM_Invoice_Main>, IAPM_Invoice_MainRepository
    {
        private GBAccDbContext accDbContext;
        public APM_Invoice_MainRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }

        public async Task<string> GetInvoiceSystemID(int companyID)
        {
            var InvoiceSystemStringID = "";
            //   var invoiceNumber = "";

            var existinvoice = Convert.ToInt32(await accDbContext.APM_Invoice_Main
                                                   .Where(b => b.CompanyID == companyID && b.InvoiceDate.Year == DateTime.Now.Year)
                                                .MaxAsync(m => m.InvoiceSystemID));

            if (existinvoice == 0)
            {
                var dateLast2DigitStr = DateTime.Now.ToString("yy");
                dateLast2DigitStr = dateLast2DigitStr + "000001";
                var dateLast2Digit = Convert.ToInt32(dateLast2DigitStr);
                existinvoice = dateLast2Digit;
            }
            else
            {
                existinvoice += 1;
            }
            InvoiceSystemStringID = existinvoice.ToString("00000000");

            //var billNo= await (from vMD in accDbContext.VW_VoucherMD
            //                   join vgi in accDbContext.VoucherGeneralInfo on new { VoucherID = vMD.VoucherID, AccountID = vMD.AccountID, Vindex = vMD.Vindex }
            //                   equals new { VoucherID = vgi.VoucherID, AccountID = vgi.AccountID, Vindex = vgi.VIndex }
            //                   where vMD.VoucherID == voucherID && vMD.CompanyID==companyID && vMD.Amount > 0
            //                   select new 
            //                   {
            //                         InvoiceNumber=vgi.Billno==null?vMD.VoucherNumber: vgi.Billno

            //                   }).FirstAsync();
            //invoiceNumber = billNo.InvoiceNumber;

            return InvoiceSystemStringID;
        }
        public async Task<string> GetInvoiceNumber(int companyID, long voucherID)
        {
            var invoiceNumber = "";
            var billNo = await (from vMD in accDbContext.vw_VoucherMD
                                join vgi in accDbContext.VoucherGeneralInfo on new { VoucherID = vMD.VoucherID, AccountID = vMD.AccountID, Vindex = vMD.Vindex }
                                equals new { VoucherID = vgi.VoucherID, AccountID = vgi.AccountID, Vindex = vgi.VIndex }
                                where vMD.VoucherID == voucherID && vMD.CompanyID == companyID && vMD.Amount > 0
                                select new
                                {
                                    InvoiceNumber = vgi.Billno == null ? vMD.VoucherNumber : vgi.Billno

                                }).FirstAsync();
            invoiceNumber = billNo.InvoiceNumber;
            return invoiceNumber;
        }
        public async Task<RResult> SaveAPMInvoice(APM_Invoice_Main model)
        {
            try
            {
                var result = new RResult();
                await accDbContext.APM_Invoice_Main.AddAsync(model);
                await accDbContext.SaveChangesAsync();
                result.result = 1;
                result.LongID = model.InvoiceID;
                result.message = ReturnMessage.SaveMessage;
                return result;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }

        public async Task<CBM_RFPRelatedDataResponseModel> GetCBM_RFPRelatedDataByInvoiceID(long invoiceID)
        {
            var rtnObj = await (from vwi in accDbContext.vw_Invoice
                                join apmIn in accDbContext.APM_Invoice_Main on new { InvoiceID = vwi.InvoiceID, InvoiceNumber = vwi.InvoiceNumber.Trim(), SupplierID = vwi.SupplierID, IsRemove = false }
                                equals new { InvoiceID = apmIn.InvoiceID, InvoiceNumber = apmIn.InvoiceNumber.Trim(), SupplierID = apmIn.SupplierID, IsRemove = apmIn.IsRemoved }
                                where apmIn.InvoiceID == invoiceID
                                select new CBM_RFPRelatedDataResponseModel()
                                {
                                    NetAmount = vwi.InvoiceAmount,
                                    SupplierID = vwi.SupplierID,
                                    CompanyID = vwi.CompanyID,
                                    CreationBy = apmIn.PreparedBy,
                                    CreationDate = vwi.PrepareDate,
                                }).FirstAsync();
            return rtnObj;

        }

        public async Task<List<APMVendorVoucherResponseModel>> GetVendorVoucher(int accountId, DateTime dateFrom, DateTime dateTo, string poNumber)
        {
            var vandorVoucherList = new List<APMVendorVoucherResponseModel>();

            await accDbContext.LoadStoredProc("Ajt.USP_GetAPM_VendorVoucher", commandTimeout: 300)
                .WithSqlParam("VendorID", accountId)
                 .WithSqlParam("DateFrom", dateFrom)
                  .WithSqlParam("DateTo", dateTo)
                   .WithSqlParam("PONum", poNumber)
                .ExecuteStoredProcAsync((handler) =>
                {
                    vandorVoucherList = handler.ReadToList<APMVendorVoucherResponseModel>() as List<APMVendorVoucherResponseModel>;

                });
            return vandorVoucherList;

        }

    }
}
