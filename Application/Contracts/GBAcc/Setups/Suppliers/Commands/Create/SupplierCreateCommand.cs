using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Suppliers.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Suppliers.Commands.Create
{
   public class SupplierCreateCommand:IRequest<RResult>
    {
        public SupplierDTM SupplierDTM { get; set; }
    }
    public class SupplierCreateCommandHandler : IRequestHandler<SupplierCreateCommand, RResult>
    {
        private readonly ISupplierService supplierService;

        public SupplierCreateCommandHandler(ISupplierService _supplierService)
        {
            supplierService = _supplierService;
        }
        public async Task<RResult> Handle(SupplierCreateCommand request, CancellationToken cancellationToken)
        {
            return await supplierService.SupplierSave(request.SupplierDTM);
        }
    }
}
