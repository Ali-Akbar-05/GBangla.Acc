using Application.Contracts.GBAcc.Business.COATransactions.Queries.RequestResponseModel;
using Application.Interfaces.Services.GBAcc.Business;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Contracts.GBAcc.Business.COATransactions.Queries
{
    public class GetLedgerBalanceQuery:IRequest<LedgerBalanceResponseModel>
    {
          public int AccBalanceType { get; set; }
          public  int FiscalYear      {get;set;}
          public  int BusinessID      {get;set;}
          public  int AccountID       {get;set;}
    }
    public class GetLedgerBalanceQueryHandler : IRequestHandler<GetLedgerBalanceQuery, LedgerBalanceResponseModel>
    {
        private readonly ICOATransactionService _coatransactionsService;

        public GetLedgerBalanceQueryHandler(ICOATransactionService coatransactionsService)
        {
            _coatransactionsService = coatransactionsService;
        }
        public async Task<LedgerBalanceResponseModel> Handle(GetLedgerBalanceQuery request, CancellationToken cancellationToken)
        {
            return await _coatransactionsService.GetLedgerBalance(request.AccBalanceType, request.FiscalYear, request.BusinessID, request.AccountID, cancellationToken);
        }
    }
}
