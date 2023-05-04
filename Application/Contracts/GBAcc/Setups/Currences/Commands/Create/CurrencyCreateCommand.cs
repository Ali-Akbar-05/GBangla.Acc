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

namespace Application.Contracts.GBAcc.Setups.Currences.Commands.Create
{
   public class CurrencyCreateCommand:IRequest<RResult>
    {
        public CurrencyDTM CurrencyDTM { get; set; }
    }
    public class CurrencyCreateCommandHandler : IRequestHandler<CurrencyCreateCommand, RResult>
    {
        private readonly ICurrencyService currencyService;

        public CurrencyCreateCommandHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }
        public async Task<RResult> Handle(CurrencyCreateCommand request, CancellationToken cancellationToken)
        {
            return await currencyService.CurrencySave(request.CurrencyDTM);
        }
    }
}
