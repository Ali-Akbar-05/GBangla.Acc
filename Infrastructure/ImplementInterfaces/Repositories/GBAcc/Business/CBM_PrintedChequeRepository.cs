using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMPrintedCheques.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Constants;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using Snickler.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
  public  class CBM_PrintedChequeRepository:GenericRepository<CBM_PrintedCheque>, ICBM_PrintedChequeRepository
    {
        private GBAccDbContext accDbContext;
        public CBM_PrintedChequeRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }

        public async Task<List<PrintedChequesResponseModel>> GetCBM_PrintedCheques(PrintedChequesRequestModel model, CancellationToken cancellationToken)
        {
            var listOfPrintedCheque = new List<PrintedChequesResponseModel>();
            await accDbContext.LoadStoredProc("Ajt.usp_CBM_PrintedCheques_Get", commandTimeout: 300)
               .WithSqlParam("accountID", model.AccountID)
                .WithSqlParam("dateFrom", model.DateFrom)
                 .WithSqlParam("dateTo", model.DateTo)
                  .WithSqlParam("ChqDesc", model.ChequeDescription)
                   .WithSqlParam("status", model.Status)
               .ExecuteStoredProcAsync((handler) =>
               {
                   listOfPrintedCheque = handler.ReadToList<PrintedChequesResponseModel>() as List<PrintedChequesResponseModel>;

               });
            return listOfPrintedCheque;
        }

        public async Task<RResult> UpdatePrintedCheque(List<CBM_PrintedCheque> model)
        {
            var result = new RResult();
            foreach (var item in model)
            {
                var dbObj = await accDbContext.CBM_PrintedCheque.FindAsync(item.ChqID);
                dbObj.Status = item.Status;
                dbObj.TransactionDate = item.TransactionDate;
                await UpdateAsync(dbObj, true);
            }
            result.result = 1;
            result.message = ReturnMessage.UpdateMessage;
            return result;
        }
    }
}
