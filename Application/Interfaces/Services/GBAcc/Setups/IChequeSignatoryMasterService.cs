using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
    public interface IChequeSignatoryMasterService
    {
        Task<List<SelectListItem>> DDLChequeSignatoryMasterList(int companyID, CancellationToken cancellationToken);
    }
}
