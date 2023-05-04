using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.CBMRFPs.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
   public interface IAPM_Invoice_MainRepository:IGenericRepository<APM_Invoice_Main>
    {
        Task<string> GetInvoiceSystemID(int companyID);
        Task<string> GetInvoiceNumber(int companyID, long voucherID);
        Task<RResult> SaveAPMInvoice(APM_Invoice_Main model);
        Task<CBM_RFPRelatedDataResponseModel> GetCBM_RFPRelatedDataByInvoiceID(long invoiceID);
        Task<List<APMVendorVoucherResponseModel>> GetVendorVoucher(int accountId, DateTime dateFrom, DateTime dateTo, string poNumber);
    }
}
