using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries
{
  public  class GetCostCenterListQuery:IRequest<List<CostAndActivityCenterResponseModel>>
    {
        public ChartOfAccountRequestModel RequestModel { get; set; }
    }
    public class GetCostCenterListQueryHandler : IRequestHandler<GetCostCenterListQuery, List<CostAndActivityCenterResponseModel>>
    {
        private readonly IBasicCOAService basicCOAService;

        public GetCostCenterListQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<List<CostAndActivityCenterResponseModel>> Handle(GetCostCenterListQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.GetCostCenterList(request.RequestModel,cancellationToken);
        }
    }
}
