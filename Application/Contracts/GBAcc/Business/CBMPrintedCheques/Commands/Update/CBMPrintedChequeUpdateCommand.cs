using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.CBMPrintedCheques.Commands.Update
{
   public class CBMPrintedChequeUpdateCommand:IRequest<RResult>
    {
        public List<CBM_PrintedChequeDTM> CBM_PrintedCheque { get; set; }
    }
    public class CBMPrintedChequeUpdateCommandHandler : IRequestHandler<CBMPrintedChequeUpdateCommand, RResult>
    {
        private readonly ICBM_PrintedChequeService iCBM_PrintedChequeService;

        public CBMPrintedChequeUpdateCommandHandler(ICBM_PrintedChequeService _iCBM_PrintedChequeService)
        {
            iCBM_PrintedChequeService = _iCBM_PrintedChequeService;
        }
        public async Task<RResult> Handle(CBMPrintedChequeUpdateCommand request, CancellationToken cancellationToken)
        {
            return await iCBM_PrintedChequeService.UpdatePrintedCheque(request.CBM_PrintedCheque);
        }
    }
}
