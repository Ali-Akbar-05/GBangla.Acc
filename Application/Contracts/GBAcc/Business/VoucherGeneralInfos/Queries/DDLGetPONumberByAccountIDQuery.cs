using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.VoucherGeneralInfos.Queries
{
   public class DDLGetPONumberByAccountIDQuery:IRequest<List<SelectListItem>>
    {
        public int AccountID { get; set; }
        public string Predict { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
    public class DDLGetPONumberByAccountIDQueryHandler : IRequestHandler<DDLGetPONumberByAccountIDQuery, List<SelectListItem>>
    {
        private readonly IVoucherGeneralInfoService voucherGeneralInfoService;

        public DDLGetPONumberByAccountIDQueryHandler(IVoucherGeneralInfoService _voucherGeneralInfoService)
        {
            voucherGeneralInfoService = _voucherGeneralInfoService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetPONumberByAccountIDQuery request, CancellationToken cancellationToken)
        {
            return await voucherGeneralInfoService.DDlGetPONumberByAccountID(request.AccountID, request.DateFrom, request.DateTo, request.Predict, cancellationToken);
        }
    }
}
