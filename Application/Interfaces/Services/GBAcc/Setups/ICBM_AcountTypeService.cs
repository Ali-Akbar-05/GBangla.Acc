using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Commands.DataTransferModel;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries.RequestResponseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Services.GBAcc.Setups
{
  public  interface ICBM_AcountTypeService
    {
        Task<RResult> SaveAccountType(CBM_AcountTypeDTM model,CancellationToken cancellationToken);
        Task<List<AccountTypeResponseModel>> GetAccountType(CancellationToken cancellationToken);
        Task<RResult> UpdateAccountType(CBM_AcountTypeDTM model, CancellationToken cancellationToken);
    }
}
