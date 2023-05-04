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
    public class DDLSupplierQueries : IRequest<List<SelectListItem>>
    {
        public int[] ParentList { get; set; }
        public int CompanyID { get; set; }
        public string Predict { get; set; }
    }
    public class DDLSupplierQueriesHandler : IRequestHandler<DDLSupplierQueries, List<SelectListItem>>
    {
        private readonly IBasicCOAService _basicCOAService;

        public DDLSupplierQueriesHandler(IBasicCOAService basicCOAService)
        {
            _basicCOAService = basicCOAService;
        }
        public async Task<List<SelectListItem>> Handle(DDLSupplierQueries request, CancellationToken cancellationToken)
        {
            return await _basicCOAService.DDLSupplier(request.ParentList,request.CompanyID,request.Predict,cancellationToken);
        }
    }
}
