using Application.Contracts.GBAcc.Business.COATransactions.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Enums;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class COATransactionRepository : ICOATransactionRepository
    {
        private readonly GBAccDbContext _dbCon;
        public COATransactionRepository(GBAccDbContext dbcon)
        {
            _dbCon = dbcon;
        }
        public async Task<LedgerBalanceResponseModel> GetLedgerBalance(int AccBalanceType, int FiscalYear, int BusinessID, int AccountID, CancellationToken cancellationToken)
        {
            LedgerBalanceResponseModel rmodel = new LedgerBalanceResponseModel();
            
           
            DateTime dateFrom = new DateTime();
            DateTime dateTo= new DateTime();
            var CalculatedVoucherStatus = new[] { 1, 5, 10, 15 };
                
                /*await _dbCon.VoucherStatus.Where(b => b.IsActive == true
                                          && b.IsRemoved == false
                                          && b.IsAmountCalculation == true)
                .Select(b => b.StatusID).ToListAsync();
            */
            if (AccBalanceType== 1)
            {
                dateFrom = new DateTime(FiscalYear,7,1);
                dateTo = new DateTime(FiscalYear+1,6,30);
            }
            else
            {
                dateFrom = new DateTime(FiscalYear - 1, 7, 30);
                dateTo = new DateTime(FiscalYear , 6, 30);
            }
            decimal currentAmount = 0;

            if (AccBalanceType == 1)
            {
                rmodel.OpeningBalance = 0;

                var dataquery1 = from v in _dbCon.vw_VoucherMD
                                 join chq in _dbCon.CBMCheque on v.VoucherID equals chq.VoucherID
                                 where v.AccountID == AccountID
                                 && v.VoucherDate >= dateFrom && v.VoucherDate <= dateTo
                                 && v.VoucherType == (int)Enum_VoucherType.BPV
                                 && chq.ChequeDescription != null
                                 && !chq.ChequeDescription.Contains("Bangladesh Bank")
                                 select new { VoucherAmount = v.Amount };

                currentAmount = await dataquery1.SumAsync(b => b.VoucherAmount);
            }
            else
            {
                var dataquery0 = from v in _dbCon.vw_VoucherMD

                                 where v.VoucherDate >= dateFrom && v.VoucherDate <= dateTo
                                 && CalculatedVoucherStatus.Contains(v.Status)
                                 && v.AccountID == AccountID
                                 select new { VoucherAmount = v.Amount };

                currentAmount = await dataquery0.SumAsync(b => b.VoucherAmount);

                var openingQuery = await _dbCon.COAOpeningBalance
                    .Where(b => b.AccountID == AccountID 
                             && b.FiscalYear == (FiscalYear - 1))
                    .SumAsync(b => b.OpeningBalance); 
            }
       

            rmodel.LedgerBalance = currentAmount;

           
           // rmodel.FiscalYear = FiscalYear;

            return rmodel;
            
         
        }

        public async Task<CBM_AdvanceForAdjustmentTotalDRM> GetCBM_AdvanceForAdjustment(int AccountID, int BusinessID, CancellationToken cancellationToken)
        {
            var advanceList = new CBM_AdvanceForAdjustmentTotalDRM(); ;

            await _dbCon.LoadStoredProc("Ajt.USP_GetCBM_AdvanceForAdjustment")
                .WithSqlParam("AccountID", AccountID)
                .WithSqlParam("BusinessID", BusinessID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    advanceList.CBM_AdvanceForAdjustment = handler.ReadToList<CBM_AdvanceForAdjustmentDRM>() as List<CBM_AdvanceForAdjustmentDRM>;
                });


            return advanceList;
        }

        public async Task<List<APM_InvoiceForPaymentDRM>> GetAPM_InvoiceForPayment(int AccountID, int BusinessID, CancellationToken cancellationToken)
        {
            var advanceList = new List<APM_InvoiceForPaymentDRM>(); ;

            await _dbCon.LoadStoredProc("Ajt.usp_GetAPM_InvoiceForPayment")
                .WithSqlParam("AccountID", AccountID)
                .WithSqlParam("BusinessID", BusinessID)
                .ExecuteStoredProcAsync((handler) =>
                {
                    advanceList = handler.ReadToList<APM_InvoiceForPaymentDRM>() as List<APM_InvoiceForPaymentDRM>;

                });


            return advanceList;
        }
    }
}
