using Application.Common.CommonModels;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.Update
{
   public class CBM_BranchRemoveCommand:IRequest<RResult>
    {
        public int BranchID { get; set; }
    }
    public class CBM_BranchRemoveCommandHandler : IRequestHandler<CBM_BranchRemoveCommand, RResult>
    {
        private readonly ICBM_BranchService cBM_BranchService;

        public CBM_BranchRemoveCommandHandler(ICBM_BranchService _cBM_BranchService)
        {
            cBM_BranchService = _cBM_BranchService;
        }
        public async  Task<RResult> Handle(CBM_BranchRemoveCommand request, CancellationToken cancellationToken)
        {
            return await cBM_BranchService.BranchDelete(request.BranchID);
        }
    }
}
