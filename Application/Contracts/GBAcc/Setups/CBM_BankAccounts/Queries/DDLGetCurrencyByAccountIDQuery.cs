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
   public class DDLGetCurrencyByAccountIDQuery:IRequest<List<SelectListItem>>
    {
        public int AccountID { get; set; }
    }
    public class DDLGetCurrencyByAccountIDQueryHandler : IRequestHandler<DDLGetCurrencyByAccountIDQuery, List<SelectListItem>>
    {
        private readonly ICBM_BankAccountService cBM_BankAccountService;

        public DDLGetCurrencyByAccountIDQueryHandler(ICBM_BankAccountService _cBM_BankAccountService)
        {
            cBM_BankAccountService = _cBM_BankAccountService;
        }
        public async Task<List<SelectListItem>> Handle(DDLGetCurrencyByAccountIDQuery request, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountService.GetCurrencyByAccountID(request.AccountID, cancellationToken);
        }
    }
}
