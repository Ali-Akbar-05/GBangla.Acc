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
    public class DDLAccBroadGroupQueries :IRequest<List<SelectListItem>>
    {
        public int ParentID { get; set; }
    }
    public class DDLAccBroadGroupQueriesHandler : IRequestHandler<DDLAccBroadGroupQueries, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLAccBroadGroupQueriesHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLAccBroadGroupQueries request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLAccBroadGroup(request.ParentID, cancellationToken);
        }
    }
}
