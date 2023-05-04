using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMPrintedChequeStatus.Queries
{
   public class DDLGetCBMPrintedChequeStatusQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLGetCBMPrintedChequeStatusQueryHandler : IRequestHandler<DDLGetCBMPrintedChequeStatusQuery, List<SelectListItem>>
    {
        private readonly ICBM_PrintedChequeStatusService cBM_PrintedChequeStatusService;

        public DDLGetCBMPrintedChequeStatusQueryHandler(ICBM_PrintedChequeStatusService _cBM_PrintedChequeStatusService)
        {
            cBM_PrintedChequeStatusService = _cBM_PrintedChequeStatusService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetCBMPrintedChequeStatusQuery request, CancellationToken cancellationToken)
        {
            return await cBM_PrintedChequeStatusService.DDLGetCBMPrintedChequeStatus(cancellationToken);
        }
    }
}
