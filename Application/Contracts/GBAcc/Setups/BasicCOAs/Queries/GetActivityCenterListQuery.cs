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
  public  class GetActivityCenterListQuery:IRequest<List<CostAndActivityCenterResponseModel>>
    {
        public ChartOfAccountRequestModel RequestModel { get; set; }
    }
    public class GetActivityCenterListQueryHandler : IRequestHandler<GetActivityCenterListQuery, List<CostAndActivityCenterResponseModel>>
    {
        private readonly IBasicCOAService basicCOAService;

        public GetActivityCenterListQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<List<CostAndActivityCenterResponseModel>> Handle(GetActivityCenterListQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.GetActivityCenterList(request.RequestModel, cancellationToken);
        }
    }
}
