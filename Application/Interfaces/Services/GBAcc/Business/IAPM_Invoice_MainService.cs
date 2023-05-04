using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.DataTransferModel;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
   public interface IAPM_Invoice_MainService
    {
        Task<string> GetInvoiceSystemID(int companyID);
        //Task<RResult> SaveAPMInvoice(APM_Invoice_Main model);
        Task<List<APMVendorVoucherResponseModel>> GetVendorVoucher(int accountId, DateTime dateFrom, DateTime dateTo, string poNumber);
        Task<RResult> SaveVoucherInvoiceMap(VoucherInvoiceMapDTM model,CancellationToken cancellationToken);
    }
}
