using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries
{
  public  class CBMPrintedChequesQuery:IRequest<List<PrintedChequesResponseModel>>
    {
        public PrintedChequesRequestModel ReqModel { get; set; }
    }
    public class CBMPrintedChequesQueryHandler : IRequestHandler<CBMPrintedChequesQuery, List<PrintedChequesResponseModel>>
    {
        private readonly ICBM_PrintedChequeService cBM_PrintedChequeService;

        public CBMPrintedChequesQueryHandler(ICBM_PrintedChequeService _cBM_PrintedChequeService)
        {
            cBM_PrintedChequeService = _cBM_PrintedChequeService;
        }
        public async Task<List<PrintedChequesResponseModel>> Handle(CBMPrintedChequesQuery request, CancellationToken cancellationToken)
        {
            return await cBM_PrintedChequeService.GetCBM_PrintedCheques(request.ReqModel, cancellationToken);
        }
    }
}
