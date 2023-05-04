using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.Vouchers.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Business.Vouchers.Queries.RequestResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
   public interface IVoucherService
    {
        //  Task<IList<Voucher>> FindAllAsync(Expression<Func<Voucher, bool>> match);
        Task<RResult> SaveSupplierInvoiceVoucher(VoucherDTM model);
        // Task<InvoiceRelatedDataResponseModel> GetInvoiceRelatedDataByVoucherID(long voucherID);
       Task<RResult> SaveBankPaymentVoucher(BankVouchersDTM model,CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDateWiseVoucherNumber(int companyID, int businessID, DateTime dateFrom, DateTime dateTo, int voucherType = 0);
        Task<List<CBM_ReportListResponseModel>> GetVoucherListForReport(long voucherID, int voucherType, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);
    }
}
