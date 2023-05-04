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
    public class DDLAccCategoryQueries :IRequest<List<SelectListItem>>
    {
        public int CompanyID { get; set; }
    }
    public class DDLAccCategoryQueriesHandler : IRequestHandler<DDLAccCategoryQueries, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLAccCategoryQueriesHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLAccCategoryQueries request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLAccCategory(request.CompanyID,cancellationToken);
        }
    }
}
