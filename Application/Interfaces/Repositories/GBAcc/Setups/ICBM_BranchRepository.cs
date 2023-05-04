using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Queries.RequestResponseModel;
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
   public interface ICBM_BranchRepository:IGenericRepository<CBM_Branch>
    {
        Task<RResult> BranchSave(CBM_Branch model);
        Task<RResult> BranchUpdate(CBM_Branch model);
        Task<RResult> BranchDelete(int branchID);
        Task<List<CBM_BranchResponseModel>> GetCBMBranchList(CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLGetBranchList(int bankID, CancellationToken cancellationToken);
    }
}
