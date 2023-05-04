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
   public class AdvanceForAdjustmentQuery :IRequest<CBM_AdvanceForAdjustmentTotalDRM>
    {
        public int AccountID { get; set; }
        public int BusinessID { get; set; }

    }
    public class AdvanceForAdjustmentQueryHandler : IRequestHandler<AdvanceForAdjustmentQuery, CBM_AdvanceForAdjustmentTotalDRM>
    {
        private readonly ICOATransactionService _coatransactionsService;

        public AdvanceForAdjustmentQueryHandler(ICOATransactionService coatransactionsService)
        {
            _coatransactionsService = coatransactionsService;
        }
        public async Task<CBM_AdvanceForAdjustmentTotalDRM> Handle(AdvanceForAdjustmentQuery request, CancellationToken cancellationToken)
        {
            return await _coatransactionsService.GetCBM_AdvanceForAdjustment(request.AccountID,request.BusinessID,cancellationToken);
        }
    }
}
