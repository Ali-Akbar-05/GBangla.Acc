using Application.Interfaces.Repositories.GBAcc.Setups;
using Application.Interfaces.Services.GBAcc.Setups;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Setups
{
    public class LedgerBalanceIncomeTaxPercentService : ILedgerBalanceIncomeTaxPercentService
    {
        private readonly ILedgerBalanceIncomeTaxPercentRepository _ledgerBalanceIncomeTaxPercentRepository;

        public LedgerBalanceIncomeTaxPercentService(ILedgerBalanceIncomeTaxPercentRepository ledgerBalanceIncomeTaxPercentRepository)
        {
            _ledgerBalanceIncomeTaxPercentRepository = ledgerBalanceIncomeTaxPercentRepository;
        }
        public async Task<decimal> GetIncomeTaxPercent(decimal LedgerAmount, int CompanyID, CancellationToken cancellationToken)
        {
            return await _ledgerBalanceIncomeTaxPercentRepository.GetIncomeTaxPercent(LedgerAmount,CompanyID,cancellationToken);
        }
    }
}
