using Application.Contracts.GBAcc.Setups.CurrencyDetails.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
   public interface ICurrencyDetailRepository:IGenericRepository<CurrencyDetail>
    {
        Task<List<CurrencyDetailResponseModel>> GetAllCurrencyDetailList(CancellationToken cancellationToken);
        Task<CurrencyDetailResponseModel> GetCurrencyDetailByCurrencyID(int currencyID, CancellationToken cancellationToken);
    }
}
