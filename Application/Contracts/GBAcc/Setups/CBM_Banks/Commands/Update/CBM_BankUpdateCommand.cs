using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.Update
{
  public  class CBM_BankUpdateCommand:IRequest<RResult>
    {
        public CBM_BankDTM CBMBankDTM { get; set; }
    }
    public class CBM_BankUpdateCommandHandler : IRequestHandler<CBM_BankUpdateCommand, RResult>
    {
        private readonly ICBM_BankService iCBM_BankService;

        public CBM_BankUpdateCommandHandler(ICBM_BankService _iCBM_BankService)
        {
            iCBM_BankService = _iCBM_BankService;
        }
        public async Task<RResult> Handle(CBM_BankUpdateCommand request, CancellationToken cancellationToken)
        {
            return await iCBM_BankService.UpdateCBMBank(request.CBMBankDTM,cancellationToken);
        }
    }
}
