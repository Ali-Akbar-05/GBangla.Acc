using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMCheques.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Business;
using Domain.Constants;
using Domain.Entities.GBAcc.Business;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Business
{
    public class CBMChequeRepository : GenericRepository<CBMCheque>, ICBMChequeRepository
    {
        private GBAccDbContext accDbContext;
        public CBMChequeRepository(GBAccDbContext context)
            : base(context)
        {
            accDbContext = context;
        }
        public async Task<RResult> SaveCBMChequeList(List<CBMCheque> model)
        {
            var result = new RResult();
            try
            {

                await accDbContext.CBMCheque.AddRangeAsync(model);
                await accDbContext.SaveChangesAsync();
                result.result = 1;
                result.message = ReturnMessage.SaveMessage;
            }
            catch (Exception e)
            {
                result.result = 0;
                result.message = e.Message;

               
            }
            return result;
        }

        public async Task<List<CBMChequeResponseModel>> GetChequeList(int chequeBookID, CancellationToken cancellationToken)
        {
            var rtnList = await (from chq in accDbContext.CBMCheque
                                 join sts in accDbContext.CBMChequeStatus on chq.ChequeStatusID equals sts.ChequeStatusID
                                 where chq.ChequeBookID == chequeBookID && chq.IsActive == true && chq.IsRemoved == false
                                 select new CBMChequeResponseModel()
                                 {
                                     ChequeAmount = chq.ChequeAmount,
                                     ChequeNum = chq.ChequeNum,
                                     StrChequeDate = chq.ChequeDate == null ? "" : chq.ChequeDate.Value.ToString("dd-MMM-yyyy"),
                                     StrChequeAmount=chq.ChequeAmount>0? chq.ChequeAmount.ToString() :"",
                                     StrChequeStatus=sts.StatusName
                                 }).ToListAsync();
            return rtnList;
        }

        public async Task<RResult> UpdateCBMCheque(CBMCheque entity)
        {
            RResult rResult = new RResult();
            var dbEntiry = await GetByIdAsync(entity.ChequeID);
            dbEntiry.VoucherID = entity.VoucherID;
            dbEntiry.AccountID = entity.AccountID;
            dbEntiry.ChequeStatusID = entity.ChequeStatusID;
            dbEntiry.ChequeAmount = entity.ChequeAmount;
            dbEntiry.ChequeDate = entity.ChequeDate;
            dbEntiry.ChequeDescription = entity.ChequeDescription;

            accDbContext.Update(dbEntiry);
            await accDbContext.SaveChangesAsync();
            rResult.result = 1;
            rResult.message = ReturnMessage.UpdateMessage;
            return rResult;
        }
    }
}
