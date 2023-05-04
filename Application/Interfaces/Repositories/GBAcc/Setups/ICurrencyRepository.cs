using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Currences.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
  public  interface ICurrencyRepository:IGenericRepository<Currency>
    {
        Task<RResult> CurrencyUpdate(Currency model);
        Task<List<CurrencyResponseModel>> GetCurrencyList(CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLCurrency(CancellationToken cancellationToken);
        Task<RResult> CurrencyDataDelete(int currencyID);

    }
}
