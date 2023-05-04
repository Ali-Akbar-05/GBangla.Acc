using Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.APMInvoiceMain.Queries
{
   public class GetVendorVoucherListQuery:IRequest<List<APMVendorVoucherResponseModel>>
    {
        public int VendorID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string PONumber { get; set; }
    }
    public class GetVendorVoucherListQueryHandler : IRequestHandler<GetVendorVoucherListQuery, List<APMVendorVoucherResponseModel>>
    {
        private readonly IAPM_Invoice_MainService iAPM_Invoice_MainService;

        public GetVendorVoucherListQueryHandler(IAPM_Invoice_MainService _iAPM_Invoice_MainService)
        {
            iAPM_Invoice_MainService = _iAPM_Invoice_MainService;
        }
        public async Task<List<APMVendorVoucherResponseModel>> Handle(GetVendorVoucherListQuery request, CancellationToken cancellationToken)
        {
            return await iAPM_Invoice_MainService.GetVendorVoucher(request.VendorID, request.DateFrom, request.DateTo, request.PONumber);
        }
    }
}
