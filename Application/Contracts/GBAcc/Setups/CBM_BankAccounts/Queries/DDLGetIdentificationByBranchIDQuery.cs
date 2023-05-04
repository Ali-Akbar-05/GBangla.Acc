using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries
{
   public class DDLGetIdentificationByBranchIDQuery:IRequest<List<SelectListItem>>
    {
        public int BranchID { get; set; }
    }
    public class DDLGetIdentificationByBranchIDQueryHandler : IRequestHandler<DDLGetIdentificationByBranchIDQuery, List<SelectListItem>>
    {
        private readonly ICBM_BankAccountService iCBM_BankAccountService;

        public DDLGetIdentificationByBranchIDQueryHandler(ICBM_BankAccountService _iCBM_BankAccountService)
        {
            iCBM_BankAccountService = _iCBM_BankAccountService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetIdentificationByBranchIDQuery request, CancellationToken cancellationToken)
        {
            return await iCBM_BankAccountService.GetIdentification(request.BranchID, cancellationToken);
        }
    }
}
