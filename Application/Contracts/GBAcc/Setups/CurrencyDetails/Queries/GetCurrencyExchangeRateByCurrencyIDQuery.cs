using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries
{
   public class GetCurrencyExchangeRateByCurrencyIDQuery:IRequest<decimal>
    {
        public int CurrencyID { get; set; }
    }
    public class GetCurrencyExchangeRateByCurrencyIDQueryHandler : IRequestHandler<GetCurrencyExchangeRateByCurrencyIDQuery, decimal>
    {
        private readonly ICurrencyDetailService currencyDetailService;

        public GetCurrencyExchangeRateByCurrencyIDQueryHandler(ICurrencyDetailService _currencyDetailService)
        {
            currencyDetailService = _currencyDetailService;
        }
        public async Task<decimal> Handle(GetCurrencyExchangeRateByCurrencyIDQuery request, CancellationToken cancellationToken)
        {
            return await currencyDetailService.GetCurrencyExchangeRateByCurrencyID(request.CurrencyID, cancellationToken);
        }
    }
}
