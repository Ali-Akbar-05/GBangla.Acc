using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Suppliers.Queries
{
   public class GetDDLSupplierListQuery:IRequest<List<SelectListItem>>
    {
        public string Pridict { get; set; }
    }
    public class GetDDLSupplierListQueryHandler : IRequestHandler<GetDDLSupplierListQuery, List<SelectListItem>>
    {
        private readonly ISupplierService supplierService;

        public GetDDLSupplierListQueryHandler(ISupplierService _supplierService)
        {
            supplierService = _supplierService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLSupplierListQuery request, CancellationToken cancellationToken)
        {
            return await supplierService.GetDDLSupplierList(request.Pridict, cancellationToken);
        }
    }
}
