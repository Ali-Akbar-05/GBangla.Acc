using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBM_BankAccounts.Queries.RequestResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
  public  interface ICBM_BankAccountService
    {
        Task<RResult> SaveBankAccount(CBM_BankAccountDTM model,CancellationToken cancellationToken);
        Task<List<BankAccountResponseModel>> GetBankAccountList(CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetIdentification(int branchID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetAccountNumberByTypeID(int AccountTypeID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetCurrencyByAccountID(int AccountID, CancellationToken cancellationToken);
        Task<List<SelectListItem>> GetBankAccountNumberByBankID(int bankID, CancellationToken cancellationToken);
    }
}
