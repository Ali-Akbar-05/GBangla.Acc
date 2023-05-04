using Application.Contracts.GBAcc.Business.Vouchers.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Queries
{
   public class GetVoucherListForReportQuery:IRequest<List<CBM_ReportListResponseModel>>
    {
        public long VoucherID { get; set; }
        public int VoucherType { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
    public class GetVoucherListForReportQueryHandler : IRequestHandler<GetVoucherListForReportQuery, List<CBM_ReportListResponseModel>>
    {
        private readonly IVoucherService voucherService;

        public GetVoucherListForReportQueryHandler(IVoucherService _voucherService)
        {
            voucherService = _voucherService;
        }
        public async Task<List<CBM_ReportListResponseModel>> Handle(GetVoucherListForReportQuery request, CancellationToken cancellationToken)
        {
            return await voucherService.GetVoucherListForReport(request.VoucherID, request.VoucherType, request.DateFrom, request.DateTo, cancellationToken);
        }
    }
}
