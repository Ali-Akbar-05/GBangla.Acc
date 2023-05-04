using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.Currences.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.Currences.Queries.RequestResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
   public interface ICurrencyService
    {
        Task<RResult> CurrencySave(CurrencyDTM model);
        Task<RResult> CurrencyUpdate(CurrencyDTM model);
        Task<List<CurrencyResponseModel>> GetCurrencyList(CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLCurrency(CancellationToken cancellationToken);
        Task<RResult> CurrencyDataDelete(int currencyID);
    }
}
