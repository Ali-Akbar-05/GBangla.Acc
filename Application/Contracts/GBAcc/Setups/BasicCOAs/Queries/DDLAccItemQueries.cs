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
    public class DDLAccItemQueries :IRequest<List<SelectListItem>>
    {
        public int ParentID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLAccItemQueriesHandler : IRequestHandler<DDLAccItemQueries, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLAccItemQueriesHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLAccItemQueries request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLAccItem(request.ParentID, request.Predict,cancellationToken);
        }
    }
}
