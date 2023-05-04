using Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries.RequestResponseModel;
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
   public class GetAllCurrencyDetailListQuery:IRequest<List<CurrencyDetailResponseModel>>
    {
    }
    public class GetAllCurrencyDetailListQueryHandler : IRequestHandler<GetAllCurrencyDetailListQuery, List<CurrencyDetailResponseModel>>
    {
        private readonly ICurrencyDetailService currencyDetailService;

        public GetAllCurrencyDetailListQueryHandler(ICurrencyDetailService _currencyDetailService)
        {
            currencyDetailService = _currencyDetailService;
        }
        public async Task<List<CurrencyDetailResponseModel>> Handle(GetAllCurrencyDetailListQuery request, CancellationToken cancellationToken)
        {
            return await currencyDetailService.GetAllCurrencyDetailList(cancellationToken);
        }
    }
}
