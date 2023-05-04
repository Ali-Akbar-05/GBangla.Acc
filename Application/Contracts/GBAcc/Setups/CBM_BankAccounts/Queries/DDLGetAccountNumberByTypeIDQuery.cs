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
  public  class DDLGetAccountNumberByTypeIDQuery:IRequest<List<SelectListItem>>
    {
        public int AccountTypeID { get; set; }
    }
    public class DDLGetAccountNumberByTypeIDQueryHandler : IRequestHandler<DDLGetAccountNumberByTypeIDQuery, List<SelectListItem>>
    {
        private readonly ICBM_BankAccountService cBM_BankAccountService;

        public DDLGetAccountNumberByTypeIDQueryHandler(ICBM_BankAccountService _cBM_BankAccountService)
        {
            cBM_BankAccountService = _cBM_BankAccountService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetAccountNumberByTypeIDQuery request, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountService.GetAccountNumberByTypeID(request.AccountTypeID, cancellationToken);
        }
    }
}
