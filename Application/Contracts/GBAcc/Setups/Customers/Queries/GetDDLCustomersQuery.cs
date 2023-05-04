using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Customers.Queries
{
    public class GetDDLCustomersQuery : IRequest<List<SelectListItem>>
    {
        public string Predict { get; set; }
    }
    public class GetDDLCustomersQueryHandler : IRequestHandler<GetDDLCustomersQuery, List<SelectListItem>>
    {
        private readonly ICustomerService customerService;

        public GetDDLCustomersQueryHandler(ICustomerService _customerService)
        {
            customerService = _customerService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCustomersQuery request, CancellationToken cancellationToken)
        {
            return await customerService.DDLCustomer(request.Predict, cancellationToken);
        }
    }
}
