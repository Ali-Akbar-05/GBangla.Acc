using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class vw_CustomerWiseIssueService : Ivw_CustomerWiseIssueService
    {
        private readonly Ivw_CustomerWiseIssueRepository customerWiseIssueRepository;

        public vw_CustomerWiseIssueService(Ivw_CustomerWiseIssueRepository _customerWiseIssueRepository)
        {
            customerWiseIssueRepository = _customerWiseIssueRepository;
        }
        public async Task<List<SelectListItem>> DDLCustomerWiseIssue(int customerID, DateTime DateFrom, DateTime DateTo, string predict, CancellationToken cancellationToken)
        {
            return await customerWiseIssueRepository.DDLCustomerWiseIssue(customerID,DateFrom,DateTo, predict, cancellationToken);
        }
    }
}
