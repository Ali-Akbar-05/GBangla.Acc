using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries.RequestResponseModel;
using Application.Interfaces.Repositories.GBAcc.Setups;
using Domain.Entities.GBAcc.Setups;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.ImplementInterfaces.Repositories.GBAcc.Setups
{
    public class CBM_BankAccountRepository : GenericRepository<CBM_BankAccount>, ICBM_BankAccountRepository
    {
        private readonly GBAccDbContext _dbCon;
        public CBM_BankAccountRepository(GBAccDbContext dbCon) : base(dbCon)
        {
            _dbCon = dbCon;
        }
       public async Task<List<BankAccountResponseModel>>GetBankAccountList(CancellationToken cancellationToken)
        {
            var listRtn = await (from bak in _dbCon.CBM_BankAccount
                                 join bco in _dbCon.BasicCOA on bak.TypeID equals bco.AccID
                                 join bra in _dbCon.CBM_Branch on bak.BranchID equals bra.BranchID
                                 join bnk in _dbCon.CBM_Bank on bra.BankID equals bnk.BankID
                                 where bak.IsActive == true && bak.IsRemoved == false
                                 select new BankAccountResponseModel()
                                 {
                                     BAccountID=bak.BAccountID,
                                     AccountName=bak.BAccountName,
                                     AccountType=bco.AccName,
                                     BankName=bnk.BankName,
                                     BranchName=bra.BranchName
                                 }).ToListAsync(cancellationToken);
            return listRtn;
        }
        public async Task<List<SelectListItem>>GetIdentification(int branchID,CancellationToken cancellationToken)
        {
            var rtnList = await (from bak in _dbCon.CBM_BankAccount
                                 join bcoa in _dbCon.BasicCOA on bak.TypeID equals bcoa.AccID
                                 where bak.IsActive == true && bak.IsRemoved == false && bak.BranchID == branchID
                                 select new SelectListItem()
                                 {
                                     Text=$"{bcoa.AccCode}-{bcoa.AccName}" ,
                                     Value=bak.TypeID.ToString()
                                     
                                 }).Distinct().ToListAsync();
           
            return rtnList;
        }

        public async Task<List<SelectListItem>> GetAccountNumberByTypeID(int AccountTypeID, CancellationToken cancellationToken)
        {
            var rtnList = await (from bak in _dbCon.CBM_BankAccount
                                 join bcoa in _dbCon.BasicCOA on bak.BAccountID equals bcoa.AccID
                                 where bak.IsActive == true && bak.IsRemoved == false && bak.TypeID == AccountTypeID
                                 select new SelectListItem()
                                 {
                                     Text = bak.BAccountName,
                                     Value = bak.BAccountID.ToString()

                                 }).Distinct().ToListAsync();

            return rtnList;
        }
        public async Task<List<SelectListItem>> GetCurrencyByAccountID(int AccountID, CancellationToken cancellationToken)
        {
            var rtnList = await (from bak in _dbCon.CBM_BankAccount
                                 join cur in _dbCon.Currency on bak.CurrencyID equals cur.CurrencyID
                                 where bak.IsActive == true && bak.IsRemoved == false && bak.BAccountID == AccountID
                                 select new SelectListItem()
                                 {
                                     Text = cur.CurrencyName,
                                     Value = bak.CurrencyID.ToString()

                                 }).Distinct().ToListAsync();

            return rtnList;
        }
        public async Task<List<SelectListItem>> GetBankAccountNumberByBankID(int bankID, CancellationToken cancellationToken)
        {
            var rtnList = await (from bak in _dbCon.CBM_BankAccount
                                 join bcoa in _dbCon.BasicCOA on bak.BAccountID equals bcoa.AccID
                                 join bran in _dbCon.CBM_Branch on bak.BranchID equals bran.BranchID
                                 join bank in _dbCon.CBM_Bank on bran.BankID equals bank.BankID
                                 where bak.IsActive == true && bak.IsRemoved == false && bank.BankID == bankID
                                 select new SelectListItem()
                                 {
                                     Text = bak.BAccountName,
                                     Value = bak.BAccountID.ToString()

                                 }).Distinct().ToListAsync();

            return rtnList;
        }

    }
}
