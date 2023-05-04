using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
   public interface ICurrencyDetailService
    {
        Task<RResult> SaveCurrencyDetail(CurrencyDetailDTM model);
        Task<RResult> UpdateCurrencyDetail(CurrencyDetailDTM model);
        Task<RResult> DeleteCurrencyDetail(int ID, bool saveChange);
        Task<List<CurrencyDetailResponseModel>> GetAllCurrencyDetailList(CancellationToken cancellationToken);
        Task<decimal> GetCurrencyExchangeRateByCurrencyID(int currencyID, CancellationToken cancellationToken);
    }
}
