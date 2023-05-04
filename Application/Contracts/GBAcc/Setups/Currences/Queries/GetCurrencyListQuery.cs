using Application.Contracts.GBAcc.Setups.Currences.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Currences.Queries
{
   public class GetCurrencyListQuery:IRequest<List<CurrencyResponseModel>>
    {
    }
    public class GetCurrencyListQueryHandler : IRequestHandler<GetCurrencyListQuery, List<CurrencyResponseModel>>
    {
        private readonly ICurrencyService currencyService;

        public GetCurrencyListQueryHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }
        public async Task<List<CurrencyResponseModel>> Handle(GetCurrencyListQuery request, CancellationToken cancellationToken)
        {
            return await currencyService.GetCurrencyList(cancellationToken);
        }
    }
}
