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
   public class APM_InvoiceForPaymentQuery :IRequest<List<APM_InvoiceForPaymentDRM>>
    {
        public int AccountID { get; set; }
       public int BusinessID { get; set; }
    }

    public class APM_InvoiceForPaymentQueryHandler : IRequestHandler<APM_InvoiceForPaymentQuery, List<APM_InvoiceForPaymentDRM>>
    {
        private readonly ICOATransactionService _coatransactionsService;
        public APM_InvoiceForPaymentQueryHandler(ICOATransactionService coatransactionsService)
        {
            _coatransactionsService = coatransactionsService;
        }
        public async Task<List<APM_InvoiceForPaymentDRM>> Handle(APM_InvoiceForPaymentQuery request, CancellationToken cancellationToken)
        {
            return await _coatransactionsService.GetAPM_InvoiceForPayment(request.AccountID,request.BusinessID,cancellationToken);
        }
    }
}
