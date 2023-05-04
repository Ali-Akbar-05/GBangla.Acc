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

namespace Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.Create
{
    public class CBM_BankCreateCommand:IRequest<RResult>
    {
        public CBM_BankDTM CBM_Bank { get; set; }
    }

    public class CBM_BankCreateCommandHandler : IRequestHandler<CBM_BankCreateCommand, RResult>
    {
        private readonly ICBM_BankService cBM_BankService;

        public CBM_BankCreateCommandHandler(ICBM_BankService _cBM_BankService)
        {
            cBM_BankService = _cBM_BankService;
        }
        public async Task<RResult> Handle(CBM_BankCreateCommand request, CancellationToken cancellationToken)
        {
            return await cBM_BankService.SaveCBMBank(request.CBM_Bank, cancellationToken);
        }
    }
}
