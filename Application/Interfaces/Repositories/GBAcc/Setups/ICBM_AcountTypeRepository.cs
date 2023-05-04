
using Application.Common.CommonModels;
using Application.Contracts.GBAcc.Setups.CBMAcountTypes.Queries.RequestResponseModel;
using Domain.Entities.GBAcc.Setups;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories.GBAcc.Setups
{
   public interface ICBM_AcountTypeRepository:IGenericRepository<CBM_AcountType>
    {
        //Task<RResult> SaveAccountType(CBM_AcountType model);
        Task<List<AccountTypeResponseModel>> GetAccountType(CancellationToken cancellationToken);
        Task<RResult> UpdateAccountType(CBM_AcountType model);
    }
    
}
