using Application.Contracts.GBAcc.Setups.Suppliers.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Suppliers.Queries
{
   public class GetSupplierBySupplierIDQuery:IRequest<SupplierDTM>
    {
        public int SupplierID { get; set; }
    }
    public class GetSupplierBySupplierIDQueryHandler : IRequestHandler<GetSupplierBySupplierIDQuery, SupplierDTM>
    {
        private readonly ISupplierService supplierService;

        public GetSupplierBySupplierIDQueryHandler(ISupplierService _supplierService)
        {
            supplierService = _supplierService;
        }
        public async Task<SupplierDTM> Handle(GetSupplierBySupplierIDQuery request, CancellationToken cancellationToken)
        {
            return await supplierService.GetSupplierBySupplierID(request.SupplierID, cancellationToken);
        }
    }
}
