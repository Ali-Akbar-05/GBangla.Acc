using Domain.Entities.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
  public  interface ILedgerBalanceIncomeTaxPercentRepository :IGenericRepository<LedgerBalanceIncomeTaxPercent>
    {
        Task<decimal> GetIncomeTaxPercent(decimal LedgerAmount, int CompanyID, CancellationToken cancellationToken);
    }
}
