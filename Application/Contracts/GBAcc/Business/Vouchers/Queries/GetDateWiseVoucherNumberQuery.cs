using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.Vouchers.Queries
{
  public  class GetDateWiseVoucherNumberQuery:IRequest<List<SelectListItem>>
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int CompanyID { get; set; }
        public int BusinessID { get; set; }
        public int VoucherType { get; set; }
    }
    public class GetDateWiseVoucherNumberQueryHandler : IRequestHandler<GetDateWiseVoucherNumberQuery, List<SelectListItem>>
    {
        private readonly IVoucherService voucherService;

        public GetDateWiseVoucherNumberQueryHandler(IVoucherService _voucherService)
        {
            voucherService = _voucherService;
        }
        public async Task<List<SelectListItem>> Handle(GetDateWiseVoucherNumberQuery request, CancellationToken cancellationToken)
        {

            return await voucherService.GetDateWiseVoucherNumber(request.CompanyID,  request.BusinessID, request.DateFrom, request.DateTo,request.VoucherType);
        }
    }
}
