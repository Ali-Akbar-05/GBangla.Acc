using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries.RequestResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
   public interface ICBM_BankService
    {
        Task<RResult> SaveCBMBank(CBM_BankDTM model, CancellationToken cancellationToken);
        Task<RResult> UpdateCBMBank(CBM_BankDTM model, CancellationToken cancellationToken);
        Task<List<CBM_BankResponseModel>> GetCBMBankList(CancellationToken cancellationToken);
        Task<RResult> BankDataDelete(int bankID);
        Task<List<SelectListItem>> DDLGetBankList(int companyID, CancellationToken cancellationToken);
    }
}
