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

namespace Application.Contracts.GBAcc.Setups.Suppliers.Commands.Update
{
  public   class SupplierUpdateCommand:IRequest<RResult>
    {
        public SupplierDTM SupplierDTM { get; set; }
    }
    public class SupplierUpdateCommandHandler : IRequestHandler<SupplierUpdateCommand, RResult>
    {
        private readonly ISupplierService supplierService;

        public SupplierUpdateCommandHandler(ISupplierService _supplierService)
        {
            supplierService = _supplierService;
        }
        public async Task<RResult> Handle(SupplierUpdateCommand request, CancellationToken cancellationToken)
        {
            return await supplierService.SupplierUpdate(request.SupplierDTM, cancellationToken);
        }
    }
}
