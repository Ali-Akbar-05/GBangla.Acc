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
    public class DDLAccNarrowGroupQueries :IRequest<List<SelectListItem>>
    {
        public int ParentID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLAccNarrowGroupQueriesHandler : IRequestHandler<DDLAccNarrowGroupQueries, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLAccNarrowGroupQueriesHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLAccNarrowGroupQueries request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLAccNarrowGroup(request.ParentID, request.Predict,cancellationToken);
        }
    }
}
