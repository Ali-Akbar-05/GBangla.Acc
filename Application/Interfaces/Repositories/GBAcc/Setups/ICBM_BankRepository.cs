using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBM_Banks.Queries.RequestResponseModel;
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
    public interface ICBM_BankRepository:IGenericRepository<CBM_Bank>
    {
        Task<RResult> BankDataDelete(int bankID);
        Task<List<CBM_BankResponseModel>> GetCBMBankList(CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLGetBankList(int companyID, CancellationToken cancellationToken);

    }
}
