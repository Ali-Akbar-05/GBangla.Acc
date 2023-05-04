using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Signatores.Queries
{
   public class DDLGetSignatoryListQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLGetSignatoryListQueryHandler : IRequestHandler<DDLGetSignatoryListQuery, List<SelectListItem>>
    {
        private readonly ISignatoryService signatoryService;

        public DDLGetSignatoryListQueryHandler(ISignatoryService _signatoryService)
        {
            signatoryService = _signatoryService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetSignatoryListQuery request, CancellationToken cancellationToken)
        {
            return await signatoryService.DDLGetSignatoryList(cancellationToken);
        }
    }
}
