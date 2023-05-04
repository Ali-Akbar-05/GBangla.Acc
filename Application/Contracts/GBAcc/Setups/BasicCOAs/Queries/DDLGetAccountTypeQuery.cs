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
   public class DDLGetAccountTypeQuery:IRequest<List<SelectListItem>>
    {
        public string Predict { get; set; }
    }
    public class DDLGetAccountTypeQueryHandler : IRequestHandler<DDLGetAccountTypeQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService basicCOAService;

        public DDLGetAccountTypeQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetAccountTypeQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.DDLAccountType(request.Predict, cancellationToken);
        }
    }
}
