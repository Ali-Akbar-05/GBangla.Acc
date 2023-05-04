using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Currences.Commands.DataTransferModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Currences.Commands.Update
{
   public class CurrencyUpdateCommand:IRequest<RResult>
    {
        public CurrencyDTM CurrencyDTM { get; set; }
    }
    public class CurrencyUpdateCommandHandler : IRequestHandler<CurrencyUpdateCommand, RResult>
    {
        private readonly ICurrencyService currencyService;

        public CurrencyUpdateCommandHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }
        public async Task<RResult> Handle(CurrencyUpdateCommand request, CancellationToken cancellationToken)
        {
            return await currencyService.CurrencyUpdate(request.CurrencyDTM);
        }
    }
}
