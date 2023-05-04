using Application.Contracts.GBAcc.Business.COATransactions.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Application.Interfaces.Services.GBAcc.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Services.GBAcc.Business
{
    public class COATransactionsService : ICOATransactionService
    {
        private readonly ICOATransactionRepository _coaTransactionsRepository;
        public COATransactionsService(ICOATransactionRepository coaTransactionsRepository )
        {
            _coaTransactionsRepository = coaTransactionsRepository;
        }

        public async Task<List<APM_InvoiceForPaymentDRM>> GetAPM_InvoiceForPayment(int AccountID, int BusinessID, CancellationToken cancellationToken)
        {
            return await _coaTransactionsRepository.GetAPM_InvoiceForPayment(AccountID,BusinessID,cancellationToken);
        }

        public async Task<CBM_AdvanceForAdjustmentTotalDRM> GetCBM_AdvanceForAdjustment(int AccountID, int BusinessID, CancellationToken cancellationToken)
        {
            return await _coaTransactionsRepository.GetCBM_AdvanceForAdjustment(AccountID,BusinessID,cancellationToken);
        }

        public async Task<LedgerBalanceResponseModel> GetLedgerBalance(int AccBalanceType, int FiscalYear, int BusinessID, int AccountID, CancellationToken cancellationToken)
        {
            return await _coaTransactionsRepository.GetLedgerBalance(AccBalanceType,FiscalYear,BusinessID,AccountID,cancellationToken); 
        }
    }
}
