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

namespace Application.Contracts.GBAcc.Setups.Customers.Commands.Update
{
  public  class CustomerUpdateCommand:IRequest<RResult>
    {
        public CustomerDTM CustomerDTM { get; set; }
    }
    public class CustomerUpdateCommandHanler : IRequestHandler<CustomerUpdateCommand, RResult>
    {
        private readonly ICustomerService customerService;

        public CustomerUpdateCommandHanler(ICustomerService _customerService)
        {
            customerService = _customerService;
        }
        public async Task<RResult> Handle(CustomerUpdateCommand request, CancellationToken cancellationToken)
        {
            return await customerService.CustomerUpdate(request.CustomerDTM);
        }
    }
}
