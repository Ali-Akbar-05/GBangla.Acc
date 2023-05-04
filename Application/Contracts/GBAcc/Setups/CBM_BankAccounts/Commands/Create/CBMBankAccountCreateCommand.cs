using Application.Common.CommonModels;

using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Commands.Create
{
  public  class CBMBankAccountCreateCommand:IRequest<RResult>
    {
        public CBM_BankAccountDTM CBM_BankAccount { get; set; }
    }
    public class CBMBankAccountCreateCommandHandler : IRequestHandler<CBMBankAccountCreateCommand, RResult>
    {
        private readonly ICBM_BankAccountService cBM_BankAccountService;

        public CBMBankAccountCreateCommandHandler(ICBM_BankAccountService _cBM_BankAccountService)
        {
            cBM_BankAccountService = _cBM_BankAccountService;
        }
        public async Task<RResult> Handle(CBMBankAccountCreateCommand request, CancellationToken cancellationToken)
        {
            return await cBM_BankAccountService.SaveBankAccount(request.CBM_BankAccount, cancellationToken);
        }
    }
}
