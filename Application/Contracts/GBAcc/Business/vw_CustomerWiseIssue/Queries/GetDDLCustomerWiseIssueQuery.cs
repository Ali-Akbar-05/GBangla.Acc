using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.vw_CustomerWiseIssue.Queries
{
    public class GetDDLCustomerWiseIssueQuery:IRequest<List<SelectListItem>>
    {
        public int CustomerID { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public string Predict { get; set; }
    }
    public class GetDDLCustomerWiseIssueQueryHandler : IRequestHandler<GetDDLCustomerWiseIssueQuery, List<SelectListItem>>
    {
        private readonly Ivw_CustomerWiseIssueService customerWiseIssueService;

        public GetDDLCustomerWiseIssueQueryHandler(Ivw_CustomerWiseIssueService _customerWiseIssueService)
        {
            customerWiseIssueService = _customerWiseIssueService;
        }
        public async Task<List<SelectListItem>> Handle(GetDDLCustomerWiseIssueQuery request, CancellationToken cancellationToken)
        {
            return await customerWiseIssueService.DDLCustomerWiseIssue(request.CustomerID, request.DateFrom, request.DateTo, request.Predict,cancellationToken);
        }
    }
}
