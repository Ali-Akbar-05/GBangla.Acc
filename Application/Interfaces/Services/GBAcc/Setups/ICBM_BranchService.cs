using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBMBranchs.Queries.RequestResponseModel;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
   public interface ICBM_BranchService
    {
        Task<RResult> BranchSave(CBM_BranchDTM model);
        Task<RResult> BranchUpdate(CBM_BranchDTM model);
        Task<RResult> BranchDelete(int branchID);
        Task<List<CBM_BranchResponseModel>> GetCBMBranchList(CancellationToken cancellationToken);
        Task<List<SelectListItem>> DDLGetBranchList(int bankID, CancellationToken cancellationToken);
    }
}
