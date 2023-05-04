using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries
{
   public class GetBankAccountListQuery:IRequest<List<BankAccountResponseModel>>
    {
    }
    public class GetBankAccountListQueryHandler : IRequestHandler<GetBankAccountListQuery, List<BankAccountResponseModel>>
    {
        private readonly ICBM_BankAccountService cBM_BankAccountService;

        public GetBankAccountListQueryHandler(ICBM_BankAccountService _cBM_BankAccountService)
        {
            cBM_BankAccountService = _cBM_BankAccountService;
        }
        public async Task<List<BankAccountResponseModel>> Handle(GetBankAccountListQuery request, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountService.GetBankAccountList(cancellationToken);
        }
    }
}
