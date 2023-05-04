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
    public class DDLGetAccBusinessQuery : IRequest<List<SelectListItem>>
    {
        public int ParentID { get; set; }
        public int CompanyID { get; set; }
        public int LevelID { get; set; }
    }
    public class DDLGetAccBusinessQueryHandler : IRequestHandler<DDLGetAccBusinessQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService basicCOAService;

        public DDLGetAccBusinessQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetAccBusinessQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.DDLAccBusiness(request.ParentID,request.LevelID, request.CompanyID, cancellationToken);
        }
    }
}
