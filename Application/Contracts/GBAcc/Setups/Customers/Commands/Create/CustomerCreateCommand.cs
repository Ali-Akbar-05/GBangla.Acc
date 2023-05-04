using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Customers.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Customers.Commands.Create
{
  public  class CustomerCreateCommand:IRequest<RResult>
    {
        public CustomerDTM CustomerDTM { get; set; }
    }
    public class CustomerCreateCommandHandler : IRequestHandler<CustomerCreateCommand, RResult>
    {
        private readonly ICustomerService customerService;

        public CustomerCreateCommandHandler(ICustomerService _customerService)
        {
            customerService = _customerService;
        }
        public async Task<RResult> Handle(CustomerCreateCommand request, CancellationToken cancellationToken)
        {
            return await customerService.CustomerSave(request.CustomerDTM);
        }
    }
}
