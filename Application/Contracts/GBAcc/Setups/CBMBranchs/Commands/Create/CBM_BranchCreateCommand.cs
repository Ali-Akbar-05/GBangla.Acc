using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.Create
{
  public  class CBM_BranchCreateCommand:IRequest<RResult>
    {
        public CBM_BranchDTM CBM_BranchDTM { get; set; }
    }
    public class CBM_BranchCreateCommandHandler : IRequestHandler<CBM_BranchCreateCommand, RResult>
    {
        private readonly ICBM_BranchService cBM_BranchService;

        public CBM_BranchCreateCommandHandler(ICBM_BranchService _cBM_BranchService)
        {
            cBM_BranchService = _cBM_BranchService;
        }
        public async Task<RResult> Handle(CBM_BranchCreateCommand request, CancellationToken cancellationToken)
        {
            return await cBM_BranchService.BranchSave(request.CBM_BranchDTM);
        }
    }
}
