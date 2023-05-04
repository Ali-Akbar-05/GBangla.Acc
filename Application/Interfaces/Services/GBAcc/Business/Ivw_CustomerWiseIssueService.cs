using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
    public interface Ivw_CustomerWiseIssueService
    {
        Task<List<SelectListItem>> DDLCustomerWiseIssue(int customerID, DateTime DateFrom, DateTime DateTo, string predict, CancellationToken cancellationToken);
    }
}
