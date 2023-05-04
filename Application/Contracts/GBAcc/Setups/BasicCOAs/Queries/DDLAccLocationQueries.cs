using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.BasicCOAs.Queries
{
    public class DDLAccLocationQueries : IRequest<List<SelectListItem>>
    {
        public int ParentID { get; set; }
        public int CompanyID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLAccLocationQueriesHandler : IRequestHandler<DDLAccLocationQueries, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLAccLocationQueriesHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLAccLocationQueries request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLAccLocation(request.ParentID,request.CompanyID,request.Predict,cancellationToken);
        }
    }
}
