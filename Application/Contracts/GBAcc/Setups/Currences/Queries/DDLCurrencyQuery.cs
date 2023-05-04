using Application.Contracts.GBAcc.Setups.Currences.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.Currences.Queries
{
   public class DDLCurrencyQuery:IRequest<List<SelectListItem>>
    {
    }
    public class DDLCurrencyQueryHandler : IRequestHandler<DDLCurrencyQuery, List<SelectListItem>>
    {
        private readonly ICurrencyService currencyService;

        public DDLCurrencyQueryHandler(ICurrencyService _currencyService)
        {
            currencyService = _currencyService;
        }
        public async Task<List<SelectListItem>> Handle(DDLCurrencyQuery request, CancellationToken cancellationToken)
        {
            return await currencyService.DDLCurrency(cancellationToken);
        }
    }
}
