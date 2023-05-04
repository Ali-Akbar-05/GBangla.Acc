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
  public  class DDLAccountItemListQuery:IRequest<List<SelectListItem>>
    {
        public int[] ParentList { get; set; }
        public int CompanyID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLAccountItemListQueryHandler : IRequestHandler<DDLAccountItemListQuery, List<SelectListItem>>
    {
        private readonly IBasicCOAService basicCOAService;

        public DDLAccountItemListQueryHandler(IBasicCOAService _basicCOAService)
        {
            basicCOAService = _basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLAccountItemListQuery request, CancellationToken cancellationToken)
        {
            return await basicCOAService.DDLAccountItemList(request.ParentList, request.CompanyID, request.Predict, cancellationToken);
        }
    }
}
