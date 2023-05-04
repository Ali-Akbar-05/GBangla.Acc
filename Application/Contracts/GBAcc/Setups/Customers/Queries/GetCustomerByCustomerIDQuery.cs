using Application.Contracts.GBAcc.Setups.Customers.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Customers.Queries
{
   public class GetCustomerByCustomerIDQuery:IRequest<CustomerDTM>
    {
        public int CustomerID { get; set; }
    }
    public class GetCustomerByCustomerIDQueryHandler : IRequestHandler<GetCustomerByCustomerIDQuery, CustomerDTM>
    {
        private readonly ICustomerService customerService;

        public GetCustomerByCustomerIDQueryHandler(ICustomerService _customerService)
        {
            customerService = _customerService;
        }
        public async Task<CustomerDTM> Handle(GetCustomerByCustomerIDQuery request, CancellationToken cancellationToken)
        {
            return await customerService.GetCustomerByCustomerID(request.CustomerID, cancellationToken);
        }
    }
}
