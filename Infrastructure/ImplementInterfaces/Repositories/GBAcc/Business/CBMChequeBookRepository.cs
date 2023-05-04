using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Business.CBMChequeBooks.Queries.RequestResponseModel;
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
    public class CBMChequeBookRepository : GenericRepository<CBMChequeBook>, ICBMChequeBookRepository
    {
        private readonly GBAccDbContext _dbCon;
        public CBMChequeBookRepository(GBAccDbContext dbCon):base(dbCon)
        {
            _dbCon = dbCon;
        }
        public async Task<int> AvailableCheque(int AccountID, CancellationToken cancallationToken)
        {
            var query = from cb in _dbCon.CBMChequeBook
                        join cq in _dbCon.CBMCheque on new { x1 = cb.ID, x2 = true, x3 = false } equals
                                                       new { x1 = cq.ChequeBookID, x2 = cq.IsActive, x3 = cq.IsRemoved }
                        where cb.AccountID == AccountID && cb.IsRemoved == false && cb.IsActive == true
                         && cq.ChequeStatusID == 1
                         && cb.SerialStatus == "Unused"
                        select new
                        {
                            TotalCheque =cq.ChequeID
                        };
            var totalCheq = await query.CountAsync(cancallationToken); 
            return totalCheq;

        }

        public async Task<RResult> CreateChequeBook(CBMChequeBook model)
        {
            var result = new RResult();
            await _dbCon.CBMChequeBook.AddAsync(model);
            await _dbCon.SaveChangesAsync();
            result.result = 1;
            result.message = ReturnMessage.SaveMessage;
            result.statusCode =model.ID;
            return result;
        }

        public async Task<List<CBMChequeBookResponseModel>> GetChequeBookList(ChequeBookRequestModel model, CancellationToken cancellationToken)
        {
            var rtnList = await (from cbacc in _dbCon.CBM_BankAccount
                                 join bcoa in _dbCon.BasicCOA on cbacc.TypeID equals bcoa.AccID
                                 join chkb in _dbCon.CBMChequeBook on cbacc.BAccountID equals chkb.AccountID
                                 join bra in _dbCon.CBM_Branch on cbacc.BranchID equals bra.BranchID
                                 join bnk in _dbCon.CBM_Bank on bra.BankID equals bnk.BankID
                                 where
                                 (model.BankID == 0 || bnk.BankID == model.BankID)
                                 && (model.BranchID == 0 || cbacc.BranchID == model.BranchID)
                                 && (model.IdentificationID == 0 || cbacc.TypeID == model.IdentificationID)
                                 && (model.AccountNumberID == 0 || chkb.AccountID == model.AccountNumberID)
                                 && (model.CurrencyID == 0 || cbacc.CurrencyID == model.CurrencyID)
                                 && (model.Status == null || chkb.SerialStatus == model.Status)
                                  && chkb.IsActive == true 
                                 && chkb.IsRemoved == false
                                 select new CBMChequeBookResponseModel()
                                 {
                                     BankID=bnk.BankID,
                                     BankName=bnk.BankName,
                                     ID= chkb.ID,
                                     Prefix= chkb.Prefix,
                                     SeriesStart= chkb.SeriesStart,
                                     SeriesEnd= chkb.SeriesEnd,
                                     SerialStatus= chkb.SerialStatus,
                                     AccountID = chkb.AccountID,
                                     AccountNumber=cbacc.BAccountName
                                 }).ToListAsync(cancellationToken);
            return rtnList;
        }

        public async Task<ChequeInActiveInfoResponseModel> GetInactiveChequeInfo(int AccountID, CancellationToken cancellationToken)
        {
            var query = from cb in _dbCon.CBMChequeBook
                        join cq in _dbCon.CBMCheque on new { x1 = cb.ID, x2 = true, x3 = false } equals
                                                       new { x1 = cq.ChequeBookID, x2 = cq.IsActive, x3 = cq.IsRemoved }
                        join acc in _dbCon.BasicCOA on cb.AccountID equals acc.AccID
                        where cb.AccountID == AccountID && cb.IsRemoved == false && cb.IsActive == true
                         && cq.ChequeStatusID == 1
                         && cb.SerialStatus == "Unused"
                         orderby cq.ChequeID
                        select new ChequeInActiveInfoResponseModel
                        {
                            ChequeID =cq.ChequeID,
                            ChequeNumber = cq.ChequeNum,
                            ChequePrefix = cb.Prefix,
                            ChequeStatusID = cq.ChequeStatusID,
                            COABankAccountID = cb.AccountID,
                            COAAccountName = acc.AccName
                        };
            var chequeInfo = await query.FirstAsync(cancellationToken);
            return chequeInfo;
        }
    }
}
