using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries
{
   public class GetChartOfAccountByItemIDQuery:IRequest<ChartOfAccountListResponseModel>
    {
        public int AccID { get; set; }
    }
    public class GetChartOfAccountByItemIDQueryHandler : IRequestHandler<GetChartOfAccountByItemIDQuery, ChartOfAccountListResponseModel>
    {
        private readonly IBasicCOAService basicCOAService;

        public GetChartOfAccountByItemIDQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<ChartOfAccountListResponseModel> Handle(GetChartOfAccountByItemIDQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.GetChartOfAccountByItemID(request.AccID, cancellationToken);
        }
    }
}
