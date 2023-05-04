using Application.Common.DevExtremeModelBinds;
using Application.Contracts.GBAcc.Setups.BasicCOAs.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Data.ResponseModel;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries
{
   public class GetChartOfAccountListQuery :IRequest<LoadResult>
    {
        public ChartOfAccountRequestModel ReqModel { get; set; }
        public DataSourceLoadOptions loadOptions { get; set; }
    }

    public class GetChartOfAccountListQueryHandler : IRequestHandler<GetChartOfAccountListQuery, LoadResult>
    {
        private readonly IBasicCOAService _basicCOAService;
        public GetChartOfAccountListQueryHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async  Task<LoadResult> Handle(GetChartOfAccountListQuery request, CancellationToken cancellationToken)
        {
             
            request.loadOptions.PrimaryKey = new[] { "Serial" };
            request.loadOptions.PaginateViaPrimaryKey = true;
            var dataQuery = _basicCOAService.GetChartOfAccountList(request.ReqModel);
            var data = await DataSourceLoader.LoadAsync(dataQuery, request.loadOptions, cancellationToken);
            return data;
        }
    }
}
