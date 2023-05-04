using Application.Interfaces.Services.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Setups.LedgerBalanceIncomeTaxPercnts.Queries
{
  public class GetLedgerBalanceIncomeTaxPercntQuery:IRequest<decimal>
    {
        public decimal LedgerAmount { get; set; }
        public int CompanyID { get; set; }
    }

    public class GetLedgerBalanceIncomeTaxPercntQueryHandler : IRequestHandler<GetLedgerBalanceIncomeTaxPercntQuery, decimal>
    {
        private readonly ILedgerBalanceIncomeTaxPercentService _ledgerBalanceIncomeTaxPercentService;

        public GetLedgerBalanceIncomeTaxPercntQueryHandler(ILedgerBalanceIncomeTaxPercentService ledgerBalanceIncomeTaxPercentService)
        {
            _ledgerBalanceIncomeTaxPercentService = ledgerBalanceIncomeTaxPercentService;
        }
        public async Task<decimal> Handle(GetLedgerBalanceIncomeTaxPercntQuery request, CancellationToken cancellationToken)
        {
            return await _ledgerBalanceIncomeTaxPercentService.GetIncomeTaxPercent(request.LedgerAmount,request.CompanyID, cancellationToken);
        }
    }
}
