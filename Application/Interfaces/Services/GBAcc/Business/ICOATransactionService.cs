using Application.Contracts.GBAcc.Business.COATransactions.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Business
{
   public interface ICOATransactionService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccBalance">0= Opening & Current Balance,</param>
        /// <param name="AccBalance">1= Current Balance,</param>
        /// <param name="FiscalYear">Current Fiscal(Floor) Year </param>
        /// <param name="AccountID">Chart Of Account ID</param>
        /// <returns></returns>
        Task<LedgerBalanceResponseModel> GetLedgerBalance(int AccBalanceType, int FiscalYear, int BusinessID, int AccountID, CancellationToken cancellationToken);
        Task<CBM_AdvanceForAdjustmentTotalDRM> GetCBM_AdvanceForAdjustment(int AccountID, int BusinessID, CancellationToken cancellationToken);
        Task<List<APM_InvoiceForPaymentDRM>> GetAPM_InvoiceForPayment(int AccountID, int BusinessID, CancellationToken cancellationToken);
    }
}
