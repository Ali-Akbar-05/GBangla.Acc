using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Setups;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
   public interface ICBM_BankAccountRepository:IGenericRepository<CBM_BankAccount>
    {
        Task<List<BankAccountResponseModel>> GetBankAccountList(CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetIdentification(int branchID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetAccountNumberByTypeID(int AccountTypeID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetCurrencyByAccountID(int AccountID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetBankAccountNumberByBankID(int bankID, CancellationToken cancellationToken);
    }
}
