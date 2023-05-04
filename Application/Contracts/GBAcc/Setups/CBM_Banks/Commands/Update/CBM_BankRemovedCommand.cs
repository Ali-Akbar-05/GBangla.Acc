using Application.Common.CommonModels;
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
  public  class CBM_BankRemovedCommand:IRequest<RResult>
    {
        public int BankID { get; set; }
    }
    public class CBM_BankRemovedCommandHandler : IRequestHandler<CBM_BankRemovedCommand, RResult>
    {
        private readonly ICBM_BankService cBM_BankService;

        public CBM_BankRemovedCommandHandler(ICBM_BankService _cBM_BankService)
        {
            cBM_BankService = _cBM_BankService;
        }
        public async Task<RResult> Handle(CBM_BankRemovedCommand request, CancellationToken cancellationToken)
        {
            return await cBM_BankService.BankDataDelete(request.BankID);
        }
    }
}
