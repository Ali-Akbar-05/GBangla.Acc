using Application.Contracts.GBAcc.Setups.Customers.Queries.RequestResponseModel;
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
   public class GetCustomerListListQuery:IRequest<List<CustomerResponseModel>>
    {
    }
    public class GetCustomerListListQueryHandler : IRequestHandler<GetCustomerListListQuery, List<CustomerResponseModel>>
    {
        private readonly ICustomerService customerService;

        public GetCustomerListListQueryHandler(ICustomerService _customerService)
        {
            customerService = _customerService;
        }
        public async Task<List<CustomerResponseModel>> Handle(GetCustomerListListQuery request, CancellationToken cancellationToken)
        {
            return await customerService.GetCustomerList(cancellationToken);
        }
    }
}
