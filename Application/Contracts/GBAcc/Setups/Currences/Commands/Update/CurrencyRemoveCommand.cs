using Application.Common.CommonModels;
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
   public class CurrencyRemoveCommand:IRequest<RResult>
    {
        public int CurrencyID { get; set; }
    }
    public class CurrencyRemoveCommandHandler : IRequestHandler<CurrencyRemoveCommand, RResult>
    {
        private readonly ICurrencyService currencyService;

        public CurrencyRemoveCommandHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }
        public async Task<RResult> Handle(CurrencyRemoveCommand request, CancellationToken cancellationToken)
        {
            return await currencyService.CurrencyDataDelete(request.CurrencyID);
        }
    }
}
