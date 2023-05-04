using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Contracts.GBAcc.Business.Vouchers.Queries.RequestResponseModel;
using Domain.Entities.GBAcc;
using Domain.Entities.GBAcc.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Business
{
    public interface IVoucherRepository :IGenericRepository<Voucher>
    {
        /// <summary>
        /// Return: Voucher Number,VoucherSerial,Fiscal Year
        /// </summary>
        /// <param name="LocationID"></param>
        /// <param name="VoucherTypeID"></param>
        /// <param name="CompanyID"></param>
        /// <param name="BusinessID"></param>
        /// <param name="VMonth"></param>
        /// <param name="VYear"></param>
        /// <returns> 1. Voucher Number , 2. VoucherSerial, 3. Fiscal Year</returns>
        Task<(string,int,string)> GenerateVoucherNumber(int LocationID,int VoucherTypeID,int CompanyID,int BusinessID,DateTime VoucherDate);
        Task<RResult> SaveSupplierInvoiceVoucher(Voucher model);
        Task<InvoiceRelatedDataResponseModel> GetInvoiceRelatedDataByVoucherID(long voucherID);
        Task<RResult> SaveBankPaymentVoucher(Voucher model,CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetDateWiseVoucherNumber(int companyID, int businessID,  DateTime dateFrom, DateTime dateTo, int voucherType = 0);

        Task<List<CBMAdvancePayment>> GetVoucherDetailsForAdvancePayment(long VoucherID, CancellationToken cancellationToken);
        Task<List<CBM_ReportListResponseModel>> GetVoucherListForReport(long voucherID, int voucherType, DateTime dateFrom, DateTime dateTo, CancellationToken cancellationToken);

    }
}
