using Application.Contracts.GBAcc.Setups.CBMBranchs.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBMBranchs.Queries
{
  public  class GetCBMBranchListQuery:IRequest<List<CBM_BranchResponseModel>>
    {
    }
    public class GetCBMBranchListQueryHandler : IRequestHandler<GetCBMBranchListQuery, List<CBM_BranchResponseModel>>
    {
        private readonly ICBM_BranchService cBM_BranchService;

        public GetCBMBranchListQueryHandler(ICBM_BranchService _cBM_BranchService)
        {
            cBM_BranchService = _cBM_BranchService;
        }
        public async Task<List<CBM_BranchResponseModel>> Handle(GetCBMBranchListQuery request, CancellationToken cancellationToken)
        {
          return await  cBM_BranchService.GetCBMBranchList(cancellationToken);
        }
    }
}
